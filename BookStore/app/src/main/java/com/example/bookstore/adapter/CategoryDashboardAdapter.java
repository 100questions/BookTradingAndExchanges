package com.example.bookstore.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.bookstore.model.Entity.Category;
import com.example.bookstore.R;

import java.util.ArrayList;

public class CategoryDashboardAdapter extends RecyclerView.Adapter<CategoryDashboardAdapter.ViewHolder> {

    private ArrayList<Category> mCategories;
    private Context context;

    public CategoryDashboardAdapter(ArrayList<Category> mCategories, Context context) {
        this.mCategories = mCategories;
        this.context = context;
    }

    public void setCategoriesList(ArrayList<Category> categoriesList)
    {
        this.mCategories = categoriesList;
        notifyDataSetChanged();
    }

    @NonNull
    @Override
    public ViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        View itemView = LayoutInflater.from(viewGroup.getContext()).inflate(R.layout.category_item_dashboard,viewGroup,false);
        ViewHolder viewHolder = new ViewHolder(itemView);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull ViewHolder holder, int position) {
        Category category = mCategories.get(position);
        holder.imgViewCategory.setImageResource(R.drawable.img1);
        holder.txtCategoryName.setText(category.getTenLoai());
    }


    @Override
    public int getItemCount() {
        if(mCategories == null)
        {
            return 0;
        }
        return mCategories.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder{
        ImageView imgViewCategory;
        TextView txtCategoryName;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            imgViewCategory = itemView.findViewById(R.id.category_img_dashboard);
            txtCategoryName = itemView.findViewById(R.id.category_title_dashboard);
        }
    }
}
