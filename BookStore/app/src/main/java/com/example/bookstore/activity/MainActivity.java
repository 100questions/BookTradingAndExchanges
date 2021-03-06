package com.example.bookstore.activity;

import androidx.annotation.NonNull;

import com.example.bookstore.R;
import com.example.bookstore.room.database.AppDatabase;
import com.google.android.material.bottomnavigation.BottomNavigationView;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.view.MenuItem;

import com.example.bookstore.fragment.AccountFragment;
import com.example.bookstore.fragment.DashBoardFragment;
import com.example.bookstore.fragment.HomeFragment;
import com.example.bookstore.fragment.NotificationFragment;

public class MainActivity extends AppCompatActivity {

    BottomNavigationView navView;
    boolean status = false;
    MenuItem mItem;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        SharedPreferences sharedPreferences = getSharedPreferences("Logged",MODE_PRIVATE);
        navView = findViewById(R.id.nav_view);
        getSupportActionBar().hide();
        Intent intent = getIntent();
        boolean isLogged = intent.getBooleanExtra("IsLogged",false);

        if(isLogged)
        {
            LoadFragment(new AccountFragment());
            navView.setSelectedItemId(R.id.account_navigation);
            getSupportActionBar().show();
        }
        else {
            LoadFragment(new HomeFragment());
        }

        navView.setOnNavigationItemSelectedListener(new BottomNavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem menuItem) {
                Fragment fragment;
                switch (menuItem.getItemId())
                {
                    case R.id.home_navigation:
                        getSupportActionBar().hide();
                        fragment = new HomeFragment();
                        LoadFragment(fragment);
                        return true;
                    case R.id.dashboard_navigation:
                        getSupportActionBar().show();
                        getSupportActionBar().setTitle("DashBoard");
                        fragment = new DashBoardFragment();
                        LoadFragment(fragment);
                        return true;
                    case R.id.notification_navigation:
                        getSupportActionBar().show();
                        getSupportActionBar().setTitle("Notification");
                        fragment = new NotificationFragment();
                        LoadFragment(fragment);
                        return true;
                    case R.id.account_navigation:
                        getSupportActionBar().show();
                        getSupportActionBar().setTitle("Account");
                        fragment = new AccountFragment();
                        LoadFragment(fragment);
                        return true;
                }
                return false;
            }
        });
    }

    private void LoadFragment(Fragment fragment)
    {
        FragmentTransaction transaction = getSupportFragmentManager().beginTransaction();
        transaction.replace(R.id.nav_host_fragment, fragment);
        transaction.addToBackStack(null);
        transaction.commit();
    }
}
