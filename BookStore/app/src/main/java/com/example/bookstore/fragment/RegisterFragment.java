package com.example.bookstore.fragment;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.Toast;

import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.model.Entity.User;
import com.example.bookstore.R;

import java.util.UUID;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * A simple {@link Fragment} subclass.
 */
public class RegisterFragment extends Fragment {
    EditText edtName,edtPhoneNumber, edtAddress, edtPassword;
    RadioButton rdMale, rdFeMale;
    Button btnRegister;
    RequestAPI requestAPI;

    public RegisterFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_register, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        init(view);
        requestAPI = APIClient.getClient().create(RequestAPI.class);

        btnRegister.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String userID = UUID.randomUUID().toString();
                String userName = edtName.getText().toString();
                String phoneNumber = edtPhoneNumber.getText().toString();
                String address = edtAddress.getText().toString();
                String password = edtPassword.getText().toString();
                boolean sex = rdMale.isChecked();
                //
                User user = new User(userID,userName,phoneNumber,address,sex,password);
                Call<String> call = requestAPI.createUser(user);
                call.enqueue(new Callback<String>() {
                    @Override
                    public void onResponse(Call<String> call, Response<String> response) {
                        if(response.isSuccessful())
                        {
                            Toast.makeText(requireContext(),"isSuccessful",Toast.LENGTH_LONG);
                        }
                        Log.d("TAG","Response = "+ response.body());
                    }

                    @Override
                    public void onFailure(Call<String> call, Throwable t) {
                        Log.d("TAG","Response = "+t.toString());
                    }
                });
            }
        });
    }

    private void init(View view)
    {
        edtName = view.findViewById(R.id.edt_Name);
        edtPhoneNumber = view.findViewById(R.id.edt_phone_number);
        edtAddress = view.findViewById(R.id.edt_address);
        edtPassword = view.findViewById(R.id.edt_password);
        rdFeMale = view.findViewById(R.id.radio_button_female);
        rdMale = view.findViewById(R.id.radio_button_male);
        btnRegister = view.findViewById(R.id.btn_register);
    }
}
