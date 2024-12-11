using MauiBindingIssue.ViewModels;
using MauiBindingIssue.Views;

namespace MauiBindingIssue
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {

          QuestionnaireViewModel vm = new QuestionnaireViewModel();


            return new Window(new QuestionPage(vm));
        }
    }
}