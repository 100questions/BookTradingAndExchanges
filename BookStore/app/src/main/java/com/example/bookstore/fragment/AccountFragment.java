package com.example.bookstore.fragment;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import com.example.bookstore.activity.BillsManagerActivity;
import com.example.bookstore.activity.LoginRegisterActivity;
import com.example.bookstore.R;
import com.example.bookstore.activity.MainActivity;
import com.example.bookstore.activity.ProductHasBeenBought;
import com.example.bookstore.activity.UpdateAccountActivity;
import com.example.bookstore.model.Entity.User;
import com.example.bookstore.room.database.AppDatabase;

/**
 * A simple {@link Fragment} subclass.
 */
public class AccountFragment extends Fragment {

    private Button btnLogin;
    private Button btnLogged;
    private Button btnLogout,btnProductBought,btnManagerBill;
    private AppDatabase mDB;
    private SharedPreferences sharedPreferences;
    boolean isLogged;
    public AccountFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_account, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        setHasOptionsMenu(true);
        init(view);
        sharedPreferences = requireActivity().getSharedPreferences("Logged", Context.MODE_PRIVATE);

        isLogged = sharedPreferences.getBoolean("IsLogged",false);
        if(isLogged)
        {
            btnLogged.setVisibility(View.VISIBLE);
            btnLogin.setVisibility(View.GONE);
            User user = mDB.UseDao().getUser().get(0);
            btnLogged.setText("Xin Chào : " + user.getTenKH());
            btnLogout.setVisibility(View.VISIBLE);
        }
        else
        {
            btnLogout.setVisibility(View.GONE);
            btnLogged.setVisibility(View.GONE);
            btnLogin.setVisibility(View.VISIBLE);
        }
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(requireContext(), LoginRegisterActivity.class);
                startActivity(intent);
            }
        });

        btnLogout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                SharedPreferences.Editor editor = sharedPreferences.edit();
                editor.clear();
                editor.apply();
                mDB.UseDao().Logout();
                Intent intent = new Intent(requireContext(), MainActivity.class);
                startActivity(intent);
            }
        });

        btnProductBought.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent;
                if(isLogged)
                {
                    intent = new Intent(requireContext(), ProductHasBeenBought.class);
                }
                else
                {
                    intent = new Intent(requireContext(), LoginRegisterActivity.class);
                }
                startActivity(intent);

            }
        });

        btnManagerBill.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent;
                if(isLogged)
                {
                    intent = new Intent(requireContext(), BillsManagerActivity.class);
                }
                else
                {
                    intent = new Intent(requireContext(), LoginRegisterActivity.class);
                }
                startActivity(intent);
            }
        });

        btnLogged.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(requireContext(), UpdateAccountActivity.class);
                startActivity(intent);
            }
        });
    }

    @Override
    public void onCreateOptionsMenu(@NonNull Menu menu, MenuInflater inflater) {
        inflater.inflate(R.menu.menu_cart,menu);
        super.onCreateOptionsMenu(menu, inflater);
    }

    private void init(View view)
    {
        btnManagerBill = view.findViewById(R.id.btnManagerBill);
        btnLogout = view.findViewById(R.id.btnLogout);
        mDB = AppDatabase.BuilderDatabase(requireContext());
        btnLogged = view.findViewById(R.id.btnLogged);
        btnLogin = view.findViewById(R.id.btnLogin);
        btnProductBought = view.findViewById(R.id.btnProductBought);
    }
}
