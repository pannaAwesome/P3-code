﻿ALTER TABLE [dbo].[CompanyCode]  WITH CHECK ADD  CONSTRAINT [FK__Company__Count__440B1D61] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Country] ([ID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CompanyCode] CHECK CONSTRAINT [FK__Company__Count__440B1D61]