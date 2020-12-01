package com.example.bookstore.activity;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.SearchView;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.util.TypedValue;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AutoCompleteTextView;
import android.widget.CompoundButton;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.example.bookstore.R;
import com.example.bookstore.adapter.RecyclerViewTouchListener;
import com.example.bookstore.adapter.SearchBookAdapter;
import com.example.bookstore.api.APIClient;
import com.example.bookstore.api.RequestAPI;
import com.example.bookstore.model.Entity.Book;
import com.google.android.material.chip.Chip;
import com.google.android.material.chip.ChipGroup;

import java.util.ArrayList;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class SearchProductActivity extends AppCompatActivity {

    ChipGroup chipGroup;
    ImageView imgSearchBack;
    SearchView searchView;
    RequestAPI requestAPI;
    SearchBookAdapter searchBookAdapter;
    RecyclerView rcvSearchBook;
    ArrayList<Book> books = new ArrayList<Book>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_search_product);
        getSupportActionBar().hide();
        init();
        setSearchviewTextSize(searchView,14);

        String [] mKeyHots = {"Đắc Nhân Tâm","Nhà Giả Kim","Tôi Tài Giỏi Bạn Cũng Thế","Giới Hạn Của Bạn Là Xuất Phát Điểm Của Tôi"};
        try {
            for (String key: mKeyHots)
            {
                Chip newChip = addNewChip(key);
                // Set Listener for the Chip:
                newChip.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
                    @Override
                    public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                        handleChipCheckChanged((Chip) buttonView, isChecked);
                    }
                });

                newChip.setOnCloseIconClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        handleChipCloseIconClicked((Chip) v);
                    }
                });
            }
        }catch (Exception ex)
        {
            Toast.makeText(this,ex.getMessage(),Toast.LENGTH_LONG).show();
        }

        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(final String query) {
                Call<ArrayList<Book>> call = requestAPI.getAllBook();
                call.enqueue(new Callback<ArrayList<Book>>() {
                    @Override
                    public void onResponse(Call<ArrayList<Book>> call, Response<ArrayList<Book>> response) {
                        if(response.isSuccessful())
                        {
                            ArrayList<Book> list = response.body();
                            Log.i("aaa",list.toString());
                            for (Book book: list) {
                                if(book.getBookName().contains(query)){
                                    books.add(book);
                                }
                            }
                            Log.i("aaa",books.toString());
                            searchBookAdapter = new SearchBookAdapter(rcvSearchBook.getContext(),books);
                            rcvSearchBook.setAdapter(searchBookAdapter);
                            rcvSearchBook.setLayoutManager(new LinearLayoutManager(rcvSearchBook.getContext(), LinearLayoutManager.VERTICAL, false));
                            searchBookAdapter.notifyDataSetChanged();
                        }
                    }

                    @Override
                    public void onFailure(Call<ArrayList<Book>> call, Throwable t) {
                        Log.d("TAG","Book = "+t.toString());
                    }
                });
                return true;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                return false;
            }
        });

        rcvSearchBook.addOnItemTouchListener(new RecyclerViewTouchListener(this, rcvSearchBook, new RecyclerViewTouchListener.ClickListener() {
            @Override
            public void onClick(View view, int position) {
                Intent intent = new Intent(SearchProductActivity.this, DetailProductActivity.class);
                intent.putExtra("BookDetail", books.get(position));
                startActivity(intent);
            }

            @Override
            public void onLongClick(View view, int position) {

            }
        }));

        imgSearchBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                finish();
            }
        });
    }

    private void init()
    {
        chipGroup = (ChipGroup) findViewById(R.id.chipGroup);
        imgSearchBack = (ImageView) findViewById(R.id.btnSearchBack);
        searchView = (SearchView) findViewById(R.id.product_search_view);
        requestAPI = APIClient.getClient().create(RequestAPI.class);
        rcvSearchBook = findViewById(R.id.rcvSearch);
    }

    private Chip addNewChip(String key)
    {
        LayoutInflater inflater = LayoutInflater.from(this);
        Chip newChip = (Chip) inflater.inflate(R.layout.chip_entry, this.chipGroup, false);
        newChip.setText(key);
        this.chipGroup.addView(newChip);
        return newChip;
    }

    private void handleChipCloseIconClicked(Chip chip) {
        ChipGroup parent = (ChipGroup) chip.getParent();
        parent.removeView(chip);
    }

    // Chip Checked Changed
    private void handleChipCheckChanged(Chip chip, boolean isChecked) {
        searchView.setQuery(chip.getText(),false);
        handleChipCloseIconClicked(chip);
    }

    private void setSearchviewTextSize(SearchView searchView, int fontSize) {
        try {
            AutoCompleteTextView autoCompleteTextViewSearch = (AutoCompleteTextView) searchView.findViewById(searchView.getContext().getResources().getIdentifier("app:id/search_src_text", null, null));
            if (autoCompleteTextViewSearch != null) {
                autoCompleteTextViewSearch.setTextSize(TypedValue.COMPLEX_UNIT_SP, fontSize);
            } else {
                LinearLayout linearLayout1 = (LinearLayout) searchView.getChildAt(0);
                LinearLayout linearLayout2 = (LinearLayout) linearLayout1.getChildAt(2);
                LinearLayout linearLayout3 = (LinearLayout) linearLayout2.getChildAt(1);
                AutoCompleteTextView autoComplete = (AutoCompleteTextView) linearLayout3.getChildAt(0);
                autoComplete.setTextSize(TypedValue.COMPLEX_UNIT_SP, fontSize);
            }
        } catch (Exception e) {
            LinearLayout linearLayout1 = (LinearLayout) searchView.getChildAt(0);
            LinearLayout linearLayout2 = (LinearLayout) linearLayout1.getChildAt(2);
            LinearLayout linearLayout3 = (LinearLayout) linearLayout2.getChildAt(1);
            AutoCompleteTextView autoComplete = (AutoCompleteTextView) linearLayout3.getChildAt(0);
            autoComplete.setTextSize(TypedValue.COMPLEX_UNIT_SP, fontSize);
        }
    }
}
