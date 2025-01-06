using UsingHybridOrm.Services.Abstract;

namespace UsingHybridOrm.UI
{
    public partial class Form1 : Form
    {
        private readonly IDepartmentService _departmentService;

        public Form1(IDepartmentService departmentService)
        {
            InitializeComponent();

            _departmentService = departmentService;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            var results = _departmentService.GetList();
        }
    }
}
