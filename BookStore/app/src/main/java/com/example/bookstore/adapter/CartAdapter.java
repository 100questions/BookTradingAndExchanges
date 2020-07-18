package com.example.bookstore.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.bookstore.model.CartItemModel;
import com.example.bookstore.R;

import java.util.ArrayList;

public class CartAdapter extends RecyclerView.Adapter<CartAdapter.ViewHolder> {
    Context context;
    ArrayList<CartItemModel> mCartList;

    public CartAdapter(Context context, ArrayList<CartItemModel> mCartList) {
        this.context = context;
        this.mCartList = mCartList;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.cart_item,parent,false);
        ViewHolder viewHolder = new ViewHolder(view);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull final ViewHolder holder, int position) {
        final CartItemModel cartItem = mCartList.get(position);
        holder.bind(cartItem);
    }

    @Override
    public int getItemCount() {
        return mCartList.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder
    {
        ImageView imgCartBook;
        TextView txtTitleBook;
        TextView txtTitleSupplier;
        TextView txtPrice;
        TextView txtDisCount;
        ImageView btnReduction;
        ImageView btnIncrease;
        TextView txtAmount;
        public ViewHolder(@NonNull View view) {
            super(view);
            imgCartBook = view.findViewById(R.id.img_cart_book);
            txtTitleBook = view.findViewById(R.id.title_cart_book);
            txtTitleSupplier = view.findViewById(R.id.title_Supplier);
            txtPrice = view.findViewById(R.id.price_book_cart);
            txtDisCount = view.findViewById(R.id.price_book_discount_cart);
            btnReduction = view.findViewById(R.id.btn_reduction);
            btnIncrease = view.findViewById(R.id.btn_increase);
            txtAmount = view.findViewById(R.id.txt_amount);

        }

        public void bind(final CartItemModel cartItem){
            imgCartBook.setImageResource(cartItem.getImgProduct());
            txtTitleBook.setText(cartItem.getProductName());
            txtPrice.setText(String.valueOf(cartItem.getPrice()) + "đ");
            txtDisCount.setText(String.valueOf(cartItem.getPrice() * 1.4));
            txtAmount.setText(String.valueOf(cartItem.getSoluong()));

            btnReduction.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                int amount = cartItem.getSoluong();
                if(amount > 1)
                    amount--;
                cartItem.setSoluong(amount);
                txtAmount.setText(String.valueOf(amount));
            }
            });

            btnIncrease.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                int amount = cartItem.getSoluong();
                amount++;
                cartItem.setSoluong(amount);
                txtAmount.setText(String.valueOf(amount));
            }
            });
        }
    }
}
