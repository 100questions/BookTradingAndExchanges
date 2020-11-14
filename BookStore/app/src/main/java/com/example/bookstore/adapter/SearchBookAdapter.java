package com.example.bookstore.adapter;

import android.annotation.SuppressLint;
import android.content.Context;
import android.text.TextUtils;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.bookstore.R;
import com.example.bookstore.model.CartItemModel;
import com.example.bookstore.model.Entity.Book;
import com.example.bookstore.room.database.AppDatabase;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class SearchBookAdapter extends RecyclerView.Adapter<SearchBookViewHolder> {
    Context context;
    ArrayList<Book> mCartList;
    Onclick SumPriceOnClick;

    public SearchBookAdapter(Context context, ArrayList<Book> mCartList) {
        this.context = context;
        this.mCartList = mCartList;
    }

    public void setSumPriceOnClick(Onclick sumPriceOnClick) {
        SumPriceOnClick = sumPriceOnClick;
    }

    public interface Onclick {
        void onclick();
    }

    public void SetListCartBook(ArrayList<Book> mCartList) {
        this.mCartList = mCartList;
        notifyDataSetChanged();
    }

    @NonNull
    @Override
    public SearchBookViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_search_book, parent, false);
        SearchBookViewHolder viewHolder = new SearchBookViewHolder(view);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull SearchBookViewHolder holder, int position) {
        holder.bind(mCartList.get(position));
    }

    @Override
    public int getItemCount() {
        return mCartList.size();
    }
}

class SearchBookViewHolder extends RecyclerView.ViewHolder {
    ImageView imgCartBook;
    TextView txtTitleBook;
    TextView txtPrice;

    public SearchBookViewHolder(@NonNull View view) {
        super(view);
        imgCartBook = view.findViewById(R.id.img_search_book);
        txtTitleBook = view.findViewById(R.id.title_search_book);
        txtPrice = view.findViewById(R.id.price_search_book);
    }

    @SuppressLint({"DefaultLocale", "SetTextI18n"})
    public void bind(final Book book) {
        if (TextUtils.isEmpty(book.getImageBook())) {
            Picasso.get().cancelRequest(imgCartBook);
            imgCartBook.setImageDrawable(null);
        } else {
            Picasso.get()
                    .load(book.getImageBook())
                    .resize(80, 100)
                    .placeholder(R.mipmap.ic_launcher)
                    .error(R.drawable.ic_error_red_24dp)
                    .into(imgCartBook);
        }
        txtTitleBook.setText(book.getBookName());
        txtPrice.setText(String.format("%,.0f", book.getPrice()) + "đ");
    }

}
