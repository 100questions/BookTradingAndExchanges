package com.example.bookstore.activity;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;

import com.example.bookstore.adapter.CartAdapter;
import com.example.bookstore.model.CartItemModel;
import com.example.bookstore.R;

import java.util.ArrayList;

import jp.wasabeef.recyclerview.animators.SlideInDownAnimator;

public class CartActivity extends AppCompatActivity {
    RecyclerView cartRecyclerView;
    CartAdapter cartAdapter;
    ArrayList<CartItemModel> mListItemCart;
    ImageView btnBack;

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
    }

    private void init() {
        cartRecyclerView = findViewById(R.id.list_item_card);
        btnBack = findViewById(R.id.btnBack_cart);
    }

    private void GetData()
    {
        mListItemCart.add(new CartItemModel("Đắc Nhân Tâm",20000,R.drawable.img1,1));
        mListItemCart.add(new CartItemModel("Đắc Nhân Tâm",20000,R.drawable.img1,1));
        mListItemCart.add(new CartItemModel("Đắc Nhân Tâm",20000,R.drawable.img1,1));
        mListItemCart.add(new CartItemModel("Đắc Nhân Tâm",20000,R.drawable.img1,1));
    }
}
