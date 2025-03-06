using Reqnroll;
using ReqnrollTestProject.Reports;

namespace ReqnrollTestProject.Hooks
{
	[Binding]
	public sealed class Hooks
	{
		// For additional details on Reqnroll hooks see https://go.reqnroll.net/doc-hooks

		[BeforeTestRun]
		public static void BeforeTestRun()
		{ 
			ExtentReportManager.InitReport();
		}

		[BeforeScenario]
		public void BeforeScenario(ScenarioContext scenarioContext)
		{
			ExtentReportManager.StartTest(scenarioContext.ScenarioInfo.Title);
		}

		[AfterStep]
		public static void AfterStep(ScenarioContext scenarioContext) {
			var stepInfo = scenarioContext.StepContext.StepInfo.Text;
			bool isSuccses = scenarioContext.TestError == null;

			ExtentReportManager.LogStep(isSuccses, isSuccses ? $"Paso exitoso:{stepInfo}" : $"Error:{scenarioContext.TestError.Message}");
		}

		[AfterTestRun]
		public static void AfterTestRun()
		{
			ExtentReportManager.FlushReport();
		}
	}
}