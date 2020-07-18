package com.example.bookstore.activity;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;
import androidx.recyclerview.widget.StaggeredGridLayoutManager;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.adapter.ProductTodayAdapter;
import com.example.bookstore.model.Entity.Book;
import com.example.bookstore.R;
import com.google.android.material.snackbar.Snackbar;
import com.jaredrummler.materialspinner.MaterialSpinner;

import java.util.ArrayList;

import jp.wasabeef.recyclerview.animators.SlideInUpAnimator;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ProductOfDashBoardActivity extends AppCompatActivity {
    RecyclerView recyclerView;
    ArrayList<Book> mProducts;
    ProductTodayAdapter productTodayAdapter;
    ImageView btnBack;
    MaterialSpinner spinner;
    RequestAPI requestAPI;
    TextView title;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_product_of_dash_board);
        getSupportActionBar().hide();
        init();
        requestAPI = APIClient.getClient().create(RequestAPI.class);

        spinner.setItems("Giá Thấp", "Giá Cao", "Hàng Mới");
        spinner.setOnItemSelectedListener(new MaterialSpinner.OnItemSelectedListener<String>() {

            @Override
            public void onItemSelected(MaterialSpinner view, int position, long id, String item) {
                Snackbar.make(view, "Clicked " + item, Snackbar.LENGTH_LONG).show();
            }
        });

        //product to day
        mProducts = new ArrayList<Book>();
        GetData();
        productTodayAdapter = new ProductTodayAdapter(mProducts, this);
        recyclerView.setAdapter(productTodayAdapter);

        recyclerView.setItemAnimator(new SlideInUpAnimator());

        recyclerView.setLayoutManager(new StaggeredGridLayoutManager(2,
                StaggeredGridLayoutManager.VERTICAL));

        //productTodayRecyclerView.setLayoutManager(new GridLayoutManager(requireContext(),2));
        productTodayAdapter.notifyDataSetChanged();

        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });
    }

    private void init() {
        recyclerView = findViewById(R.id.list_product);
        btnBack = findViewById(R.id.btnBack_list_book);
        spinner = (MaterialSpinner) findViewById(R.id.spinner);
        title = findViewById(R.id.title_product_of_dashboard);
    }

    private void GetData()
    {
        Intent intent = getIntent();
        Bundle bundle = intent.getExtras();
        if(bundle != null)
        {
            title.setText(bundle.getString("categoryName",""));
            final String categoryID = bundle.getString("categoryID","");
            Call<ArrayList<Book>> bookCall = requestAPI.getAllBook();
            bookCall.enqueue(new Callback<ArrayList<Book>>() {
                @Override
                public void onResponse(Call<ArrayList<Book>> call, Response<ArrayList<Book>> response) {
                    for(Book book : response.body())
                    {
                        if(book.getCategories().equals(categoryID))
                        {
                            mProducts.add(book);
                        }
                    }
                    productTodayAdapter.SetBookList(mProducts);
                }

                @Override
                public void onFailure(Call<ArrayList<Book>> call, Throwable t) {
                    Log.d("TAG","Book = "+t.toString());
                }
            });
        }
    }

}
