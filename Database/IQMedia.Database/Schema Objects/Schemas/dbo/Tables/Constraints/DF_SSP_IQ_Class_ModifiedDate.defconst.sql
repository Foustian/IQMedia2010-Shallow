﻿ALTER TABLE [dbo].[SSP_IQ_Class] ADD  CONSTRAINT [DF_SSP_IQ_Class_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]