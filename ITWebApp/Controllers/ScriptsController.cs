using Infrastructure;
using ITWebApp.Features.GetUsers;
using ITWebApp.Features.Scripts;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITWebApp.Controllers
{
    public class ScriptsController
    {
        private readonly IAsyncRequestHandler<GetScriptsByDeviceTypeRequest, List<ScriptsDto>> _listScriptsHandler;
        private readonly IAsyncCommandHandler<ScriptsDto> _updateScript;
        private readonly IAsyncCommandHandler<NewScriptDto> _addNewScript;
        private readonly IAsyncCommandHandler<UpdateScriptToRunDto> _updateScriptToRun;
        public ScriptsController(IAsyncRequestHandler<GetScriptsByDeviceTypeRequest, List<ScriptsDto>> listScriptsHandler,
            IAsyncCommandHandler<ScriptsDto> updateScript,
            IAsyncCommandHandler<NewScriptDto> addNewScript,
            IAsyncCommandHandler<UpdateScriptToRunDto> updateScriptToRun) 
        {  
            _listScriptsHandler = listScriptsHandler;
            _updateScript = updateScript;
            _addNewScript = addNewScript;
            _updateScriptToRun= updateScriptToRun;
        }
        public async Task<List<ScriptsDto>> GetScriptsByMachineType(string machineType)
        {
            var result = await _listScriptsHandler.HandleAsync(new GetScriptsByDeviceTypeRequest { MachineType = machineType});
            return result;

        }

        public async Task UpdateScript(ScriptsDto updatedScript)
        {
            await _updateScript.HandleAsync(updatedScript);
        }

        public async Task AddNewScript(NewScriptDto newScript)
        {
            
            await _addNewScript.HandleAsync(newScript);
            
        }
        
        public async Task UpdateScriptToRun(UpdateScriptToRunDto updateScriptToRun)
        {
            await _updateScriptToRun.HandleAsync(updateScriptToRun);
        }
    }
}
