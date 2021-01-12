package com.example.bookstore.activity;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.ImageView;

import com.example.bookstore.R;
import com.example.bookstore.adapter.MangerBillAdapter;
import com.example.bookstore.adapter.RecyclerViewTouchListener;
import com.example.bookstore.adapter.SearchBookAdapter;
import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.model.Entity.Bill;
import com.example.bookstore.model.Entity.Book;
import com.example.bookstore.model.Entity.User;
import com.example.bookstore.room.database.AppDatabase;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class BillsManagerActivity extends AppCompatActivity {

    ImageView btnBillBack;
    RecyclerView rvManagerBill;
    RequestAPI requestAPI;
    MangerBillAdapter mangerBillAdapter;
    ArrayList<Bill> bills = new ArrayList<Bill>();
    private AppDatabase mDB;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bills_manager);
        init();
        getSupportActionBar().hide();
        LoadData();

        btnBillBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

        rvManagerBill.addOnItemTouchListener(new RecyclerViewTouchListener(this, rvManagerBill, new RecyclerViewTouchListener.ClickListener() {
            @Override
            public void onClick(View view, int position) {
                Intent intent = new Intent(BillsManagerActivity.this, BillDetailActivity.class);
                intent.putExtra("BillID", bills.get(position).mAHD);
                intent.putExtra("Price", bills.get(position).gettHANHTIEN());
                startActivity(intent);
            }

            @Override
            public void onLongClick(View view, int position) {

            }
        }));
    }

    private void LoadData() {
        User user = mDB.UseDao().getUser().get(0);
        Call<ArrayList<Bill>> call = requestAPI.GetListBill(user.getMaKH());
        call.enqueue(new Callback<ArrayList<Bill>>() {
            @Override
            public void onResponse(Call<ArrayList<Bill>> call, Response<ArrayList<Bill>> response) {
                if(response.isSuccessful()){
                    assert response.body() != null;
                    bills.addAll(response.body());
                    Log.i("bill",bills.toString());
                }
                mangerBillAdapter = new MangerBillAdapter(rvManagerBill.getContext(),bills);
                rvManagerBill.setAdapter(mangerBillAdapter);
                rvManagerBill.setLayoutManager(new LinearLayoutManager(rvManagerBill.getContext(), LinearLayoutManager.VERTICAL, false));
                mangerBillAdapter.notifyDataSetChanged();
            }

            @Override
            public void onFailure(Call<ArrayList<Bill>> call, Throwable t) {
                Log.i("bill","Bill = "+t.toString());
            }
        });
    }

    private void init()
    {
        btnBillBack = (ImageView) findViewById(R.id.btnBillBack);
        requestAPI = APIClient.getClient().create(RequestAPI.class);
        rvManagerBill = findViewById(R.id.rvManagerBill);
        mDB = AppDatabase.BuilderDatabase(this);
    }
}