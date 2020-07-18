package com.example.bookstore.adapter;

import android.content.Context;
import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.bookstore.model.Entity.Category;
import com.example.bookstore.R;

import java.util.ArrayList;

public class CategoryHomeAdapter extends RecyclerView.Adapter<CategoryHomeAdapter.ViewHolder> {
    private ArrayList<Category> mCategories;
    private Context context;

    public CategoryHomeAdapter(ArrayList<Category> mCategories, Context context) {
        this.mCategories = mCategories;
        this.context = context;
    }

    public void setCategoriesList(ArrayList<Category> movieList) {
        this.mCategories = movieList;
        notifyDataSetChanged();
    }


    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        View itemView = LayoutInflater.from(viewGroup.getContext()).inflate(R.layout.category_item,viewGroup,false);
        ViewHolder viewHolder = new ViewHolder(itemView);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder viewHolder, int i) {
        Category category = mCategories.get(i);
        viewHolder.imgViewCategory.setImageResource(R.drawable.book_icon_pack);
        viewHolder.txtCategoryName.setText(category.getTenLoai());
    }

    @Override
    public int getItemCount() {
        if(mCategories != null) {
            return mCategories.size();
        }
        return 0;
    }

    public class ViewHolder extends RecyclerView.ViewHolder{
        ImageView imgViewCategory;
        TextView txtCategoryName;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            imgViewCategory = itemView.findViewById(R.id.category_img);
            txtCategoryName = itemView.findViewById(R.id.category_title);
        }
    }
}

