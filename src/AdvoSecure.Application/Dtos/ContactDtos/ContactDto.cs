using System.ComponentModel.DataAnnotations;

namespace AdvoSecure.Application.Dtos.ContactDtos
{
    public class ContactDto : BaseDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether the contact is an employee of the firm, this
        /// allows for booking of time.
        /// </summary>
        /// <value>
        ///   <c>true</c> if a firm employee; otherwise, <c>false</c>.
        /// </value>
        /// <author>Lucas Nodine</author>
        public bool IsOurEmployee { get; set; } = false;

        public bool IsOrganization { get; set; } = false;

        public string Picture { get; set; } = string.Empty;
        public byte[] PictureBin { get; set; }

        #region Contact Name
        [MaxLength(6)]
        public string? Code { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the nickname of the contact.
        /// </summary>
        /// <value>
        /// The nickname.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets the generation suffix of the contact, such as "Jr.", "Sr.", or "III".
        /// </summary>
        /// <value>
        /// The generation.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Generation { get; set; }

        /// <summary>
        /// Gets or sets the title of the contact, such as "Mr." or "Mrs.".
        /// </summary>
        /// <value>
        /// The display name prefix.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string DisplayNamePrefix { get; set; }

        /// <summary>
        /// Gets or sets the surname (family name) of the contact.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the middle name(s) of the contact.
        /// </summary>
        /// <value>
        /// The middle name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the given name (first name) of the contact.
        /// </summary>
        /// <value>
        /// The given name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets the initials of the contact.
        /// </summary>
        /// <value>
        /// The initials.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Initials { get; set; }

        /// <summary>
        /// Gets or sets the full name of the contact.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string DisplayName { get; set; }


        public int OnlineStatusId { get; set; }

        #endregion Contact Name

        #region Electronic Address Properties

        /// <summary>
        /// Gets or sets the user-readable display name for the e-mail address of the contact such as "Home", "Work", "Phone", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Email1DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Email1EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the e-mail address of the contact such as "Home", "Work", "Phone", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Email2DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Email2EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the e-mail address of the contact such as "Home", "Work", "Phone", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Email3DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Email3EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the e-mail address of the contact such as "Home", "Work", "Phone", etc..
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Fax1DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the fax number for the contact.
        /// </summary>
        /// <value>
        /// The fax number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Fax1FaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the e-mail address of the contact such as "Home", "Work", "Phone", etc..
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Fax2DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the fax number for the contact.
        /// </summary>
        /// <value>
        /// The fax number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Fax2FaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the e-mail address of the contact such as "Home", "Work", "Phone", etc..
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Fax3DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the fax number for the contact.
        /// </summary>
        /// <value>
        /// The fax number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Fax3FaxNumber { get; set; }

        #endregion Electronic Address Properties

        #region Physical Address Properties

        /// <summary>
        /// Gets or sets the user-readable display name for the address of the contact such as "Home", "Work", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address1DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the address.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address1AddressStreet { get; set; }
        public string Address1AddressHouseNo { get; set; }
        public string Address1AddressHouseNoExt { get; set; }

        /// <summary>
        /// Gets or sets the second line of the street portion of the address.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address1AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city portion of the address.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address1AddressCity { get; set; }

        /// <summary>
        /// Gets or sets the state or province portion of the address.
        /// </summary>
        /// <value>
        /// The state or province.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address1AddressStateOrProvince { get; set; }

        /// <summary>
        /// Gets or sets the postal code portion of the address.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address1AddressPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country portion of the address.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address1AddressCountry { get; set; }

        /// <summary>
        /// Gets or sets the country/region code portion of the address.
        /// </summary>
        /// <value>
        /// The country/region code.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address1AddressCountryCode { get; set; }

        /// <summary>
        /// Gets or sets the post office box portion of the address.
        /// </summary>
        /// <value>
        /// The post office box.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address1AddressPostOfficeBox { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the address of the contact such as "Home", "Work", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address2DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the address.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address2AddressStreet { get; set; }
        public string Address2AddressHouseNo { get; set; }
        public string Address2AddressHouseNoExt { get; set; }

        /// <summary>
        /// Gets or sets the second line of the street portion of the address.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address2AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city portion of the address.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address2AddressCity { get; set; }

        /// <summary>
        /// Gets or sets the state or province portion of the address.
        /// </summary>
        /// <value>
        /// The state or province.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address2AddressStateOrProvince { get; set; }

        /// <summary>
        /// Gets or sets the postal code portion of the address.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address2AddressPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country portion of the address.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address2AddressCountry { get; set; }

        /// <summary>
        /// Gets or sets the country/region code portion of the address.
        /// </summary>
        /// <value>
        /// The country/region code.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address2AddressCountryCode { get; set; }

        /// <summary>
        /// Gets or sets the post office box portion of the address.
        /// </summary>
        /// <value>
        /// The post office box.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address2AddressPostOfficeBox { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the address of the contact such as "Home", "Work", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address3DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the street portion of the address.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address3AddressStreet { get; set; }
        public string Address3AddressHouseNo { get; set; }
        public string Address3AddressHouseNoExt { get; set; }

        /// <summary>
        /// Gets or sets the second line of the street portion of the address.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address3AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city portion of the address.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address3AddressCity { get; set; }

        /// <summary>
        /// Gets or sets the state or province portion of the address.
        /// </summary>
        /// <value>
        /// The state or province.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address3AddressStateOrProvince { get; set; }

        /// <summary>
        /// Gets or sets the postal code portion of the address.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address3AddressPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country portion of the address.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address3AddressCountry { get; set; }

        /// <summary>
        /// Gets or sets the country/region code portion of the address.
        /// </summary>
        /// <value>
        /// The country/region code.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address3AddressCountryCode { get; set; }

        /// <summary>
        /// Gets or sets the post office box portion of the address.
        /// </summary>
        /// <value>
        /// The post office box.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Address3AddressPostOfficeBox { get; set; }

        #endregion Physical Address Properties

        #region Telephone Properties

        /// <summary>
        /// Gets or sets the user-readable display name for the telephone number of the contact such as "Home", "Work", "Mobile", "Assistant", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone1DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone1TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the telephone number of the contact such as "Home", "Work", "Mobile", "Assistant", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone2DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone2TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the telephone number of the contact such as "Home", "Work", "Mobile", "Assistant", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone3DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone3TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the telephone number of the contact such as "Home", "Work", "Mobile", "Assistant", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone4DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone4TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the telephone number of the contact such as "Home", "Work", "Mobile", "Assistant", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone5DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone5TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the telephone number of the contact such as "Home", "Work", "Mobile", "Assistant", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone6DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone6TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the telephone number of the contact such as "Home", "Work", "Mobile", "Assistant", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone7DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone7TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the telephone number of the contact such as "Home", "Work", "Mobile", "Assistant", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone8DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone8TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the telephone number of the contact such as "Home", "Work", "Mobile", "Assistant", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone9DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone9TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the user-readable display name for the telephone number of the contact such as "Home", "Work", "Mobile", "Assistant", etc.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone10DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the telephone number.
        /// </summary>
        /// <value>
        /// The telephone number.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Telephone10TelephoneNumber { get; set; }

        #endregion Telephone Properties

        #region Event Properties

        /// <summary>
        /// Gets or sets the birthday of the contact.
        /// </summary>
        /// <value>
        /// The birthday.
        /// </value>
        /// <author>Lucas Nodine</author>
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Gets or sets the wedding anniversary of the contact.
        /// </summary>
        /// <value>
        /// The wedding anniversary.
        /// </value>
        /// <author>Lucas Nodine</author>
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Wedding { get; set; }

        #endregion Event Properties

        #region Professional Properties

        /// <summary>
        /// Gets or sets the job title of the contact.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the attorney's bar registration number
        /// </summary>
        /// <value>
        /// The Barnummer.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string BarNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the company that employs the contact.
        /// </summary>
        /// <value>
        /// The name of the company.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the department to which the contact belongs.
        /// </summary>
        /// <value>
        /// The name of the department.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the location of the office that the contact works in.
        /// </summary>
        /// <value>
        /// The office location.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string OfficeLocation { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact's manager.
        /// </summary>
        /// <value>
        /// The name of the manager.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string ManagerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the contact's assistant.
        /// </summary>
        /// <value>
        /// The name of the assistant.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string AssistantName { get; set; }

        /// <summary>
        /// Gets or sets the profession of the contact.
        /// </summary>
        /// <value>
        /// The profession.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Profession { get; set; }

        /// <summary>
        /// Gets or sets the saluation of the contact.
        /// </summary>
        /// <value>
        /// The saluation.
        /// </value>
        /// <author>GJD</author>
        public string Saluation { get; set; }

        #endregion Professional Properties

        #region Other Contact Properties

        /// <summary>
        /// Gets or sets the name of the contact's spouse/partner.
        /// </summary>
        /// <value>
        /// The name of the spouse/partner.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string SpouseName { get; set; }

        /// <summary>
        /// Gets or sets the language that the contact uses.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the contact's instant messaging address.
        /// </summary>
        /// <value>
        /// The instant messaging address.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string InstantMessagingAddress { get; set; }

        /// <summary>
        /// Gets or sets the personal home page URL.
        /// </summary>
        /// <value>
        /// The personal home page.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string PersonalHomePage { get; set; }

        /// <summary>
        /// Gets or sets the business home page URL.
        /// </summary>
        /// <value>
        /// The business home page.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string BusinessHomePage { get; set; }

        /// <summary>
        /// Gets or sets the gender of the contact.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the name of the person who referred this contact.
        /// </summary>
        /// <value>
        /// The referrer.
        /// </value>
        /// <author>Lucas Nodine</author>
        public string ReferredByName { get; set; }

        /// <summary>
        /// Gets or sets the name of the person who referred this contact.
        /// </summary>
        /// <value>
        /// The referrer.
        /// </value>
        /// <author>GJD</author>
        public string IdNumber { get; set; }

        /// <summary>
        /// Gets or sets the name of the person who referred this contact.
        /// </summary>
        /// <value>
        /// The referrer.
        /// </value>
        /// <author>GJD</author>
        public DateTime? IdDateExpiry { get; set; }

        /// <summary>
        /// Gets or sets the name of the person who referred this contact.
        /// </summary>
        /// <value>
        /// The referrer.
        /// </value>
        /// <author>GJD</author>
        public string Nationality { get; set; }

        /// <summary>
        /// Gets or sets the birthcity of this contact.
        /// </summary>
        /// <value>
        /// The BirthCity
        /// </value>
        /// <author>GJD</author>
        public string BirthCity { get; set; }

        /// <summary>
        /// Gets or sets the SSN / BSN.
        /// </summary>
        /// <value>
        /// SSN/BSN
        /// </value>
        /// <author>GJD</author>
        public string SocialSecurityNumber { get; set; }

        /// <summary>
        /// Gets or sets the Visumnumber / Vreemdelingennummer
        /// </summary>
        /// <value>
        /// VisaNumber
        /// </value>
        /// <author>GJD</author>
        public string VNumber { get; set; }

        #endregion Other Contact Properties

        #region Contact Bank details

        /// <summary>
        /// Gets or sets the Bankaccount nummer
        /// </summary>
        /// <value>
        /// BankAccount
        /// </value>
        /// <author>GJD</author>
        public string BankAccount { get; set; }

        /// <summary>
        /// Gets or sets the BIC/Swift number
        /// </summary>
        /// <value>
        /// BIC
        /// </value>
        /// <author>GJD</author>
        public string BicCode { get; set; }

        /// <summary>
        /// Gets or sets the BankName
        /// </summary>
        /// <value>
        /// BankName
        /// </value>
        /// <author>GJD</author>
        public string BankName { get; set; }

        /// <summary>
        /// Gets or sets the sepamandatenumber for automatic payments
        /// </summary>
        /// <value>
        /// SepaMandateNumber
        /// </value>
        /// <author>GJD</author>
        public string SepaMandateNumber { get; set; }

        /// <summary>
        /// Gets or sets the SepaMandateDate , the startdate of the mandate
        /// </summary>
        /// <value>
        /// SepaMandateDate
        /// </value>
        /// <author>GJD</author>
        public DateTime? SepaMandateDate { get; set; }

        /// <summary>
        /// Gets or sets the SEPA mandate limit (in currency)
        /// </summary>
        /// <value>
        /// SepaMandateLimit
        /// </value>
        /// <author>GJD</author>
        public int SepaMandateLimit { get; set; }

        #endregion

        #region CompanyDetails

        /// <summary>
        /// Gets or sets the Companies Taxnumber (RSIN)
        /// </summary>
        /// <value>
        /// TaxNumber
        /// </value>
        /// <author>GJD</author>
        public string TaxNumber { get; set; }

        /// <summary>
        /// Gets or sets the Companies VAT ID / BTW number (required for EU invoicing)
        /// </summary>
        /// <value>
        /// VatId
        /// </value>
        /// <author>GJD</author>
        public string VatId { get; set; }

        /// <summary>
        /// Gets or sets the Companies SBI code - required for CRM usage
        /// </summary>
        /// <value>
        /// SbiCode
        /// </value>
        /// <author>GJD</author>
        public string SbiCode { get; set; }

        /// <summary>
        /// Gets or sets the Companies businessregistration / KVK nummer - required for CRM usage
        /// </summary>
        /// <value>
        /// BusinessRegistration
        /// </value>
        /// <author>GJD</author>
        public string BusinessRegistration { get; set; }

        /// <summary>
        /// Gets or sets the Companies dateofincorporation - oprichtingsdatum - required for CRM usage
        /// </summary>
        /// <value>
        /// DateOfIncorporation
        /// </value>
        /// <author>GJD</author>
        public DateTime? DateOfIncorporation { get; set; }

        /// <summary>
        /// Gets or sets the Companies legalform - rechtsvorm for crm usage
        /// </summary>
        /// <value>
        /// LegalForm
        /// </value>
        /// <author>GJD</author>
        public string LegalForm { get; set; }

        /// <summary>
        /// Gets or sets the Companies number of employees for crm usage (dropdown - 0, 1, 2-10, 10-50, 50-250, 250-500, 500+)
        /// </summary>
        /// <value>
        /// NumEmployees
        /// </value>
        /// <author>GJD</author>
        public int NumEmployees { get; set; }

        /// <summary>
        /// Gets or sets the Companies annual turnover / jaaromzet
        /// </summary>
        /// <value>
        /// TurnOver
        /// </value>
        /// <author>GJD</author>
        public int TurnOver { get; set; }

        /// <summary>
        /// Gets or sets the Companies website
        /// </summary>
        /// <value>
        /// WebSite
        /// </value>
        /// <author>GJD</author>
        public string Website { get; set; }

        #endregion

        public int? BillingRateId { get; set; } = null;

        /// <summary>
        /// Gets or sets the civilstatus / burgelijkestaat of this contact.
        /// </summary>
        /// <value>
        /// The Civil/Maritial status.
        /// </value>
        /// <author>GJD</author>
        public int? CivilStatusId { get; set; } = null;

        public int? IdTypeId { get; set; } = null;

        public int? CompanyLegalStatusId { get; set; } = null;
    }
}
