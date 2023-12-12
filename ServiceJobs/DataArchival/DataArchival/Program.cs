using ServiceJob.Interfaces;

IService service = new DataArchival.DataArchival();
service.StartProcess(args);