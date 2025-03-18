using System;

namespace SolidPrinciples
{

    // Applying SOLID Principles

    /// <summary>
    /// Responsible for generating reports.
    /// </summary>
    public class ReportGenerator
    {
        /// <summary>
        /// Generates a report.
        /// </summary>
        /// <returns>Report content as a string.</returns>
        public string GenerateReport()
        {
            return "Report Content";
        }
    }

    /// <summary>
    /// Responsible for saving reports to a file.
    /// </summary>
    public class ReportSaver
    {
        /// <summary>
        /// Saves the report content to a specified file path.
        /// </summary>
        /// <param name="reportContent">The content of the report.</param>
        /// <param name="filePath">The file path to save the report.</param>
        public void SaveReport(string reportContent, string filePath)
        {
            File.WriteAllText(filePath, reportContent);
        }
    }

    /// <summary>
    /// Interface for report formatting.
    /// </summary>
    public interface IReportFormatter
    {
        /// <summary>
        /// Formats the report content.
        /// </summary>
        /// <param name="content">The report content.</param>
        /// <returns>Formatted report content.</returns>
        string FormatReport(string content);
    }

    /// <summary>
    /// PDF report formatting implementation.
    /// </summary>
    public class PdfFormatter : IReportFormatter
    {
        public string FormatReport(string content)
        {
            return "PDF: " + content;
        }
    }

    /// <summary>
    /// Excel report formatting implementation.
    /// </summary>
    public class ExcelFormatter : IReportFormatter
    {
        public string FormatReport(string content)
        {
            return "Excel: " + content;
        }
    }

    /// <summary>
    /// Abstract base class for reports.
    /// </summary>
    public abstract class Report
    {
        public abstract string GetContent();
    }

    /// <summary>
    /// Financial report implementation.
    /// </summary>
    public class FinancialReport : Report
    {
        public override string GetContent()
        {
            return "Financial Report Content";
        }
    }

    /// <summary>
    /// Sales report implementation.
    /// </summary>
    public class SalesReport : Report
    {
        public override string GetContent()
        {
            return "Sales Report Content";
        }
    }

    /// <summary>
    /// Interface for report generation.
    /// </summary>
    public interface IReportGenerator
    {
        string GenerateReport();
    }

    /// <summary>
    /// Interface for report saving.
    /// </summary>
    public interface IReportSaver
    {
        void SaveReport(string content, string filePath);
    }

    /// <summary>
    /// Manages report services and dependencies.
    /// </summary>
    public class ReportService
    {
        private readonly IReportGenerator _reportGenerator;
        private readonly IReportSaver _reportSaver;

        public ReportService(IReportGenerator reportGenerator, IReportSaver reportSaver)
        {
            _reportGenerator = reportGenerator;
            _reportSaver = reportSaver;
        }

        /// <summary>
        /// Processes and saves a report to a specified file path.
        /// </summary>
        /// <param name="filePath">File path where the report will be saved.</param>
        public void ProcessReport(string filePath)
        {
            string report = _reportGenerator.GenerateReport();
            _reportSaver.SaveReport(report, filePath);
        }
    }

}
