using System.Collections.ObjectModel;
using Word = Microsoft.Office.Interop.Word;

namespace TaskMaster.Services
{
    public static class ReportMaker
    {
        public static void MakeReport(ObservableCollection<Models.Task> tasks)
        {
            Word.Application wordApp = new Word.Application();

            Word.Document doc = wordApp.Documents.Add();

            Word.Range range = doc.Content;
           

            Word.Table table = doc.Tables.Add(range, NumRows: tasks.Count + 1, NumColumns: 6);


            table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;
            table.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleDouble;

            table.Borders.OutsideColor = Word.WdColor.wdColorBlack;

            table.Borders.InsideColor = Word.WdColor.wdColorBlack;


            table.Cell(1, 1).Range.Text = "Название";
            table.Cell(1, 2).Range.Text = "Описание";
            table.Cell(1, 3).Range.Text = "Дата создания"; 
            table.Cell(1, 4).Range.Text = "Конечный срок";
            table.Cell(1, 5).Range.Text = "Статус";
            table.Cell(1, 6).Range.Text = "Приоритет";



            for(int i = 2; i <= tasks.Count; i++)
            {
                table.Rows.Add();
                table.Cell(i, 1).Range.Text = tasks[i - 1].Title;
                table.Cell(i, 2).Range.Text = tasks[i - 1].Description;
                table.Cell(i, 3).Range.Text = tasks[i - 1].StartDate.ToString();
                table.Cell(i, 4).Range.Text = tasks[i - 1].DeadLine.ToString();
                table.Cell(i, 5).Range.Text = tasks[i - 1].Status;
                table.Cell(i, 6).Range.Text = tasks[i - 1].Priority;

            }
            

            doc.SaveAs2(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\report.docx");

            doc.Close();
            wordApp.Quit();
        }
    }
}
