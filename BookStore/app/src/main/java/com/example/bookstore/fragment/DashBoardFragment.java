package com.example.bookstore.fragment;

import android.content.Intent;
import android.os.Bundle;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.activity.ProductOfDashBoardActivity;
import com.example.bookstore.adapter.CategoryDashboardAdapter;
import com.example.bookstore.adapter.RecyclerViewTouchListener;
import com.example.bookstore.model.Entity.Category;
import com.example.bookstore.R;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * A simple {@link Fragment} subclass.
 */
public class DashBoardFragment extends Fragment {

    RecyclerView CategoryRecyclerView;
    ArrayList<Category> categories;
    CategoryDashboardAdapter categoryDashboardAdapter;
    RequestAPI requestAPI;

    public DashBoardFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_dash_board, container, false);

    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        requestAPI = APIClient.getClient().create(RequestAPI.class);

        CategoryRecyclerView = view.findViewById(R.id.list_category_dashboard);

        GetDataCategories();
        categoryDashboardAdapter = new CategoryDashboardAdapter(categories,requireContext());
        CategoryRecyclerView.setAdapter(categoryDashboardAdapter);
        CategoryRecyclerView.setHasFixedSize(true);

        CategoryRecyclerView.setLayoutManager(new GridLayoutManager(requireContext(),2));
        categoryDashboardAdapter.notifyDataSetChanged();

        CategoryRecyclerView.addOnItemTouchListener(new RecyclerViewTouchListener(requireContext(), CategoryRecyclerView, new RecyclerViewTouchListener.ClickListener() {
            @Override
            public void onClick(View view, int position) {
                Intent intent = new Intent(requireContext(), ProductOfDashBoardActivity.class);
                Bundle bundle = new Bundle();
                Category category = categories.get(position);
                bundle.putString("categoryID",category.getMaLoai());
                bundle.putString("categoryName",category.getTenLoai());
                intent.putExtras(bundle);
                startActivity(intent);
            }

            @Override
            public void onLongClick(View view, int position) {

            }
        }));
    }

    private void GetDataCategories() {
        Call<ArrayList<Category>> call = requestAPI.getCategory();
        call.enqueue(new Callback<ArrayList<Category>>() {
            @Override
            public void onResponse(Call<ArrayList<Category>> call, Response<ArrayList<Category>> response) {
                categories = response.body();
                categoryDashboardAdapter.setCategoriesList(categories);
            }

            @Override
            public void onFailure(Call<ArrayList<Category>> call, Throwable t) {
                Log.d("TAG","ResponseCategory = "+t.toString());
            }
        });
    }
}
