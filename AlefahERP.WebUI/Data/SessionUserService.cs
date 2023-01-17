using AlefahERP.DTO;
using AlefahERP.Services;
using System.Security.Claims;

namespace AlefahERP.WebUI.Data
{
    public class SessionUserService
    {
        private ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
        private readonly CustomAuthService auth;
        private readonly IUnitOfWork unitOfWork;

        public SessionUserService(CustomAuthService auth, IUnitOfWork unitOfWork)
        {
            claimsPrincipal = new ClaimsPrincipal();
            this.auth = auth;
            this.unitOfWork = unitOfWork;

            this.auth.Users.TryGetValue("Users--x", out claimsPrincipal);

            if (claimsPrincipal != null)
            {
                if (claimsPrincipal.Claims.Any())
                {
                    Claim? claimUserID = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "UserID");
                    if (claimUserID != null)
                    {
                        int _userID;
                        int.TryParse(claimUserID.Value, out _userID);

                        if (_userID > 0)
                        {
                            User = this.unitOfWork.Users.Users.GetAll(x => x.UserID == _userID).FirstOrDefault();


                            if (User != null)
                            {
                                if (User.UserRoleCode != "Customer")
                                {
                                    Employee = this.unitOfWork.Employees.Employees.GetAll(x => x.UserID == _userID).FirstOrDefault();
                                }
                                else
                                {
                                    Customer = this.unitOfWork.Customers.Customers.GetAll(x => x.UserID == _userID).FirstOrDefault();
                                }
                            }
                        }
                    }




                }
            }
        }

        public viewUsers User { get; set; }
        public viewEmployees? Employee { get; set; }
        public viewCustomers? Customer { get; set; }


    }
}
