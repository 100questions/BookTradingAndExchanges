package com.example.bookstore.activity;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.bookstore.adapter.CartAdapter;
import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.model.CartItemModel;
import com.example.bookstore.R;
import com.example.bookstore.model.Entity.Bill;
import com.example.bookstore.model.Entity.BillDetail;
import com.example.bookstore.model.Entity.User;
import com.example.bookstore.room.database.AppDatabase;
import com.google.android.material.snackbar.Snackbar;

import java.text.SimpleDateFormat;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Locale;
import java.util.UUID;

import jp.wasabeef.recyclerview.animators.SlideInDownAnimator;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class CartActivity extends AppCompatActivity implements CartAdapter.Onclick {
    RecyclerView cartRecyclerView;
    CartAdapter cartAdapter;
    ArrayList<CartItemModel> mListItemCart;
    ImageView btnBack;
    TextView txtSumPrice;
    Button btnBuy;
    AppDatabase mDB;
    RequestAPI requestAPI;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cart);
        getSupportActionBar().hide();
        init();
        mListItemCart = new ArrayList<>();
        GetData();

        cartAdapter = new CartAdapter(this,mListItemCart);
        cartRecyclerView.setAdapter(cartAdapter);
        cartRecyclerView.setItemAnimator(new SlideInDownAnimator());
        cartRecyclerView.setLayoutManager(new LinearLayoutManager(this,LinearLayoutManager.VERTICAL,false));
        cartAdapter.notifyDataSetChanged();

        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });

        btnBuy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(mDB.UseDao().getUser().get(0) == null)
                {
                    Toast.makeText(CartActivity.this, "Please Login !", Toast.LENGTH_SHORT).show();
                    Intent intent = new Intent(CartActivity.this,LoginRegisterActivity.class);
                    startActivity(intent);
                }
                if(mListItemCart.size() > 0)
                {
                    User user = mDB.UseDao().getUser().get(0);
                    Date date = new Date();
                    SimpleDateFormat format = new SimpleDateFormat("dd/MM/yyy HH:mm:ss");
                    String dateNow = format.format(date).toString();
                    String strSumPrice = txtSumPrice.getText().toString().replace(",","").replace(" đ","");
                    Double SumPrice = Double.parseDouble(strSumPrice);
                    final String BillId = UUID.randomUUID().toString();
                    Bill bill = new Bill(BillId,user.getMaKH(),dateNow,SumPrice,null);
                    Call<String> call = requestAPI.CreateBill(bill);
                    call.enqueue(new Callback<String>() {
                        @Override
                        public void onResponse(Call<String> call, Response<String> response) {
                            if(response.isSuccessful())
                            {
                                Log.i("Bill",response.body());
                                for(CartItemModel cart : mListItemCart)
                                {
                                    BillDetail billDetail = new BillDetail(BillId,cart.getBookId(),cart.getSoluong(),cart.getPrice(),cart.getSumPrice());
                                    Log.i("Bill",response.body());
                                    Call<String> callBillDetail = requestAPI.CreateBillDetail(billDetail);
                                    callBillDetail.enqueue(new Callback<String>() {
                                        @Override
                                        public void onResponse(Call<String> call, Response<String> response) {
                                            if(response.isSuccessful())
                                            {
                                                Log.i("TagBill",response.body());
                                                View view = findViewById(R.id.Cart_layout);
                                                ShowSnackBar(view,"Dat Hang Thanh Cong",Snackbar.LENGTH_LONG);
                                                mDB.cartBookDao().deleteAll();
                                                mListItemCart = (ArrayList<CartItemModel>) mDB.cartBookDao().findAllCartBookSync();
                                                cartAdapter.SetListCartBook(mListItemCart);
                                            }
                                        }

                                        @Override
                                        public void onFailure(Call<String> call, Throwable t) {
                                            Log.i("TagBill",t.getMessage());
                                        }
                                    });
                                }
                            }
                        }

                        @Override
                        public void onFailure(Call<String> call, Throwable t) {
                            Log.i("CreateBill",t.getMessage());
                        }
                    });
                }
            }
        });
        SetSumPrice();
        cartAdapter.setSumPriceOnClick(CartActivity.this);
    }

    public void ShowSnackBar(View view,String message,int duration)
    {
        Snackbar.make(view,message,duration).show();
    }

    private void init() {
        requestAPI = APIClient.getClient().create(RequestAPI.class);
        mDB = AppDatabase.BuilderDatabase(this);
        cartRecyclerView = findViewById(R.id.list_item_card);
        btnBack = findViewById(R.id.btnBack_cart);
        txtSumPrice = findViewById(R.id.txtSumPrice);
        btnBuy = findViewById(R.id.btn_buy);
    }

    private void GetData()
    {
        mListItemCart = (ArrayList<CartItemModel>) mDB.cartBookDao().findAllCartBookSync();
    }

    @SuppressLint({"DefaultLocale", "SetTextI18n"})
    public void SetSumPrice()
    {
        double sumPrice = cartAdapter.SetSumPrice();
        txtSumPrice.setText(String.format("%,.0f", sumPrice) + " đ");
    }

    @SuppressLint({"DefaultLocale", "SetTextI18n"})
    @Override
    public void onclick(double SumPrice) {
        txtSumPrice.setText(String.format("%,.0f", SumPrice) + " đ");
    }
}
