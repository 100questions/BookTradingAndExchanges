package com.example.bookstore.activity;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.SearchView;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;

import com.example.bookstore.R;
import com.example.bookstore.adapter.RecyclerViewTouchListener;
import com.example.bookstore.adapter.SearchBookAdapter;
import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.model.Entity.Book;
import com.example.bookstore.model.Entity.User;
import com.example.bookstore.room.database.AppDatabase;
import com.google.android.material.chip.ChipGroup;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ProductHasBeenBought extends AppCompatActivity {

    ImageView btnProductBoughtBack;
    RecyclerView rcvProductBought;
    RequestAPI requestAPI;
    SearchBookAdapter searchBookAdapter;
    ArrayList<Book> books = new ArrayList<Book>();
    private AppDatabase mDB;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_product_has_been_bought);
        init();
        getSupportActionBar().hide();
        LoadData();

        btnProductBoughtBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });

        rcvProductBought.addOnItemTouchListener(new RecyclerViewTouchListener(this, rcvProductBought, new RecyclerViewTouchListener.ClickListener() {
            @Override
            public void onClick(View view, int position) {
                Intent intent = new Intent(ProductHasBeenBought.this, DetailProductActivity.class);
                intent.putExtra("BookDetail", books.get(position));
                startActivity(intent);
            }

            @Override
            public void onLongClick(View view, int position) {

            }
        }));
    }

    private void LoadData() {
        User user = mDB.UseDao().getUser().get(0);
        Call<ArrayList<Book>> call = requestAPI.getListBook(user.getMaKH());
        call.enqueue(new Callback<ArrayList<Book>>() {
            @Override
            public void onResponse(Call<ArrayList<Book>> call, Response<ArrayList<Book>> response) {
                if(response.isSuccessful()){
                    assert response.body() != null;
                    books.addAll(response.body());
                }
                searchBookAdapter = new SearchBookAdapter(rcvProductBought.getContext(),books);
                rcvProductBought.setAdapter(searchBookAdapter);
                rcvProductBought.setLayoutManager(new LinearLayoutManager(rcvProductBought.getContext(), LinearLayoutManager.VERTICAL, false));
                searchBookAdapter.notifyDataSetChanged();
            }

            @Override
            public void onFailure(Call<ArrayList<Book>> call, Throwable t) {
                Log.d("TAG","Book = "+t.toString());
            }
        });
    }

    private void init()
    {
        btnProductBoughtBack = (ImageView) findViewById(R.id.btnProductBoughtBack);
        requestAPI = APIClient.getClient().create(RequestAPI.class);
        rcvProductBought = findViewById(R.id.rcvProductBought);
        mDB = AppDatabase.BuilderDatabase(this);
    }
}