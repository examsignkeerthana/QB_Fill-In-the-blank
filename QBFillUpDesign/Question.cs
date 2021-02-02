using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBFillUpDesign
{
    class FillUpQuestionModel
    {
        public String Question { get; set; }

        public bool QuesHasImage { get; set; }

        public List<String> ImagePath { get; set; }

        public List<FillUpAnswerModel> Answer { get; set; }

    }
    class FillUpAnswerModel
    {
        public String Answer { get; set; }

        public List<string> AltAns { get; set; }

        public String AnsType { get; set; }

        public int Position { get; set; }
    }
   
}
