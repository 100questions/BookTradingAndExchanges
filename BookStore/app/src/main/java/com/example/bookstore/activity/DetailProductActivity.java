package com.example.bookstore.activity;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.adapter.ProductAdapter;
import com.example.bookstore.adapter.RecyclerViewTouchListener;
import com.example.bookstore.model.Entity.Book;
import com.example.bookstore.R;
import com.example.bookstore.room.database.AppDatabase;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;
import java.util.Objects;

import jp.wasabeef.recyclerview.animators.SlideInUpAnimator;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class DetailProductActivity extends AppCompatActivity {
    RecyclerView recyclerViewProduct;
    ProductAdapter productAdapter;
    ArrayList<Book> products;
    TextView txtPrice;
    TextView txtDiscountPrice;
    ImageView imgBack;
    ImageView imgBook;
    TextView txtBookName;
    RequestAPI requestAPI;
    Button btnBuy;
    AppDatabase mDB;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_detail_product);
        Objects.requireNonNull(getSupportActionBar()).hide();
        init();
        mDB = AppDatabase.getInMemoryDatabase(this);
        requestAPI = APIClient.getClient().create(RequestAPI.class);

        // Set Data Detail
        Intent intent = getIntent();
        final Book book = (Book) intent.getSerializableExtra("BookDetail");
        SetBookDetail(book);
        // List Book
        products = new ArrayList<Book>();
        LoadBookAccordingToCategory(book);
        productAdapter = new ProductAdapter(products,this);
        recyclerViewProduct.setAdapter(productAdapter);

        recyclerViewProduct.setItemAnimator(new SlideInUpAnimator());
        recyclerViewProduct.setLayoutManager(new LinearLayoutManager(this, RecyclerView.HORIZONTAL,false));
        productAdapter.notifyDataSetChanged();

        recyclerViewProduct.addOnItemTouchListener(new RecyclerViewTouchListener(this, recyclerViewProduct, new RecyclerViewTouchListener.ClickListener() {
            @Override
            public void onClick(View view, int position) {
                Book book = products.get(position);
                SetBookDetail(book);
                LoadBookAccordingToCategory(book);
            }

            @Override
            public void onLongClick(View view, int position) {

            }
        }));

        imgBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });

        btnBuy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                mDB.bookDao().insertBook(book);
            }
        });
    }

    private void init()
    {
        recyclerViewProduct = findViewById(R.id.list_book);
        txtPrice = (TextView) findViewById(R.id.price_book);
        txtDiscountPrice = (TextView) findViewById(R.id.price_book_discount);
        imgBook = findViewById(R.id.image_book);
        txtBookName =findViewById(R.id.title_book_detail);
        imgBack = findViewById(R.id.btnBack_detail);
        btnBuy = findViewById(R.id.btn_buy);
    }

    private void LoadBookAccordingToCategory(final Book book)
    {
        Call<ArrayList<Book>> call = requestAPI.getAllBook();
        call.enqueue(new Callback<ArrayList<Book>>() {
            @Override
            public void onResponse(Call<ArrayList<Book>> call, Response<ArrayList<Book>> response) {
                if(response.isSuccessful())
                {
                    for(Book book1 :  response.body())
                    {
                        if(book.getCategories() != null && book1.getCategories() != null) {
                            if (book1.getCategories().equals(book.getCategories()) &&
                                    !book1.getBookId().equals(book.getBookId())) {
                                products.add(book1);
                            }
                        }
                    }
                    productAdapter.SetBookList(products);
                }
            }

            @Override
            public void onFailure(Call<ArrayList<Book>> call, Throwable t) {
                Log.d("TAG","Book = "+t.toString());
            }
        });
    }

    @SuppressLint({"DefaultLocale", "SetTextI18n"})
    private void SetBookDetail(final Book book)
    {
        if(book != null) {
            txtBookName.setText(book.getBookName());
            if (TextUtils.isEmpty(book.getImageBook())) {
                Picasso.get().cancelRequest(imgBook);
                imgBook.setImageDrawable(null);
            }
            else
            {
                Picasso.get()
                        .load(book.getImageBook())
                        .resize(80, 100)
                        .placeholder(R.mipmap.ic_launcher)
                        .error(R.drawable.ic_error_red_24dp)
                        .into(imgBook);
            }
            txtPrice.setText(String.format("%,.0f", book.getPrice()) + " đ");
            txtDiscountPrice.setText(String.format("%,.0f", book.getPrice() * 1.4) + " đ");
        }
    }

}
