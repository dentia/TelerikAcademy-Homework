<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >
  
  <xsl:template match="/">
    <html>
      <style>
        table {
          font-size: 20px;
          text-align: center;
        }
        
        th, td {
          padding: 5px;
        }
      </style>
      
      <body>
        <table border="1">
          <tr bgcolor="#9acd32" style="font-size:1.1em">
            <th>Student</th>
            <th>Gender</th>
            <th>Birth Date</th>
            <th>Phone</th>
            <th>E-mail</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty #</th>
            <th>Exams</th>
          </tr>
          <xsl:for-each select="students/student">
            <tr>
              <td>
                <xsl:value-of select="name" />
              </td>
              <td>
                <xsl:value-of select="sex" />
              </td>
              <td>
                <xsl:value-of select="birthDate" />
              </td>
              <td>
                <xsl:value-of select="phone" />
              </td>
              <td>
                <xsl:value-of select="email" />
              </td>
              <td>
                <xsl:value-of select="course" />
              </td>
              <td>
                <xsl:value-of select="specialty" />
              </td>
              <td>
                <xsl:value-of select="facultyNumber" />
              </td>
              <td>
                <xsl:for-each select="exams/exam">
                  <div>
                    <strong>
                      <xsl:value-of select="name"/>
                    </strong> /
                    tutor: <xsl:value-of select="tutor"/> /
                    score: <xsl:value-of select="score"/>
                  </div>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
