using System;
using System.Data;
using System.Configuration;
using tw.com.yj.CommonLib;
using KGLib.dl;

namespace tw.com.kg.lib
{
    /// <summary>
    /// CFactoryManager 的摘要描述
    /// </summary>
    public class CFactoryManager
    {

        private YJCommonContext _context;
        public CFactoryManager(YJCommonContext p_context)
        {
            _context = p_context;
        }
        private CUserFactory _CUserFactory;
        public CUserFactory CUserFactory
        {
            get
            {
                if (_CUserFactory == null)
                    _CUserFactory = new CUserFactory(_context);
                return _CUserFactory;
            }
        }
        private CConstructionFactory _CConstructionFactory;
        public CConstructionFactory CConstructionFactory
        {
            get
            {
                if (_CConstructionFactory == null)
                    _CConstructionFactory = new CConstructionFactory(_context);
                return _CConstructionFactory;
            }
        }
        private CInMoneyFactory _CInMoneyFactory;
        public CInMoneyFactory CInMoneyFactory
        {
            get
            {
                if (_CInMoneyFactory == null)
                    _CInMoneyFactory = new CInMoneyFactory(_context);
                return _CInMoneyFactory;
            }
        }
        private CInMoneyDetailFactory _CInMoneyDetailFactory;
        public CInMoneyDetailFactory CInMoneyDetailFactory
        {
            get
            {
                if (_CInMoneyDetailFactory == null)
                    _CInMoneyDetailFactory = new CInMoneyDetailFactory(_context);
                return _CInMoneyDetailFactory;
            }
        }
        private CWorkFactory _CWorkFactory;
        public CWorkFactory CWorkFactory
        {
            get
            {
                if (_CWorkFactory == null)
                    _CWorkFactory = new CWorkFactory(_context);
                return _CWorkFactory;
            }
        }
        private CWorkTypeFactory _CWorkTypeFactory;
        public CWorkTypeFactory CWorkTypeFactory
        {
            get
            {
                if (_CWorkTypeFactory == null)
                    _CWorkTypeFactory = new CWorkTypeFactory(_context);
                return _CWorkTypeFactory;
            }
        }
        private CInsuranceFactory _CInsuranceFactory;
        public CInsuranceFactory CInsuranceFactory
        {
            get
            {
                if (_CInsuranceFactory == null)
                    _CInsuranceFactory = new CInsuranceFactory(_context);
                return _CInsuranceFactory;
            }
        }


