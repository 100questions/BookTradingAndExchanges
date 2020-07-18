package com.example.bookstore.fragment;

import android.content.Intent;
import android.os.Bundle;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.activity.CartActivity;
import com.example.bookstore.activity.DetailProductActivity;
import com.example.bookstore.activity.ProductOfDashBoardActivity;
import com.example.bookstore.adapter.RecyclerViewTouchListener;
import com.example.bookstore.model.Entity.Book;
import com.google.android.material.appbar.AppBarLayout;
import com.google.android.material.tabs.TabLayout;
import androidx.fragment.app.Fragment;
import androidx.viewpager.widget.ViewPager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import androidx.recyclerview.widget.StaggeredGridLayoutManager;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.ImageView;

import com.example.bookstore.activity.SearchProductActivity;
import com.example.bookstore.adapter.CategoryHomeAdapter;
import com.example.bookstore.adapter.ProductAdapter;
import com.example.bookstore.adapter.ProductTodayAdapter;
import com.example.bookstore.adapter.SliderViewPagerAdapter;
import com.example.bookstore.model.Entity.Category;
import com.example.bookstore.model.ItemSlider;
import com.example.bookstore.R;

import java.util.ArrayList;

import jp.wasabeef.recyclerview.animators.SlideInUpAnimator;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * A simple {@link Fragment} subclass.
 */
public class HomeFragment extends Fragment {

    private ViewPager  SliderViewPager;
    SliderViewPagerAdapter sliderViewPagerAdapter ;
    TabLayout tabSlider;
    ArrayList<ItemSlider> mListItemSlider;
    EditText edtSearch;
    RecyclerView CategoryRecyclerView;
    RecyclerView productTodayRecyclerView;
    RecyclerView productRecyclerView;
    CategoryHomeAdapter categoryHomeAdapter;
    ProductAdapter productAdapter;
    ProductTodayAdapter productTodayAdapter;
    ArrayList<Category> categories;
    ArrayList<Book> products;
    ArrayList<Book> listProduct;
    ImageView btnCart;

    RequestAPI requestAPI;

    public HomeFragment() {
        // Required empty public constructor
    }

    private void init(View view)
    {
        btnCart = view.findViewById(R.id.btn_cart);
        edtSearch = (EditText) view.findViewById(R.id.edt_Search);
        CategoryRecyclerView = view.findViewById(R.id.list_category_home);
        productRecyclerView = view.findViewById(R.id.list_product_hot);
        productTodayRecyclerView = view.findViewById(R.id.list_product);
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_home, container, false);

    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        setHasOptionsMenu(true);
        init(view);
        requestAPI = APIClient.getClient().create(RequestAPI.class);

        AppBarLayout mAppBarLayout = (AppBarLayout) view.findViewById(R.id.home_appbar);
        mAppBarLayout.addOnOffsetChangedListener(new AppBarLayout.OnOffsetChangedListener() {
            boolean isShow = false;
            int scrollRange = -1;

            @Override
            public void onOffsetChanged(AppBarLayout appBarLayout, int verticalOffset) {
                if (scrollRange == -1) {
                    scrollRange = appBarLayout.getTotalScrollRange();
                }
                if (scrollRange + verticalOffset == 0) {
                    isShow = true;
                    edtSearch.setMaxWidth(edtSearch.getMaxWidth() - 100);
                } else if (isShow) {
                    isShow = false;
                    edtSearch.setMaxWidth(edtSearch.getMaxWidth() + 100);
                }
            }
        });
        //slider
//        SliderViewPager = view.findViewById(R.id.slider_viewpager);
//        tabSlider = view.findViewById(R.id.tab_slider);
//        mListItemSlider = new ArrayList<ItemSlider>();
////        mListItemSlider.add(new ItemSlider(R.drawable.img1));
////        mListItemSlider.add(new ItemSlider(R.drawable.img2));
////        mListItemSlider.add(new ItemSlider(R.drawable.img3));
////
////        sliderViewPagerAdapter = new SliderViewPagerAdapter(getContext(),mListItemSlider);
////        SliderViewPager.setAdapter(sliderViewPagerAdapter);
////        tabSlider.setupWithViewPager(SliderViewPager);

