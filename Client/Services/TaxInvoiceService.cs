using OrisonFinance.Shared;
using OrisonFinance.Shared.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace OrisonFinance.Client.Services
{
    public class TaxInvoiceService
    {
        int vtype;
        int vNo;
        HttpClient http;
        //IDBOperation idbopn;
        public TaxInvoiceService(HttpClient httpClient)
        {
            http = httpClient;
            //idbopn = idb;
        }
        public async Task<int> getVtype()
        {
            vtype = await http.GetFromJsonAsync<int>("/api/Values/Sales%20POS");
            return vtype;
        }
        //int vtype, DateTime d, int _BranchId
        public async Task<int> GetNextNoAsync(int vtype, string d, int _BranchId)
        {
            string apivalues = vtype.ToString() + '/' + d + '/' + _BranchId;
            vNo = await http.GetFromJsonAsync<int>("/api/Values/" + apivalues);
            //vNo = await http.GetFromJsonAsync<string>("/api/Values/75/10-15-2020/31");
            return vNo;
            //return (string)idbopn.NewNumber(vtype, d, _BranchId);
        }

    }
     
    }