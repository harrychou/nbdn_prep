use [nothinbutdotnetprep]
GO
if not exists (select * from dbo.sysusers where name = N'HARRYNB\ASPNet' and uid < 16382)
	EXEC sp_grantdbaccess N'HARRYNB\ASPNet', N'HARRYNB\ASPNet'
GO

if not exists (select * from dbo.sysusers where name = N'WebUser' and uid > 16399)
	EXEC sp_addrole N'WebUser'
GO

exec sp_addrolemember N'WebUser', N'HARRYNB\ASPNet'
GO
