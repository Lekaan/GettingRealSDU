﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GettingRealSDU;

namespace GettingRealSDUApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            FileHandler fh = new FileHandler();
            fh.CreateFiles();
            
            fh.CreateDevice("TestID4", "TestMachine2");
            fh.CreateSupporter("kief234", "Kirsten", "Gudman Larsen");
            fh.CreateDevice("TestID3", "TestMachine3");
        }
    }
}
