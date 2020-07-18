package com.example.bookstore.adapter;

import android.content.Context;
import androidx.annotation.NonNull;
import androidx.viewpager.widget.PagerAdapter;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import com.example.bookstore.model.ItemSlider;
import com.example.bookstore.R;

import java.util.List;

public class SliderViewPagerAdapter extends PagerAdapter {
    Context mContext ;
    List<ItemSlider> mListItemSliders;

    public SliderViewPagerAdapter(Context mContext, List<ItemSlider> itemSliders) {
        this.mContext = mContext;
        this.mListItemSliders = itemSliders;
    }


    @NonNull
    @Override
    public Object instantiateItem(@NonNull ViewGroup container, int position) {
        //LayoutInflater inflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View layoutScreen = LayoutInflater.from(mContext).inflate(R.layout.slider_screen,null);

        //init variable
        ImageView imgSlide = layoutScreen.findViewById(R.id.slider_img);
        //
        imgSlide.setImageResource(mListItemSliders.get(position).getImageSlider());

        container.addView(layoutScreen);

        return layoutScreen;
    }

    @Override
    public int getCount() {
        return mListItemSliders.size();
    }

    @Override
    public boolean isViewFromObject(@NonNull View view, @NonNull Object o) {
        return view == o;
    }

    @Override
    public void destroyItem(@NonNull ViewGroup container, int position, @NonNull Object object) {

        container.removeView((View)object);

    }
}
