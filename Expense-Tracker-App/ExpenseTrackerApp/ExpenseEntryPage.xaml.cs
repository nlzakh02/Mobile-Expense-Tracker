﻿using ExpenseTrackerApp.Model;
using ExpenseTrackerApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpenseTrackerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseEntryPage : ContentPage
    {
        public List<Category> Categories;
          
        public ExpenseEntryPage()
        {                       
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            selectCategory.ItemsSource = CategInfo.Categories; // for listview
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            var chosen = (Category)selectCategory.SelectedItem;
            var filename = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                $"{Path.GetRandomFileName()}.expense.txt");

            if (string.IsNullOrWhiteSpace(expense.Filename))
            {
                File.WriteAllText(filename, $"{name.Text};{amount.Text};{expensedate.Date.ToShortDateString()};{chosen.Image}");
            }
            else
            {
                File.WriteAllText(expense.Filename, $"{name.Text};{amount.Text};{expensedate.Date.ToShortDateString()};{chosen.Image}");
            }

            await Navigation.PopModalAsync();
        }

        private async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}