        edtSearch.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(getContext(), SearchProductActivity.class);
                startActivity(intent);
            }
        });

        //category
        GetDataCategories();
        categoryHomeAdapter = new CategoryHomeAdapter(categories,requireContext());
        CategoryRecyclerView.setAdapter(categoryHomeAdapter);
        CategoryRecyclerView.setHasFixedSize(true);
        CategoryRecyclerView.setLayoutManager(new LinearLayoutManager(requireContext(), LinearLayoutManager.HORIZONTAL, false));
        categoryHomeAdapter.notifyDataSetChanged();


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

        //Product RecyclerView
//        products = new ArrayList<Product>();
//        products.add(new Product("Đắc Nhân Tâm",20000,R.drawable.img1));
//        products.add(new Product("Con mèo dạy hải âu bay",20000,R.drawable.img2));
//        products.add(new Product("Giới hạn của bạn là xuất phát điểm của tôi",20000,R.drawable.img3));
        GetDataProduct();
        productAdapter = new ProductAdapter(products,requireContext());
        productRecyclerView.setAdapter(productAdapter);

        productRecyclerView.setItemAnimator(new SlideInUpAnimator());
        productRecyclerView.setLayoutManager(new LinearLayoutManager(requireContext(), RecyclerView.HORIZONTAL,false));
        productAdapter.notifyDataSetChanged();

        productRecyclerView.addOnItemTouchListener(new RecyclerViewTouchListener(requireContext(), productRecyclerView, new RecyclerViewTouchListener.ClickListener() {
            @Override
            public void onClick(View view, int position) {
                Intent intent = new Intent(requireContext(), DetailProductActivity.class);
                intent.putExtra("BookDetail", products.get(position));
                startActivity(intent);
            }

            @Override
            public void onLongClick(View view, int position) {

            }
        }));

        //product to day

        productTodayAdapter = new ProductTodayAdapter(listProduct,requireContext());
        productTodayRecyclerView.setAdapter(productTodayAdapter);
        productTodayRecyclerView.setItemAnimator(new SlideInUpAnimator());

        productTodayRecyclerView.setLayoutManager(new StaggeredGridLayoutManager(2, StaggeredGridLayoutManager.VERTICAL));
        productTodayAdapter.notifyDataSetChanged();

        productTodayRecyclerView.addOnItemTouchListener(new RecyclerViewTouchListener(requireContext(), productTodayRecyclerView, new RecyclerViewTouchListener.ClickListener() {
            @Override
            public void onClick(View view, int position) {
                Intent intent = new Intent(requireContext(), DetailProductActivity.class);
                intent.putExtra("BookDetail", products.get(position));
                startActivity(intent);
            }

            @Override
            public void onLongClick(View view, int position) {

            }
        }));

        btnCart.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(requireContext(), CartActivity.class);
                startActivity(intent);
            }
        });

    }

    private void GetDataCategories() {
        Call<ArrayList<Category>> call = requestAPI.getCategory();
        call.enqueue(new Callback<ArrayList<Category>>() {
            @Override
            public void onResponse(Call<ArrayList<Category>> call, Response<ArrayList<Category>> response) {
                categories = response.body();
                categoryHomeAdapter.setCategoriesList(categories);
                Log.d("TAG","Response = ");
            }

            @Override
            public void onFailure(Call<ArrayList<Category>> call, Throwable t) {
                Log.d("TAG","Response = "+t.toString());
            }
        });
    }

    private void GetDataProduct()
    {
        Call<ArrayList<Book>> call = requestAPI.getAllBook();
        call.enqueue(new Callback<ArrayList<Book>>() {
            @Override
            public void onResponse(Call<ArrayList<Book>> call, Response<ArrayList<Book>> response) {
                if(response.isSuccessful())
                {
                    listProduct = response.body();
                    productTodayAdapter.SetBookList(listProduct);
                    products = listProduct;
                    productAdapter.SetBookList(products);
                }
            }

            @Override
            public void onFailure(Call<ArrayList<Book>> call, Throwable t) {
                Log.d("TAG","Book = "+t.toString());
            }
        });
    }
}
