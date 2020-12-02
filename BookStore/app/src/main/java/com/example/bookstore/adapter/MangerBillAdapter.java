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
import com.example.bookstore.model.Entity.Book;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;

public class MangerBillAdapter extends RecyclerView.Adapter<BillViewHolder> {
    Context context;
    ArrayList<Bill> bills;
    SearchBookAdapter.Onclick SumPriceOnClick;

    public MangerBillAdapter(Context context, ArrayList<Bill> bills) {
        this.context = context;
        this.bills = bills;
    }

    public void setSumPriceOnClick(SearchBookAdapter.Onclick sumPriceOnClick) {
        SumPriceOnClick = sumPriceOnClick;
    }

    public interface Onclick {
        void onclick();
    }

    public void SetListCartBook(ArrayList<Bill> bills) {
        this.bills = bills;
        notifyDataSetChanged();
    }

    @NonNull
    @Override
    public BillViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.bill_item_layout, parent, false);
        BillViewHolder viewHolder = new BillViewHolder(view);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull BillViewHolder holder, int position) {
        holder.bind(bills.get(position));
    }

    @Override
    public int getItemCount() {
        return bills != null ? bills.size() : 0;
    }
}

class BillViewHolder extends RecyclerView.ViewHolder {
    TextView tvID,tvDate,tvPrice,tvState;
    Button btnReBuy;

    public BillViewHolder(@NonNull View view) {
        super(view);
        tvID = view.findViewById(R.id.tvBillID);
        tvDate = view.findViewById(R.id.tvDate);
        tvPrice = view.findViewById(R.id.tvPrice);
        tvState = view.findViewById(R.id.tvState);
    }

    @SuppressLint({"DefaultLocale", "SetTextI18n"})
    public void bind(final Bill bill) {
        tvID.setText(bill.getmAHD());
        tvDate.setText(bill.getnGAYLAPHD());
        tvPrice.setText(bill.gettHANHTIEN().toString());
        tvState.setText(bill.gettRANGTHAI());
    }

}
