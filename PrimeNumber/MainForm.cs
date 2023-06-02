using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrimeNumber
{
    public partial class MainForm : Form
    {
        /*
         * //Parallel 不支持UInt64，所以使用Int64
         * 
         * 2023/03/27 15:22:38.9969871，Parallel起始值：2，终止值1000000，结果数量：78498，耗时：00:00:21.8807827
         * 2023/03/27 15:28:46.9166055，Task起始值：2，终止值1000000，结果数量：78498，耗时：00:06:00.3271774
         * 
         */


        public MainForm()
        {
            InitializeComponent();
        }

        //Parallel并行计算
        ParallelOptions parallelOptions;
        CancellationTokenSource cts;

        //进度监控线程
        Task tMoniter = null;
        CancellationTokenSource tMoniter_cts = null;

        //结果
        static object PrimeNumberListLock = new object();
        static List<Int64> PrimeNumberList = new List<Int64>();

        private void PrimeNumberForm_Load(object sender, EventArgs e)
        {
            this.txtMax.Text = "100000";//Int64.MaxValue.ToString();
            this.txtSetCores.Text = Environment.ProcessorCount.ToString();
            RuningStatus(false);
        }

        #region log
        private delegate void ShowInLogCallback(string msg, bool autoTime = true);
        private ShowInLogCallback showInlogMethodCallback;
        private void ShowLog(string msg, bool autoTime = true)
        {
            if (this.lbMsg.InvokeRequired)
            {
                showInlogMethodCallback = new ShowInLogCallback(ShowLog);
                lbMsg.Invoke(showInlogMethodCallback, new object[] { msg, autoTime });
            }
            else
            {
                if (autoTime)
                {
                    msg = string.Format("{0},{1}", DateTime.Now.ToString("HH:mm:ss.fffffff"), msg);
                }
                Helper.LogHelper.WriteBinLog(msg, "Log");
                this.lbMsg.Items.Insert(0, msg);
            }
        }
        #endregion

        private void btnFillMax_Click(object sender, EventArgs e)
        {
            this.txtMax.Text = Int64.MaxValue.ToString();
        }

        private void btnStartParallel_Click(object sender, EventArgs e)
        {
            DateTime dtStart = DateTime.Now;
            Int64 startValue = Convert.ToInt64(this.txtStartValue.Text.Trim());
            Int64 endValue = Convert.ToInt64(this.txtMax.Text.Trim());
            int useCores = Convert.ToInt32(this.txtSetCores.Text.Trim());

            if (useCores > Environment.ProcessorCount)
            {
                useCores = Environment.ProcessorCount;
                this.txtSetCores.Text = useCores.ToString();
            }

            ParallelLoopResult result = new ParallelLoopResult();
            PrimeNumberList.Clear();

            RuningStatus(true);

            Task.Run(() =>
            {
                try
                {
                    ShowLog("启动计算");
                    string fileName = string.Format("{0}-{1}", startValue, endValue);
                    //计算核心
                    cts = new CancellationTokenSource();
                    parallelOptions = new ParallelOptions() { MaxDegreeOfParallelism = useCores, CancellationToken = cts.Token, };
                    result = Parallel.For(startValue, endValue, parallelOptions, (x, pls) =>
                    {
                        bool IsPrimeNumber = Helper.PrimeNumberHelper.IsPrimeNumber(Convert.ToUInt64(x.ToString()));
                        //Console.WriteLine($"{x}:{b}");

                        if (IsPrimeNumber)
                        {
                            lock (PrimeNumberListLock)
                            {
                                PrimeNumberList.Add(x);
                            }
                            Helper.LogHelper.WriteBinLog(x.ToString(), "PrimeNumber_Parallel", fileName, false, false);
                        }
                    });
                }
                catch (Exception ex)
                {
                    ShowLog(ex.Message);
                }
                finally
                {
                    TimeSpan ts = DateTime.Now - dtStart;
                    string tips = string.Format("Parallel，起始值：{0}，终止值{1}，结果数量：{2}，耗时：{3}", startValue, endValue, PrimeNumberList.Count(), ts.ToString());
                    ShowLog(tips);
                    RuningStatus(false);
                }
            });

            //进度监控
            tMoniter_cts = new CancellationTokenSource();
            tMoniter = new Task(() =>
            {
                DateTime dtEnd = DateTime.Now;
                TimeSpan ts = dtEnd - dtStart;
                try
                {
                    //Thread.Sleep(1 * 1000);//给result启动预留时间
                    while (!result.IsCompleted)
                    {
                        if (tMoniter_cts.Token.IsCancellationRequested)
                        {
                            ShowMoniter(string.Format("得到质数总数：{0}，后台运行状态：{1}，耗时：{2}", PrimeNumberList.Count(), "取消", ts.ToString()));
                            return;
                        }

                        dtEnd = DateTime.Now;
                        ts = dtEnd - dtStart;
                        ShowMoniter(string.Format("得到质数总数：{0}，后台运行状态：{1}，耗时：{2}", PrimeNumberList.Count(), "运行中", ts.ToString()));
                        Thread.Sleep(1 * 1000);
                    }
                    //完成
                    ShowMoniter(string.Format("得到质数总数：{0}，后台运行状态：{1}，耗时：{2}", PrimeNumberList.Count(), "完成", ts.ToString()));
                }
                catch (Exception ex)
                {
                    ShowLog(ex.Message);
                }
            }, tMoniter_cts.Token);
            tMoniter.Start();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ShowLog("终止计算");
            if (cts != null)
            {
                cts.Cancel();
            }
            if (tMoniter_cts != null)
            {
                tMoniter_cts.Cancel();
            }
            RuningStatus(false);
        }

        private void btnSetCores_Click(object sender, EventArgs e)
        {
            parallelOptions.MaxDegreeOfParallelism = Convert.ToInt32(this.txtSetCores.Text.Trim());
            ShowLog("工作内核数设置为" + parallelOptions.MaxDegreeOfParallelism);
        }

        private void RuningStatus(bool isRuning)
        {
            this.btnStartParallel.Invoke(new Action(() =>
            {
                this.btnStartParallel.Enabled = !isRuning;
                this.btnFillMax.Enabled = !isRuning;
                this.btnSetCores.Enabled = !isRuning;
                this.btnStop.Enabled = isRuning;
            }));
        }
        private void ShowMoniter(string msg)
        {
            this.txtMsg.Invoke(new Action(() =>
            {
                this.txtMsg.Text = DateTime.Now.ToString("HH:mm:ss.fffffff") + "，" + msg + Environment.NewLine;
            }));
        }

        /// <summary>
        /// 排序后导出文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOut_Click(object sender, EventArgs e)
        {

            List<long> outList = new List<long>();
            lock (PrimeNumberListLock)
            {
                outList = PrimeNumberList;
            }
            outList.Sort();
            if (outList.Count == 0)
            {
                ShowLog("无暂存结果可以导出！");
                return;
            }

            string fileName = string.Format("{0}-{1}_WithSort", outList.Min(), outList.Max());

            foreach (long num in outList)
            {
                Helper.LogHelper.WriteBinLog(num.ToString(), "PrimeNumber_Parallel", fileName, false, false);
            }
            ShowLog("导出完成！" + fileName);
        }
    }
}
