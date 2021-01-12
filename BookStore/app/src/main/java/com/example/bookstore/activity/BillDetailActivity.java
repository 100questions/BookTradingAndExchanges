package com.example.bookstore.activity;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.bookstore.R;
import com.example.bookstore.adapter.DetailBillAdapter;
import com.example.bookstore.adapter.MangerBillAdapter;
import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.model.Entity.Bill;
import com.example.bookstore.model.Entity.BookRep;
import com.example.bookstore.model.Entity.User;
import com.example.bookstore.room.database.AppDatabase;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class BillDetailActivity extends AppCompatActivity {

    ImageView btnBillDetailBack;
    RecyclerView rcvBillDetail;
    RequestAPI requestAPI;
    DetailBillAdapter detailBillAdapter;
    ArrayList<BookRep> bookReps = new ArrayList<BookRep>();
    private AppDatabase mDB;
    String billID = "";
    TextView sumPriceBillDetail;

    @SuppressLint({"DefaultLocale", "SetTextI18n"})
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bill_detail);
        init();
        billID = getIntent().getStringExtra("BillID");
        double price = getIntent().getDoubleExtra("Price",0);
        sumPriceBillDetail.setText(String.format("%,.0f", price) + " đ");

        getSupportActionBar().hide();
        LoadData();
        btnBillDetailBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

    }

    private void LoadData() {
        if(!billID.isEmpty()){
            Call<ArrayList<BookRep>> call = requestAPI.getListBookByBillID(billID);
            call.enqueue(new Callback<ArrayList<BookRep>>() {
                @Override
                public void onResponse(Call<ArrayList<BookRep>> call, Response<ArrayList<BookRep>> response) {
                    if(response.isSuccessful()){
                        if(response.isSuccessful()){
                            assert response.body() != null;
                            bookReps.addAll(response.body());
                            Log.i("detailBook",bookReps.toString());
                        }
                        detailBillAdapter = new DetailBillAdapter(rcvBillDetail.getContext(),bookReps);
                        rcvBillDetail.setAdapter(detailBillAdapter);
                        rcvBillDetail.setLayoutManager(new LinearLayoutManager(rcvBillDetail.getContext(), LinearLayoutManager.VERTICAL, false));
                        detailBillAdapter.notifyDataSetChanged();
                    }
                }

                @Override
                public void onFailure(Call<ArrayList<BookRep>> call, Throwable t) {
                    Log.i("detailBook", t.getMessage());
                }
            });
        }
    }

    private void init()
    {
        sumPriceBillDetail = findViewById(R.id.sumPriceBillDetail);
        btnBillDetailBack = (ImageView) findViewById(R.id.btnBillDetailBack);
        requestAPI = APIClient.getClient().create(RequestAPI.class);
        rcvBillDetail = findViewById(R.id.rcvBillDetail);
        mDB = AppDatabase.BuilderDatabase(this);
    }
}