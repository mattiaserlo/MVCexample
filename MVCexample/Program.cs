using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MVCexample
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      PubSub myPubSub = new PubSub();
      Form1 myForm = new Form1();
      myForm.setPubSub(myPubSub);
      Controller myController = new Controller(myForm);
      Model myModel = new Model();
      myModel.setPubSub(myPubSub);
      myController.setModel(myModel);
      Application.Run(myForm);
    }
  }
}