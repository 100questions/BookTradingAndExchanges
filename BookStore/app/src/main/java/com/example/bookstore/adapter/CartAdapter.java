package com.example.bookstore.adapter;

import android.annotation.SuppressLint;
import android.content.Context;
import android.text.TextUtils;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.bookstore.activity.CartActivity;
import com.example.bookstore.model.CartItemModel;
import com.example.bookstore.R;
import com.example.bookstore.room.database.AppDatabase;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class CartAdapter extends RecyclerView.Adapter<CartAdapter.ViewHolder> {
    Context context;
    ArrayList<CartItemModel> mCartList;
    AppDatabase mDB;
    Onclick SumPriceOnClick;

    public void setSumPriceOnClick(Onclick sumPriceOnClick) {
        SumPriceOnClick = sumPriceOnClick;
    }

    public interface Onclick
    {
        void onclick(double SumPrice);
    }

    public CartAdapter(Context context, ArrayList<CartItemModel> mCartList) {
        this.context = context;
        this.mCartList = mCartList;
        mDB = AppDatabase.BuilderDatabase(context);
    }

    public void SetListCartBook(ArrayList<CartItemModel> mCartList) {
        this.mCartList = mCartList;
        notifyDataSetChanged();
    }

    public double SetSumPrice()
    {
        double sumPrice = 0;
        for (CartItemModel cart : mCartList) {
            sumPrice += cart.getSumPrice();
        }
        return  sumPrice;
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.cart_item, parent, false);
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

    public class ViewHolder extends RecyclerView.ViewHolder {
        ImageView imgCartBook;
        TextView txtTitleBook;
        TextView txtTitleSupplier;
        TextView txtPrice;
        TextView txtDisCount;
        ImageView btnReduction;
        ImageView btnIncrease;
        TextView txtAmount;
        ImageView btnDelete;

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
            btnDelete = view.findViewById(R.id.btn_delete_cart_book);
        }

        @SuppressLint({"DefaultLocale", "SetTextI18n"})
        public void bind(final CartItemModel cartItem) {
            if (TextUtils.isEmpty(cartItem.getImageBook())) {
                Picasso.get().cancelRequest(imgCartBook);
                imgCartBook.setImageDrawable(null);
            } else {
                Picasso.get()
                        .load(cartItem.getImageBook())
                        .resize(80, 100)
                        .placeholder(R.mipmap.ic_launcher)
                        .error(R.drawable.ic_error_red_24dp)
                        .into(imgCartBook);
            }
            txtTitleBook.setText(cartItem.getBookName());
            txtPrice.setText(String.format("%,.0f", cartItem.getSumPrice()) + "đ");
            txtDisCount.setText(String.format("%,.0f", cartItem.getSumPrice()*1.4) + "đ");
            txtAmount.setText(String.valueOf(cartItem.getSoluong()));

            btnReduction.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    int amount = cartItem.getSoluong();
                    if (amount > 1)
                        amount--;
                    cartItem.setSoluong(amount);
                    txtAmount.setText(String.valueOf(amount));
                    mDB.cartBookDao().UpdateCartBook(cartItem);
                    SetListCartBook((ArrayList<CartItemModel>) mDB.cartBookDao().findAllCartBookSync());
                    double TotalPrice = 0;
                    for(CartItemModel cart : mCartList)
                    {
                        TotalPrice += cart.getSumPrice();
                    }
                    SumPriceOnClick.onclick(TotalPrice);
                }
            });

            btnIncrease.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    int amount = cartItem.getSoluong();
                    amount++;
                    cartItem.setSoluong(amount);
                    txtAmount.setText(String.valueOf(amount));
                    mDB.cartBookDao().UpdateCartBook(cartItem);
                    SetListCartBook((ArrayList<CartItemModel>) mDB.cartBookDao().findAllCartBookSync());
                    double TotalPrice = 0;
                    for(CartItemModel cart : mCartList)
                    {
                        TotalPrice += cart.getSumPrice();
                    }
                    SumPriceOnClick.onclick(TotalPrice);
                }
            });

            btnDelete.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    mDB.cartBookDao().DeleteCartBook(cartItem.getBookId());
                    SetListCartBook((ArrayList<CartItemModel>) mDB.cartBookDao().findAllCartBookSync());
                    double TotalPrice = 0;
                    for(CartItemModel cart : mCartList)
                    {
                        TotalPrice += cart.getSumPrice();
                    }
                    SumPriceOnClick.onclick(TotalPrice);
                }
            });
        }
    }
}
