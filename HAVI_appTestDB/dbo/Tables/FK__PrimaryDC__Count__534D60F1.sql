﻿ALTER TABLE [dbo].[PrimaryDCILOSCode]  WITH CHECK ADD  CONSTRAINT [FK__PrimaryDC__Count__534D60F1] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[PrimaryDCILOSCode] CHECK CONSTRAINT [FK__PrimaryDC__Count__534D60F1]