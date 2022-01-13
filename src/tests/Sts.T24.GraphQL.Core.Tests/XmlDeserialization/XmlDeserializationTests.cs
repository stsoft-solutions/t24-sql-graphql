using System;
using System.IO;
using System.Xml.Serialization;
using Sts.T24.GraphQL.Core.Model;
using Xunit;

namespace Sts.T24.GraphQL.Core.Tests.XmlDeserialization;

public class XmlDeserializationTests
{
    [Fact]
    public void StandardSelectionTest()
    {
        var xml = @"
            <row id=""STS.DBI.DEPOSIT"" xml:space=""preserve"">
                <c1>@ID</c1>
                <c1 m=""2"">ID</c1>
                <c1 m=""3"">STATUS</c1>
                <c1 m=""4"">CUSTOMER.ID</c1>
                <c1 m=""5"">DRAWDOWN.ACCOUNT</c1>
                <c1 m=""6"">AMOUNT</c1>
                <c1 m=""7"">INTEREST.RATE</c1>
                <c1 m=""8"">DEPOSIT.ID</c1>
                <c1 m=""9"">LOCAL.REF</c1>
                <c1 m=""10"">RESERVED.3</c1>
                <c1 m=""11"">RESERVED.2</c1>
                <c1 m=""12"">RESERVED.1</c1>
                <c1 m=""13"">RECORD.STATUS</c1>
                <c1 m=""14"">CURR.NO</c1>
                <c1 m=""15"">INPUTTER</c1>
                <c1 m=""16"">DATE.TIME</c1>
                <c1 m=""17"">AUTHORISER</c1>
                <c1 m=""18"">CO.CODE</c1>
                <c1 m=""19"">DEPT.CODE</c1>
                <c1 m=""20"">AUDITOR.CODE</c1>
                <c1 m=""21"">AUDIT.DATE.TIME</c1>
                <c1 m=""22"">CURRENCY</c1>
                <c1 m=""23"">PYI.DATE</c1>
                <c1 m=""24"">PYI.AMOUNT</c1>
                <c1 m=""25"">PYI.CURRENCY</c1>
                <c1 m=""26"">PYI.DETAILS</c1>
                <c1 m=""27"">PYI.FT.ID</c1>
                <c1 m=""28"">MAT.START.DATE</c1>
                <c1 m=""29"">MAT.END.DATE</c1>
                <c1 m=""30"">MAT.PRLNG.CASE</c1>
                <c1 m=""31"">MAT.SRC.TAX.APPL</c1>
                <c1 m=""32"">VALUE.DATE</c1>
                <c1 m=""33"">MATURITY.DATE</c1>
                <c1 m=""34"">EXTERNAL.ID</c1>
                <c1 m=""35"">EXTERNAL.IBAN</c1>
                <c1 m=""36"">MAT.PRLNG.DEP.ID</c1>
                <c1 m=""37"">PLACEMENT.AMOUNT</c1>
                <c1 m=""38"">PLACEMENT.EXCH.RATE</c1>
                <c2>D</c2>
                <c2 m=""2"">D</c2>
                <c2 m=""3"">D</c2>
                <c2 m=""4"">D</c2>
                <c2 m=""5"">D</c2>
                <c2 m=""6"">D</c2>
                <c2 m=""7"">D</c2>
                <c2 m=""8"">D</c2>
                <c2 m=""9"">D</c2>
                <c2 m=""10"">D</c2>
                <c2 m=""11"">D</c2>
                <c2 m=""12"">D</c2>
                <c2 m=""13"">D</c2>
                <c2 m=""14"">D</c2>
                <c2 m=""15"">D</c2>
                <c2 m=""16"">D</c2>
                <c2 m=""17"">D</c2>
                <c2 m=""18"">D</c2>
                <c2 m=""19"">D</c2>
                <c2 m=""20"">D</c2>
                <c2 m=""21"">D</c2>
                <c2 m=""22"">D</c2>
                <c2 m=""23"">D</c2>
                <c2 m=""24"">D</c2>
                <c2 m=""25"">D</c2>
                <c2 m=""26"">D</c2>
                <c2 m=""27"">D</c2>
                <c2 m=""28"">D</c2>
                <c2 m=""29"">D</c2>
                <c2 m=""30"">D</c2>
                <c2 m=""31"">D</c2>
                <c2 m=""32"">D</c2>
                <c2 m=""33"">D</c2>
                <c2 m=""34"">D</c2>
                <c2 m=""35"">D</c2>
                <c2 m=""36"">D</c2>
                <c2 m=""37"">D</c2>
                <c2 m=""38"">D</c2>
                <c3>0</c3>
                <c3 m=""2"">0</c3>
                <c3 m=""3"">1</c3>
                <c3 m=""4"">3</c3>
                <c3 m=""5"">4</c3>
                <c3 m=""6"">6</c3>
                <c3 m=""7"">8</c3>
                <c3 m=""8"">9</c3>
                <c3 m=""9"">22</c3>
                <c3 m=""10"">25</c3>
                <c3 m=""11"">26</c3>
                <c3 m=""12"">27</c3>
                <c3 m=""13"">28</c3>
                <c3 m=""14"">29</c3>
                <c3 m=""15"">30</c3>
                <c3 m=""16"">31</c3>
                <c3 m=""17"">32</c3>
                <c3 m=""18"">33</c3>
                <c3 m=""19"">34</c3>
                <c3 m=""20"">35</c3>
                <c3 m=""21"">36</c3>
                <c3 m=""22"">7</c3>
                <c3 m=""23"">12</c3>
                <c3 m=""24"">13</c3>
                <c3 m=""25"">14</c3>
                <c3 m=""26"">15</c3>
                <c3 m=""27"">16</c3>
                <c3 m=""28"">17</c3>
                <c3 m=""29"">18</c3>
                <c3 m=""30"">19</c3>
                <c3 m=""31"">21</c3>
                <c3 m=""32"">10</c3>
                <c3 m=""33"">11</c3>
                <c3 m=""34"">2</c3>
                <c3 m=""35"">5</c3>
                <c3 m=""36"">20</c3>
                <c3 m=""37"">23</c3>
                <c3 m=""38"">24</c3>
                <c4>IN2A</c4>
                <c4 m=""2"">IN2A</c4>
                <c4 m=""3"">IN2&amp;NEW_COMPLIANCE.CHECKING_COMPLIANCE.ACCEPTED_COMPLIANCE.REJECTED_LD.CREATED_LD.OPENED_REVOKED_MANUAL.CHECKING_MATURED_MATURITY.REMINDED_PROLONGATION.ORDERED</c4>
                <c4 m=""4"">IN2CUS</c4>
                <c4 m=""5"">IN2ANT</c4>
                <c4 m=""6"">IN2AMT</c4>
                <c4 m=""7"">IN2R</c4>
                <c4 m=""8"">IN2A</c4>
                <c4 m=""9"">IN2A</c4>
                <c4 m=""10"">IN2&amp;&amp;NOINPUT</c4>
                <c4 m=""11"">IN2&amp;&amp;NOINPUT</c4>
                <c4 m=""12"">IN2&amp;&amp;NOINPUT</c4>
                <c4 m=""13"">IN2A</c4>
                <c4 m=""14"">IN2</c4>
                <c4 m=""15"">IN2A</c4>
                <c4 m=""16"">IN2</c4>
                <c4 m=""17"">IN2A</c4>
                <c4 m=""18"">IN2A</c4>
                <c4 m=""19"">IN2A</c4>
                <c4 m=""20"">IN2A</c4>
                <c4 m=""21"">IN2</c4>
                <c4 m=""22"">IN2CCY</c4>
                <c4 m=""23"">IN2D</c4>
                <c4 m=""24"">IN2AMT</c4>
                <c4 m=""25"">IN2CCY</c4>
                <c4 m=""26"">IN2A</c4>
                <c4 m=""27"">IN2A</c4>
                <c4 m=""28"">IN2D</c4>
                <c4 m=""29"">IN2D</c4>
                <c4 m=""30"">IN2&amp;PRLCAP_PRLNOCAP</c4>
                <c4 m=""31"">IN2&amp;YES_</c4>
                <c4 m=""32"">IN2D</c4>
                <c4 m=""33"">IN2D</c4>
                <c4 m=""34"">IN2A</c4>
                <c4 m=""35"">IN2A</c4>
                <c4 m=""36"">IN2A</c4>
                <c4 m=""37"">IN2AMT</c4>
                <c4 m=""38"">IN2R</c4>
                <c5 m=""36"" />
                <c6>35L</c6>
                <c6 m=""2"">35L</c6>
                <c6 m=""3"">35L</c6>
                <c6 m=""4"">10R</c6>
                <c6 m=""5"">19L</c6>
                <c6 m=""6"">19R</c6>
                <c6 m=""7"">12R</c6>
                <c6 m=""8"">35L</c6>
                <c6 m=""9"">35L</c6>
                <c6 m=""10"">35R</c6>
                <c6 m=""11"">35R</c6>
                <c6 m=""12"">35R</c6>
                <c6 m=""13"">4L</c6>
                <c6 m=""14"">4R</c6>
                <c6 m=""15"">40L</c6>
                <c6 m=""16"">15R</c6>
                <c6 m=""17"">40L</c6>
                <c6 m=""18"">11L</c6>
                <c6 m=""19"">4L</c6>
                <c6 m=""20"">16L</c6>
                <c6 m=""21"">15R</c6>
                <c6 m=""22"">3L</c6>
                <c6 m=""23"">11R</c6>
                <c6 m=""24"">19R</c6>
                <c6 m=""25"">3L</c6>
                <c6 m=""26"">255L</c6>
                <c6 m=""27"">35L</c6>
                <c6 m=""28"">11R</c6>
                <c6 m=""29"">11R</c6>
                <c6 m=""30"">35L</c6>
                <c6 m=""31"">3L</c6>
                <c6 m=""32"">11R</c6>
                <c6 m=""33"">11R</c6>
                <c6 m=""34"">35L</c6>
                <c6 m=""35"">35L</c6>
                <c6 m=""36"">35L</c6>
                <c6 m=""37"">19R</c6>
                <c6 m=""38"">12R</c6>
                <c7>N</c7>
                <c7 m=""2"">N</c7>
                <c7 m=""3"">N</c7>
                <c7 m=""4"">N</c7>
                <c7 m=""5"">N</c7>
                <c7 m=""6"">N</c7>
                <c7 m=""7"">N</c7>
                <c7 m=""8"">N</c7>
                <c7 m=""9"">N</c7>
                <c7 m=""10"">N</c7>
                <c7 m=""11"">N</c7>
                <c7 m=""12"">N</c7>
                <c7 m=""13"">N</c7>
                <c7 m=""14"">N</c7>
                <c7 m=""15"">N</c7>
                <c7 m=""16"">N</c7>
                <c7 m=""17"">N</c7>
                <c7 m=""18"">N</c7>
                <c7 m=""19"">N</c7>
                <c7 m=""20"">N</c7>
                <c7 m=""21"">N</c7>
                <c7 m=""22"">N</c7>
                <c7 m=""23"">N</c7>
                <c7 m=""24"">N</c7>
                <c7 m=""25"">N</c7>
                <c7 m=""26"">N</c7>
                <c7 m=""27"">N</c7>
                <c7 m=""28"">N</c7>
                <c7 m=""29"">N</c7>
                <c7 m=""30"">N</c7>
                <c7 m=""31"">N</c7>
                <c7 m=""32"">N</c7>
                <c7 m=""33"">N</c7>
                <c7 m=""34"">N</c7>
                <c7 m=""35"">N</c7>
                <c7 m=""36"">N</c7>
                <c7 m=""37"">N</c7>
                <c7 m=""38"">N</c7>
                <c8 m=""38"" />
                <c9 m=""38"" />
                <c10>S</c10>
                <c10 m=""2"">S</c10>
                <c10 m=""3"">S</c10>
                <c10 m=""4"">S</c10>
                <c10 m=""5"">S</c10>
                <c10 m=""6"">S</c10>
                <c10 m=""7"">S</c10>
                <c10 m=""8"">S</c10>
                <c10 m=""9"">M</c10>
                <c10 m=""10"">S</c10>
                <c10 m=""11"">S</c10>
                <c10 m=""12"">S</c10>
                <c10 m=""13"">S</c10>
                <c10 m=""14"">S</c10>
                <c10 m=""15"">M</c10>
                <c10 m=""16"">M</c10>
                <c10 m=""17"">S</c10>
                <c10 m=""18"">S</c10>
                <c10 m=""19"">S</c10>
                <c10 m=""20"">S</c10>
                <c10 m=""21"">S</c10>
                <c10 m=""22"">S</c10>
                <c10 m=""23"">M</c10>
                <c10 m=""24"">M</c10>
                <c10 m=""25"">M</c10>
                <c10 m=""26"">M</c10>
                <c10 m=""27"">M</c10>
                <c10 m=""28"">S</c10>
                <c10 m=""29"">S</c10>
                <c10 m=""30"">S</c10>
                <c10 m=""31"">S</c10>
                <c10 m=""32"">S</c10>
                <c10 m=""33"">S</c10>
                <c10 m=""34"">S</c10>
                <c10 m=""35"">S</c10>
                <c10 m=""36"">S</c10>
                <c10 m=""37"">S</c10>
                <c10 m=""38"">S</c10>
                <c11>N</c11>
                <c11 m=""2"">N</c11>
                <c11 m=""3"">N</c11>
                <c11 m=""4"">N</c11>
                <c11 m=""5"">N</c11>
                <c11 m=""6"">N</c11>
                <c11 m=""7"">N</c11>
                <c11 m=""8"">N</c11>
                <c11 m=""9"">N</c11>
                <c11 m=""10"">N</c11>
                <c11 m=""11"">N</c11>
                <c11 m=""12"">N</c11>
                <c11 m=""13"">N</c11>
                <c11 m=""14"">N</c11>
                <c11 m=""15"">N</c11>
                <c11 m=""16"">N</c11>
                <c11 m=""17"">N</c11>
                <c11 m=""18"">N</c11>
                <c11 m=""19"">N</c11>
                <c11 m=""20"">N</c11>
                <c11 m=""21"">N</c11>
                <c11 m=""22"">N</c11>
                <c11 m=""23"">N</c11>
                <c11 m=""24"">N</c11>
                <c11 m=""25"">N</c11>
                <c11 m=""26"">N</c11>
                <c11 m=""27"">N</c11>
                <c11 m=""28"">N</c11>
                <c11 m=""29"">N</c11>
                <c11 m=""30"">N</c11>
                <c11 m=""31"">N</c11>
                <c11 m=""32"">N</c11>
                <c11 m=""33"">N</c11>
                <c11 m=""34"">N</c11>
                <c11 m=""35"">N</c11>
                <c11 m=""36"">N</c11>
                <c11 m=""37"">N</c11>
                <c11 m=""38"">N</c11>
                <c12>Y</c12>
                <c12 m=""2"">Y</c12>
                <c12 m=""3"">Y</c12>
                <c12 m=""4"">Y</c12>
                <c12 m=""5"">Y</c12>
                <c12 m=""6"">Y</c12>
                <c12 m=""7"">Y</c12>
                <c12 m=""8"">Y</c12>
                <c12 m=""9"">Y</c12>
                <c12 m=""10"">Y</c12>
                <c12 m=""11"">Y</c12>
                <c12 m=""12"">Y</c12>
                <c12 m=""13"">Y</c12>
                <c12 m=""14"">Y</c12>
                <c12 m=""15"">Y</c12>
                <c12 m=""16"">Y</c12>
                <c12 m=""17"">Y</c12>
                <c12 m=""18"">Y</c12>
                <c12 m=""19"">Y</c12>
                <c12 m=""20"">Y</c12>
                <c12 m=""21"">Y</c12>
                <c12 m=""22"">Y</c12>
                <c12 m=""23"">Y</c12>
                <c12 m=""24"">Y</c12>
                <c12 m=""25"">Y</c12>
                <c12 m=""26"">Y</c12>
                <c12 m=""27"">Y</c12>
                <c12 m=""28"">Y</c12>
                <c12 m=""29"">Y</c12>
                <c12 m=""30"">Y</c12>
                <c12 m=""31"">Y</c12>
                <c12 m=""32"">Y</c12>
                <c12 m=""33"">Y</c12>
                <c12 m=""34"">Y</c12>
                <c12 m=""35"">Y</c12>
                <c12 m=""36"">Y</c12>
                <c12 m=""37"">Y</c12>
                <c12 m=""38"">Y</c12>
                <c13 m=""5"">ACCOUNT</c13>
                <c13 m=""38"" />
                <c14 m=""4"">CUSTOMER</c14>
                <c14 m=""5"">ACCOUNT</c14>
                <c14 m=""18"">COMPANY</c14>
                <c14 m=""19"">DEPT.ACCT.OFFICER</c14>
                <c14 m=""22"">CURRENCY</c14>
                <c14 m=""25"">CURRENCY</c14>
                <c14 m=""38"" />
                <c15>STS.DEP.TERM</c15>
                <c16>I</c16>
                <c17>LOCAL.REF&lt;1,1&gt;</c17>
                <c18>IN2A</c18>
                <c20>7L</c20>
                <c24>S</c24>
                <c25>N</c25>
                <c27>STS.TERMS</c27>
                <c35>6</c35>
                <c36>19953__I_INAU_OFS_BUILD.CONTROL</c36>
                <c36 m=""2"">1_DL.RESTORE</c36>
                <c37>1907310939</c37>
                <c37 m=""2"">1907310939</c37>
                <c37 m=""3"">1907310938</c37>
                <c38>19953__OFS_BUILD.CONTROL</c38>
                <c39>STS0019999</c39>
                <c40>18</c40>
              </row>
        ";

        var serializer = new XmlSerializer(typeof(StandardSelectionXmlRecord));
        using var reader = new StringReader(xml);
        var standardSelection = (StandardSelectionXmlRecord) serializer.Deserialize(reader)!;
        Assert.IsType<StandardSelectionXmlRecord>(standardSelection);
        Assert.Equal("STS.DBI.DEPOSIT", standardSelection.Id);
        Assert.Equal("CUSTOMER.ID", standardSelection.Names[3].Value);
    }

