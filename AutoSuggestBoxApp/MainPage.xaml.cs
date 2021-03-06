﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AutoSuggestBoxApp
{



    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public class Pessoa
        {
            public int id { get; set; }

            public string nome { get; set; }
        }


        ObservableCollection<Pessoa> fonteDados = new ObservableCollection<Pessoa>();

        ObservableCollection<Pessoa> listaResultado = new ObservableCollection<Pessoa>();


        public MainPage()
        {
            this.InitializeComponent();

            PopularFonteDados();

            txtPesquisa.ItemsSource = listaResultado;
        }

        public void PopularFonteDados()
        {
            fonteDados.Add(new Pessoa
            {
                id = 1,
                nome = "TIAGO"
            });
            fonteDados.Add(new Pessoa
            {
                id = 2,
                nome = "JOICE"
            });

            fonteDados.Add(new Pessoa
            {
                id = 3,
                nome = "ROCK"
            });


            for (int i = 1; i < 12; i++)
            {
                fonteDados.Add(new Pessoa
                {
                    id = 3+i,
                    nome = "FUTURO FILHO " + i
                });
            }

        }

        private void txtPesquisa_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var lista = fonteDados.Where(it => (it.nome ?? "").ToLower().Contains(args.QueryText.ToLower()));

            listaResultado.Clear();
            foreach (var item in lista)
            {
                listaResultado.Add(item);
            }
        }

        private void txtPesquisa_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var p = args.SelectedItem as Pessoa;

            txtInfo.Text = "Selecionado: " + p.id + " - " + p.nome;
    
        }
    }
}
