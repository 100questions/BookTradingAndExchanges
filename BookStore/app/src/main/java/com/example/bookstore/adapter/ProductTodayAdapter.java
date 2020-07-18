package com.example.bookstore.adapter;

import android.annotation.SuppressLint;
import android.content.Context;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.bookstore.model.Entity.Book;
import com.example.bookstore.R;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class ProductTodayAdapter extends RecyclerView.Adapter<ProductTodayAdapter.ViewHolder> {

    ArrayList<Book> mProduct;
    Context context;

    public ProductTodayAdapter(ArrayList<Book> mProduct, Context context) {
        this.mProduct = mProduct;
        this.context = context;
    }

    public void SetBookList(ArrayList<Book> books) {
        this.mProduct = books;
        notifyDataSetChanged();
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        View view = LayoutInflater.from(viewGroup.getContext()).inflate(R.layout.product_item, viewGroup, false);
        ViewHolder viewHolder = new ViewHolder(view);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder viewHolder, int i) {
        Book productItem = mProduct.get(i);
        viewHolder.Bind(productItem);
    }

    @Override
    public int getItemCount() {
        if (mProduct != null) {
            return mProduct.size();
        } else
            return 0;
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        ImageView imgProduct;
        TextView txtProductName;
        TextView txtProductPrice;

        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            imgProduct = itemView.findViewById(R.id.img_product_today);
            txtProductName = itemView.findViewById(R.id.product_title_today);
            txtProductPrice = itemView.findViewById(R.id.product_price_today);
        }

        @SuppressLint("DefaultLocale")
        public void Bind(final Book book) {
            if (TextUtils.isEmpty(book.getImageBook())) {
                Picasso.get().cancelRequest(imgProduct);
                imgProduct.setImageDrawable(null);
            } else {
                Picasso.get()
                        .load(book.getImageBook())
                        .resize(80, 100)
                        .placeholder(R.mipmap.ic_launcher)
                        .error(R.drawable.ic_error_red_24dp)
                        .into(imgProduct);
            }
            txtProductName.setText(book.getBookName());
            txtProductPrice.setText(String.format("%,.0f", book.getPrice()));

        }
    }
}
