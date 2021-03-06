USE [ECommerce]
GO
/****** Object:  StoredProcedure [dbo].[UpsertUsermachineInfo]    Script Date: 16-04-2021 12:12:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Antony Lineesh
-- Create date:  14-04-2021
-- =============================================
ALTER   PROCEDURE [dbo].[UpsertUsermachineInfo] 
	@Email varchar(50),
	@MacAddress varchar(150)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @EmailTmp varchar(100);
	DECLARE @UserMachineInfoIdTmp int;
	DECLARE @UserIdTmp int;
	DECLARE @MacAddressTmp varchar(100);


	CREATE table #ResultSet
	(
		Status varchar(100),
		Message varchar(100)	
	)

	select @EmailTmp=Email,@UserMachineInfoIdTmp= um.Id,@UserIdTmp=u.Id,@MacAddressTmp=MacAdress 
	from Users u  with (nolock)   left join UserMachines um with (nolock) on u.Id=um.UserId
	where u.Email=@Email;

if (@EmailTmp is null)
	begin		
		--user is not yet registered in the system
		INSERT INTO #ResultSet values('Failed','User is not available in the system');
	end
else
	begin
		if(@UserMachineInfoIdTmp is null)
			begin
				--user is not registered in the system but user's machine info not yet created so create the machine info
				insert into UserMachines(UserId,MacAdress,LastUpdated,TrustStatus) values (@UserIdTmp,@MacAddress,GETUTCDATE(),1);
				INSERT INTO #ResultSet values('Success','User''s machine info created succesfully');
			end
		else
			begin
				if(@MacAddressTmp <> @MacAddress)
					begin
						--user is login with another machine
						UPDATE UserMachines set TrustStatus=2,LastUpdated=GETUTCDATE() where Id=@UserMachineInfoIdTmp;
						INSERT INTO #ResultSet values('Failed','User is logging from another machine');
					end
				else
					begin
						UPDATE UserMachines set TrustStatus=1,LastUpdated=GETUTCDATE() where Id=@UserMachineInfoIdTmp;								
						INSERT INTO #ResultSet values('Success','User''s machine info has been updated ');
					end
			end
	end
end
select * from #ResultSet