        private C薪資計算Factory _C薪資計算Factory;
        public C薪資計算Factory C薪資計算Factory
        {
            get
            {
                if (_C薪資計算Factory == null)
                    _C薪資計算Factory = new C薪資計算Factory(_context);
                return _C薪資計算Factory;
            }
        }
        private C保險實績統計Factory _C保險實績統計Factory;
        public C保險實績統計Factory C保險實績統計Factory
        {
            get
            {
                if (_C保險實績統計Factory == null)
                    _C保險實績統計Factory = new C保險實績統計Factory(_context);
                return _C保險實績統計Factory;
            }
        }
        private C工單實績Factory _C工單實績Factory;
        public C工單實績Factory C工單實績Factory
        {
            get
            {
                if (_C工單實績Factory == null)
                    _C工單實績Factory = new C工單實績Factory(_context);
                return _C工單實績Factory;
            }
        }
        private C台數統計Factory _C台數統計Factory;
        public C台數統計Factory C台數統計Factory
        {
            get
            {
                if (_C台數統計Factory == null)
                    _C台數統計Factory = new C台數統計Factory(_context);
                return _C台數統計Factory;
            }
        }
        private C亮新專案招攬Factory _C亮新專案招攬Factory;
        public C亮新專案招攬Factory C亮新專案招攬Factory
        {
            get
            {
                if (_C亮新專案招攬Factory == null)
                    _C亮新專案招攬Factory = new C亮新專案招攬Factory(_context);
                return _C亮新專案招攬Factory;
            }
        }
        private C各廠介紹獎金Factory _C各廠介紹獎金Factory;
        public C各廠介紹獎金Factory C各廠介紹獎金Factory
        {
            get
            {
                if (_C各廠介紹獎金Factory == null)
                    _C各廠介紹獎金Factory = new C各廠介紹獎金Factory(_context);
                return _C各廠介紹獎金Factory;
            }
        }
        private CKGPointFactory _CKGPointFactory;
        public CKGPointFactory CKGPointFactory
        {
            get
            {
                if (_CKGPointFactory == null)
                    _CKGPointFactory = new CKGPointFactory(_context);
                return _CKGPointFactory;
            }
        }
        private CKGPointDetailFactory _CKGPointDetailFactory;
        public CKGPointDetailFactory CKGPointDetailFactory
        {
            get
            {
                if (_CKGPointDetailFactory == null)
                    _CKGPointDetailFactory = new CKGPointDetailFactory(_context);
                return _CKGPointDetailFactory;
            }
        }
        private CKGPartFactory _CKGPartFactory;
        public CKGPartFactory CKGPartFactory
        {
            get
            {
                if (_CKGPartFactory == null)
                    _CKGPartFactory = new CKGPartFactory(_context);
                return _CKGPartFactory;
            }
        }
        private CKGPartOrderFactory _CKGPartOrderFactory;
        public CKGPartOrderFactory CKGPartOrderFactory
        {
            get
            {
                if (_CKGPartOrderFactory == null)
                    _CKGPartOrderFactory = new CKGPartOrderFactory(_context);
                return _CKGPartOrderFactory;
            }
        }
        private CKGPartOrderDetailFactory _CKGPartOrderDetailFactory;
        public CKGPartOrderDetailFactory CKGPartOrderDetailFactory
        {
            get
            {
                if (_CKGPartOrderDetailFactory == null)
                    _CKGPartOrderDetailFactory = new CKGPartOrderDetailFactory(_context);
                return _CKGPartOrderDetailFactory;
            }
        }
        private CKGPartOrderDetailOutFactory _CKGPartOrderDetailOutFactory;
        public CKGPartOrderDetailOutFactory CKGPartOrderDetailOutFactory
        {
            get
            {
                if (_CKGPartOrderDetailOutFactory == null)
                    _CKGPartOrderDetailOutFactory = new CKGPartOrderDetailOutFactory(_context);
                return _CKGPartOrderDetailOutFactory;
            }
        }
        private C小百貨產品銷售排行Factory _C小百貨產品銷售排行Factory;
        public C小百貨產品銷售排行Factory C小百貨產品銷售排行Factory
        {
            get
            {
                if (_C小百貨產品銷售排行Factory == null)
                    _C小百貨產品銷售排行Factory = new C小百貨產品銷售排行Factory(_context);
                return _C小百貨產品銷售排行Factory;
            }
        }
        private C小百貨銷售明細Factory _C小百貨銷售明細Factory;
        public C小百貨銷售明細Factory C小百貨銷售明細Factory
        {
            get
            {
                if (_C小百貨銷售明細Factory == null)
                    _C小百貨銷售明細Factory = new C小百貨銷售明細Factory(_context);
                return _C小百貨銷售明細Factory;
            }
        }
        private CEngnoFactory _CEngnoFactory;
        public CEngnoFactory CEngnoFactory
        {
            get
            {
                if (_CEngnoFactory == null)
                    _CEngnoFactory = new CEngnoFactory(_context);
                return _CEngnoFactory;
            }
        }
        private C欠款紀錄Factory _C欠款紀錄Factory;
        public C欠款紀錄Factory C欠款紀錄Factory
        {
            get
            {
                if (_C欠款紀錄Factory == null)
                    _C欠款紀錄Factory = new C欠款紀錄Factory(_context);
                return _C欠款紀錄Factory;
            }
        }

        private 特販審核Factory _特販審核Factory;
        public 特販審核Factory 特販審核Factory
        {
            get
            {
                if (_特販審核Factory == null)
                    _特販審核Factory = new 特販審核Factory(_context);
                return _特販審核Factory;
            }
        }


        private CSatisfactionFactory _CSatisfactionFactory;
        public CSatisfactionFactory CSatisfactionFactory
        {
            get
            {
                if (_CSatisfactionFactory == null)
                    _CSatisfactionFactory = new CSatisfactionFactory(_context);
                return _CSatisfactionFactory;
            }
        }
        private CTestDriveFactory _CTestDriveFactory;
        public CTestDriveFactory CTestDriveFactory
        {
            get
            {
                if (_CTestDriveFactory == null)
                    _CTestDriveFactory = new CTestDriveFactory(_context);
                return _CTestDriveFactory;
            }
        }

        private CClockFactory _CClockFactory;
        public CClockFactory CClockFactory
        {
            get
            {
                if (_CClockFactory == null)
                    _CClockFactory = new CClockFactory(_context);
                return _CClockFactory;
            }
        }

        private OffDutyFactory _OffDutyFactory;
        public OffDutyFactory OffDutyFactory 
        {
            get 
            {
                if (_OffDutyFactory == null)
                {
                    _OffDutyFactory = new OffDutyFactory(_context);
                }
                return _OffDutyFactory;
            }
        
        }
        
    }

}