using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SampleProject.Data;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{title}")]
        public async Task<ActionResult<ServiceBill>> PostServices(string title, List<serviceDTO> serviceRequests)
        {
            decimal CostSum = 0;
            decimal CapitalSum = 0;
            
            // دیکشنری به عنوان آیتم های صورت حساب در خروجی استفاده می شود
            ServiceBill bill = new ServiceBill()
            {
                ServiceCost = new Dictionary<string, decimal>()
            };
            
            // در صورتی که مقداری در ورودی وارد نشده باشد خطا برمیگرداند
            if (serviceRequests == null)
            {
                bill.ErrorMessage = "فیلد های داده بطور صحیح وارد نشده اند.";
                return bill;
            }
            
            //نوع پوشش  های در خواستی را در آرایه قرار میدهد
            var serviceTypes = serviceRequests.Select(x => x.ServiceType);
            // داده مربوط به پوشش های درخواستی را از دیتابیس دریافت می کند
            var serviceFromDb = _context.Services.Where(x => serviceTypes.Contains(x.ServiceName)).AsNoTracking().ToList();

            // با فرظ بر این که هر کاربر در  هر درخواست تنها هر پوشش را تنها یک بار انتخاب میکند
            // در صورتی که تعداد پوشش های انتخابی با تعداد پوشش های بارگذاری شده از دیتابیس 
            // یکی نباشد خطایی در وارد کردن نوع پوشش پیش آمده
            if (serviceRequests.Count != serviceFromDb.Count)
            {
                bill.ErrorMessage = "خدمات درخواستی در لیست وجود ندارند. نوع درخواست را بررسی کنید.";
                return bill;
            }

            // تعریف یک ترنزاکشن تا در صورت بروز خطا مواردی که قبلا در دیتا بیس تغییر کرده اند 
            // به حالت اول باز گردند
            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    // هر درخواست یک عنوان دارد و شامل حداقل یک پوشش است
                    // Request:
                    // شامل هدر درخواستهاست و 
                    // SoldInsurance:
                    // شامل آیتم های هر درخواست اس 
                    Requests request = new Requests();
                    request.RequestTitle = title;
                    _context.Add(request);
                    _context.SaveChanges();
                    
                    foreach (var requestedItem in serviceRequests)
                    {
                        var serviceObj = serviceFromDb.First(x => x.ServiceName.Equals(requestedItem.ServiceType));
                        

                        // در صورتی که سرمایه در محدوده مجاز نباشد تغییرات دیتا بیس بازگردانی شده
                        // و پیام خطا به کاربر ارسال میشود
                        if(requestedItem.Capital < serviceObj.MinCapital 
                            || requestedItem.Capital > serviceObj.MaxCapital)
                        {
                            transaction.Rollback();
                            bill.ServiceCost = null;
                            bill.Sum = 0;
                            bill.ErrorMessage = "لطفا مقدار سرمایه را در محدوده مجاز تعیین کنید.";
                            return bill;
                        }
                        
                        // محاسبه نرخ بیمه بصورتی موردی و جمع کل
                        decimal cost = serviceObj.Rate * requestedItem.Capital;
                        CostSum += cost;
                        CapitalSum += requestedItem.Capital;
                        bill.ServiceCost.TryAdd(serviceObj.ServiceName, cost);


                        //دخیره آیتم های مورد در خواست در دیتا بیس 
                        SoldInsurance soldInsurance = new SoldInsurance()
                        {
                            RequestId = request.Id,
                            ServiceId = serviceObj.Id,
                            Capital = requestedItem.Capital,
                            Cost = cost
                        };
                        _context.Add(soldInsurance);

                    }

                   
                    request.CapitalSum = CapitalSum;
                    request.BillTotal = CostSum;
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    // در صورت بروز حر خطای پیش بینی نشده دیتا بیس رول بک شده
                    // و پیغام خطا به کاربر ارسال می شود
                    transaction.Rollback();
                    bill.ServiceCost = null;
                    bill.Sum = 0;
                    bill.ErrorMessage = ex.Message;
                    return bill;
                }
            }

            bill.Sum = CostSum;

            return bill;
        }


    }
}
