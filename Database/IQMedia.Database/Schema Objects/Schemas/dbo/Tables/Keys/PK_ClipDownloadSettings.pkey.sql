﻿ALTER TABLE [dbo].[ClipDownloadSettings]
    ADD CONSTRAINT [PK_ClipDownloadSettings] PRIMARY KEY CLUSTERED ([IQ_ClipDownloadSettings_Key] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
