INSERT INTO Users (
            Id,
            Email,
            Password,
            FirstName,
            LastName,
            Phone,
            Role,
            JoinedDate,
            CreatedDate,
            UpdatedDate,
            DeletedDate
      )
VALUES (
            'c0a80123-4567-8901-2345-678901234567',
            -- Replace with a valid UUID
            'Bishoy.ashraf.a046@gmail.com',
            'P@ssword123',
            'Beshoy',
            'Ashraf',
            '01271290305',
            'Admin',
            NOW(),
            NOW(),
            NOW(),
            NULL
      );