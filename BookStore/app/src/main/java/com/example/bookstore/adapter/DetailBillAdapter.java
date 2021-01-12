package com.example.bookstore.adapter;

import android.annotation.SuppressLint;
import android.content.Context;
import android.text.TextUtils;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.bookstore.R;
import com.example.bookstore.model.Entity.Bill;
import com.example.bookstore.model.Entity.BookRep;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class DetailBillAdapter extends RecyclerView.Adapter<DetailBillViewHolder> {
    Context context;
    ArrayList<BookRep> bookReps;

    public DetailBillAdapter(Context context, ArrayList<BookRep> bookReps) {
        this.context = context;
        this.bookReps = bookReps;
    }

    public interface Onclick {
        void onclick();
    }

    public void SetListCartBook(ArrayList<BookRep> bookReps) {
        this.bookReps = bookReps;
        notifyDataSetChanged();
    }

    @NonNull
    @Override
    public DetailBillViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_detail_bill, parent, false);
        DetailBillViewHolder viewHolder = new DetailBillViewHolder(view);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull DetailBillViewHolder holder, int position) {
        holder.bind(bookReps.get(position));
    }


    @Override
    public int getItemCount() {
        return bookReps != null ? bookReps.size() : 0;
    }
}

class DetailBillViewHolder extends RecyclerView.ViewHolder {
    TextView tvTitleBook,tvPriceBook,tvAmount;
    ImageView imgBook;
    Button btnReBuy;

    public DetailBillViewHolder(@NonNull View view) {
        super(view);
        tvTitleBook = view.findViewById(R.id.titleBillDetailBook);
        imgBook = view.findViewById(R.id.imgBillDetailBook);
        tvAmount = view.findViewById(R.id.amountBillDetailBook);
        tvPriceBook = view.findViewById(R.id.priceBillDetailBook);
    }

    @SuppressLint({"DefaultLocale", "SetTextI18n"})
    public void bind(final BookRep books) {
        tvTitleBook.setText(books.getBookName());
        tvAmount.setText("x" + books.getNumberOrder());
        tvPriceBook.setText(String.valueOf(books.getPrice()));

        if (TextUtils.isEmpty(books.getImageBook())) {
            Picasso.get().cancelRequest(imgBook);
            imgBook.setImageDrawable(null);
        } else {
            Picasso.get()
                    .load(books.getImageBook())
                    .resize(80, 100)
                    .placeholder(R.mipmap.ic_launcher)
                    .error(R.drawable.ic_error_red_24dp)
                    .into(imgBook);
        }
    }

}
