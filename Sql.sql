

	USE master
	GO	

	CREATE DATABASE demoCRUD
	GO	
	USE demoCRUD
	GO	
	CREATE TABLE tbl_Employee
	(
		Sr_no INT PRIMARY KEY IDENTITY,
		Emp_name NVARCHAR(500),
		City NVARCHAR(500),
		STATE NVARCHAR(500),
		Country NVARCHAR(500),
		Department NVARCHAR(500),
		flag NVARCHAR(500)

	)

	GO	
	CREATE PROC Sp_Employee
		@Sr_no INT,
		@Emp_name NVARCHAR(500),
		@City NVARCHAR(500),
		@STATE NVARCHAR(500),
		@Country NVARCHAR(500),
		@Department NVARCHAR(500),
		@flag NVARCHAR(500)
	AS
    BEGIN
    	IF(@flag = 'insert')
		BEGIN
			INSERT dbo.tbl_Employee( Sr_no ,Emp_name , City ,STATE ,Country ,Department )
			VALUES  ( @Sr_no,@Emp_name,@City,@STATE,@Country,@Department)
		END
		ELSE IF(@flag ='update')
		BEGIN
			UPDATE dbo.tbl_Employee SET Emp_name=@Emp_name , City=@City ,STATE=@STATE ,Country=@Country ,Department=@Department
			WHERE @Sr_no=Sr_no
		END
		ELSE IF(@flag ='delete')
		BEGIN
			DELETE dbo.tbl_Employee WHERE @Sr_no=Sr_no
		END
		ELSE IF(@flag = 'getid')
		BEGIN
			SELECT *FROM dbo.tbl_Employee WHERE @Sr_no=Sr_no
		END
		ELSE IF(@flag ='get')
		BEGIN
			SELECT * FROM dbo.tbl_Employee
		END

    END
	GO	
	EXEC dbo.Sp_Employee @Sr_no = 0, -- int
	    @Emp_name = N'', -- nvarchar(500)
	    @City = N'', -- nvarchar(500)
	    @STATE = N'', -- nvarchar(500)
	    @Country = N'', -- nvarchar(500)
	    @Department = N'', -- nvarchar(500)
	    @flag = N'get' -- nvarchar(500)
	

