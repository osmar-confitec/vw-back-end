  update 
  [volkscalls].[dbo].[TblCallsCategory] set CIId = 
	(select top 1 id  from [volkscalls].[dbo].[CI] 
	where [volkscalls].[dbo].[CI].[ciname] =  REPLACE([volkscalls].[dbo].[TblCallsCategory].[description] ,'#','') )
	where [volkscalls].[dbo].[TblCallsCategory].Level in(5)