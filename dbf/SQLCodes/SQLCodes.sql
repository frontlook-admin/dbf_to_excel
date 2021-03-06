﻿/*Code 1*/

SELECT smast.SDES as SDES,bill.DT,billmed.VNO,billmed.BATCH,billmed.EXPDT, bill.MPT,aconf.ADD1,aconf.ADD2,aconf.ADD3,
(SELECT smast.SDES FROM [smast],[bill] WHERE bill.LCOD=smast.SCOD AND bill.VNO='00534' AND bill.MPT='M') AS TRANSPORT_SDES 
FROM 
[billmed],[bill],[smast],[aconf] WHERE billmed.VNO = bill.VNO AND bill.SCOD=smast.SCOD AND bill.MPT='M' AND bill.SCOD=aconf.GCOD
AND 
bill.VNO='00534';
 



/*Code 2*/

SELECT TXN.VNO, TXN.CBCOD, SMAST.SDES, GLMAST.GDES,ACONF.ADD1,ACONF.ADD2,ACONF.ADD3,TXN.AMT,TXN.DT,SMAST.AADHAR,ACONF.PARTY_IT as PAN
FROM 
((TXN 
LEFT JOIN SMAST ON SMAST.SCOD = TXN.SCOD)  
LEFT JOIN GLMAST ON GLMAST.GCOD = TXN.GCOD) 
LEFT JOIN (SELECT * FROM  ACONF WHERE ACONF.TYPE = 'S') as filteredACONF ON TXN.SCOD = filteredACONF.GCOD


/*Code 3*/
SELECT 'Ace5'+CCOD as CCOD, CNAME as CNAME,DT1,DT2,DATAPATH FROM `COMP` WHERE DT1 IS NOT null OR DT2 IS NOT NULL