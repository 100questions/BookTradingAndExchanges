package com.example.bookstore.activity;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.viewpager.widget.ViewPager;

import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;

import com.example.bookstore.adapter.PagerAdapter;
import com.example.bookstore.R;
import com.google.android.material.tabs.TabLayout;

import java.util.Objects;

public class LoginRegisterActivity extends AppCompatActivity {
    Toolbar toolbar;
    TabLayout tabLayout;
    ImageView btnBack;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_register);
        Objects.requireNonNull(getSupportActionBar()).hide();
        init();

        tabLayout.addTab(tabLayout.newTab().setText("Đăng Nhập"));
        tabLayout.addTab(tabLayout.newTab().setText("Đăng Kí"));

        tabLayout.setTabGravity(TabLayout.GRAVITY_FILL);
        final ViewPager viewPager = (ViewPager) findViewById(R.id.viewPager_login);
        final PagerAdapter adapter = new PagerAdapter(getSupportFragmentManager(), tabLayout.getTabCount());
        viewPager.setAdapter(adapter);
        viewPager.addOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(tabLayout));

        tabLayout.setOnTabSelectedListener(new TabLayout.OnTabSelectedListener() {
            @Override
            public void onTabSelected(TabLayout.Tab tab) {
                viewPager.setCurrentItem(tab.getPosition());
            }
            @Override
            public void onTabUnselected(TabLayout.Tab tab) {
            }
            @Override
            public void onTabReselected(TabLayout.Tab tab) {
            }
        });

        btnBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });

    }

    private void init()
    {
        tabLayout = (TabLayout) findViewById(R.id.tab_layout_login);
        btnBack = (ImageView) findViewById(R.id.btnBack);
        //toolbar = findViewById(R.id.toolbar_login);
    }
}