    [Fact]
    public void DbiManualTest()
    {
        var xml = @"
            <row id=""FDA111300001589"" xml:space=""preserve"">
              <c1>MATURED</c1>
              <c2>FDA\x5F111\x5F300\x5F001\x5F589</c2>
              <c3>3434</c3>
              <c4>003434001</c4>
              <c5>DE46503302002043800003</c5>
              <c6>100000.00</c6>
              <c7>EUR</c7>
              <c8>1.10</c8>
              <c9>LD1814900002</c9>
              <c10>20180529</c10>
              <c11>20200528</c11>
              <c12>20180528</c12>
              <c12 m=""2"">20180529</c12>
              <c13>100000.00</c13>
              <c13 m=""2"">100000.00</c13>
              <c14>EUR</c14>
              <c14 m=""2"">EUR</c14>
              <c15>PYI 1,10%, 24 month(s), 100000,00 EUR,FDA\x5F111\x5F300\x5F001\x5F589,</c15>
              <c15 m=""2"">PYI 1,10 , 24 month(s), 100000,00 EUR,FDA 111 300 001 589,</c15>
              <c16 m=""2"">FT1814931161</c16>
              <c17>20180529</c17>
              <c18>20200528</c18>
              <c22>24Month</c22>
              <c29>11</c29>
              <c30>583_INPUTTER_A_</c30>
              <c30 m=""2"">41_BIZTALK_I_INAU_OFS_TWS.DBI</c30>
              <c31>2005272147</c31>
              <c31 m=""2"">2005240415</c31>
              <c31 m=""3"">2005240415</c31>
              <c32>41_BIZTALK_OFS_TWS.DBI</c32>
              <c33>COMPANYCODE</c33>
              <c34>18</c34>
            </row>
        ";

        var serializer = new XmlSerializer(typeof(DbiFakeXmlRecord));
        using var reader = new StringReader(xml);
        var dbiXmlRecord = (DbiFakeXmlRecord) serializer.Deserialize(reader)!;
        Assert.IsType<DbiFakeXmlRecord>(dbiXmlRecord);
        Assert.Equal("FDA111300001589", dbiXmlRecord.Id);
        Assert.Equal("MATURED", dbiXmlRecord.Status.Value);
        Assert.Equal(1.1m, dbiXmlRecord.Rate.Value);
        Assert.Equal(100000, dbiXmlRecord.PyiAmount[0].Value);
        Assert.Equal(1, dbiXmlRecord.PyiAmount[0].MultiValueIndex);
        Assert.Equal(100000, dbiXmlRecord.PyiAmount[1].Value);
        Assert.Equal(2, dbiXmlRecord.PyiAmount[1].MultiValueIndex);
        Assert.Equal(new DateTime(2018, 5, 29), dbiXmlRecord.ValueDate.Value);
        Assert.Equal(DateTime.MinValue, dbiXmlRecord.UnExistingDateField.Value);
        Assert.False(dbiXmlRecord.UnExistingDateField.IsValueExist);
    }
}