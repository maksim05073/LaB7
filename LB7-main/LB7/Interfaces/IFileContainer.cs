namespace LB7;

public interface IFileContainer<Device>:IContainer<Device>
{
    void Save( String fileName );
    void Load( String fileName );
    Boolean IsDataSaved {get;}
}