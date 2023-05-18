namespace AdvoSecure.Application.Extensions
{
    public static class GeneratorExtension
    {
        public static string GenerateUserCode(string firstName, string lastName)
        {
            var code = new string(new char[] { firstName[0], lastName[0], lastName[1] }).ToUpper();
            return code;
        }

        public static string GenerateMatterNumber(long sequence, string currentUserCode)
        {
            string format = "YYYY/NNNNCCC";

            var currentYear = DateTime.Now.ToString("yyyy");

            var sequenceNumber = sequence.ToString("D4");

            var number = format.Replace("YYYY", currentYear).Replace("NNNN", sequenceNumber).Replace("CCC", currentUserCode);

            return number;
        }
    }
}
