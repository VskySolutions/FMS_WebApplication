DECLARE @Counter INT = 1;

WHILE @Counter <= 1000
BEGIN
    INSERT INTO [dbo].[Contact] (
        [Id],
        [FirstName],
        [LastName],
        [Email],
        [Phone],
        [Fax],
        [Address1],
        [Address2],
        [City],
        [CountryId],
        [StateProvinceId],
        [County],
        [ZipCode],
        [CreatedById],
        [CreatedOnUtc],
        [UpdatedById],
        [UpdatedOnUtc],
        [Active],
        [Deleted]
    )
    VALUES
    (
        NEWID(), -- Generates a new uniqueidentifier for each record
        N'John' + CAST(@Counter AS NVARCHAR(5)), -- First name with counter
        N'Doe', -- Last name
        N'johndoe' + CAST(@Counter AS NVARCHAR(5)) + N'@example.com', -- Email with counter
        N'123-456-7890', -- Phone
        N'123-456-7891', -- Fax
        N'123 Main St', -- Address1
        N'Apt ' + CAST(@Counter AS NVARCHAR(5)), -- Address2 with counter
        N'Anytown', -- City
        N'6C541A72-E1AC-4A84-9611-6A2655ADE639', -- CountryId
        N'DBFD4566-4B0E-4C23-9530-FB00358EC034', -- StateProvinceId
        N'AnyCounty', -- County
        N'12345', -- ZipCode
        N'E434CC54-A37B-4309-A53F-DD4E4B0A673A', -- CreatedById
        SYSDATETIME(), -- CreatedOnUtc
        NULL, -- UpdatedById, assuming it's NULL because the record is newly created
        NULL, -- UpdatedOnUtc, assuming it's NULL because the record is newly created
        1, -- Active
        0  -- Deleted
    );

    SET @Counter = @Counter + 1;
END;
GO
