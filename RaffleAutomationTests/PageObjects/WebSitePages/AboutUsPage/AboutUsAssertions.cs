using NUnit.Framework;
using RaffleAutomationTests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaffleAutomationTests.PageObjects
{
    public partial class AboutUs
    {
        public AboutUs VerifyFindOutBlock()
        {
            int i = 0;
            foreach (var description in descriptionFindOut)
            {
                i++;
                string descr = description.Text;
                Assert.IsTrue(descr.Equals(AboutTexts.FindOutTexts[--i]));
                i++;
            }

            return this;
        }

        public AboutUs VerifyStepsBlock()
        {
            int i = 0;
            int q = 0;
            foreach (var title in titleHowStep)
            {
                i++;
                string descr = title.Text;
                Assert.IsTrue(descr.Equals(AboutTexts.StepsTitleTexts[--i]));
                i++;
            }
            
            foreach (var description in descriptionHowStep)
            {
                q++;
                string descr = description.Text;
                Assert.IsTrue(descr.Equals(AboutTexts.StepsDescrTexts[--q]));
                q++;
            }

            return this;
        }

        public AboutUs VerifyCharitableBlock()
        {
            int i = 0;
            foreach (var description in descriptionCharitableCard)
            {
                i++;
                string descr = description.Text;
                Assert.IsTrue(descr.Equals(AboutTexts.CharitableTexts[--i]));
                i++;
            }

            return this;
        }

        public AboutUs VerifySiteCreditBlock()
        {
            
            Assert.IsTrue(titleSiteCredit.Text.Equals(AboutTexts.TitleSiteCredit));

            int i = 0;
            foreach (var description in descriptionSiteCredit)
            {
                i++;
                string descr = description.Text;
                Assert.IsTrue(descr.Equals(AboutTexts.DescriptionSiteCreditTexts[--i]));
                i++;
            }

            return this;
        }
    }
}
