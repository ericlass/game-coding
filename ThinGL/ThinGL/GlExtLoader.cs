using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ThinGL
{
  public static partial class GlExt
  {
    private static Dictionary<string, Delegate> _delegates = new Dictionary<string, Delegate>();

    private static Delegate GetProc<T>()
    {
      string name = typeof(T).Name;
      Delegate result = null;
      if (!_delegates.ContainsKey(name))
      {
        IntPtr proc = Wgl.wglGetProcAddress(name);

        if (proc == null || proc == IntPtr.Zero)
          throw new InvalidOperationException(name + " is not available!");

        result = Marshal.GetDelegateForFunctionPointer(proc, typeof(T));

        _delegates.Add(name, result);
      }
      else
        result = _delegates[name];

      return result;
    }

    public static bool AreProgramsResidentNV(int n, ref uint[] programs, ref byte[] residences)
    {
      glAreProgramsResidentNV del = (glAreProgramsResidentNV)GetProc<glAreProgramsResidentNV>();
      return del(n, ref programs, ref residences);
    }

    public static bool AreTexturesResidentEXT(int n, ref uint[] textures, ref byte[] residences)
    {
      glAreTexturesResidentEXT del = (glAreTexturesResidentEXT)GetProc<glAreTexturesResidentEXT>();
      return del(n, ref textures, ref residences);
    }

    public static bool IsAsyncMarkerSGIX(uint marker)
    {
      glIsAsyncMarkerSGIX del = (glIsAsyncMarkerSGIX)GetProc<glIsAsyncMarkerSGIX>();
      return del(marker);
    }

    public static bool IsBuffer(uint buffer)
    {
      glIsBuffer del = (glIsBuffer)GetProc<glIsBuffer>();
      return del(buffer);
    }

    public static bool IsBufferARB(uint buffer)
    {
      glIsBufferARB del = (glIsBufferARB)GetProc<glIsBufferARB>();
      return del(buffer);
    }

    public static bool IsBufferResidentNV(uint target)
    {
      glIsBufferResidentNV del = (glIsBufferResidentNV)GetProc<glIsBufferResidentNV>();
      return del(target);
    }

    public static bool IsEnabledi(uint target, uint index)
    {
      glIsEnabledi del = (glIsEnabledi)GetProc<glIsEnabledi>();
      return del(target, index);
    }

    public static bool IsEnabledIndexedEXT(uint target, uint index)
    {
      glIsEnabledIndexedEXT del = (glIsEnabledIndexedEXT)GetProc<glIsEnabledIndexedEXT>();
      return del(target, index);
    }

    public static bool IsFenceAPPLE(uint fence)
    {
      glIsFenceAPPLE del = (glIsFenceAPPLE)GetProc<glIsFenceAPPLE>();
      return del(fence);
    }

    public static bool IsFenceNV(uint fence)
    {
      glIsFenceNV del = (glIsFenceNV)GetProc<glIsFenceNV>();
      return del(fence);
    }

    public static bool IsFramebuffer(uint framebuffer)
    {
      glIsFramebuffer del = (glIsFramebuffer)GetProc<glIsFramebuffer>();
      return del(framebuffer);
    }

    public static bool IsFramebufferEXT(uint framebuffer)
    {
      glIsFramebufferEXT del = (glIsFramebufferEXT)GetProc<glIsFramebufferEXT>();
      return del(framebuffer);
    }

    public static bool IsImageHandleResidentARB(ulong handle)
    {
      glIsImageHandleResidentARB del = (glIsImageHandleResidentARB)GetProc<glIsImageHandleResidentARB>();
      return del(handle);
    }

    public static bool IsImageHandleResidentNV(ulong handle)
    {
      glIsImageHandleResidentNV del = (glIsImageHandleResidentNV)GetProc<glIsImageHandleResidentNV>();
      return del(handle);
    }

    public static bool IsNameAMD(uint identifier, uint name)
    {
      glIsNameAMD del = (glIsNameAMD)GetProc<glIsNameAMD>();
      return del(identifier, name);
    }

    public static bool IsNamedBufferResidentNV(uint buffer)
    {
      glIsNamedBufferResidentNV del = (glIsNamedBufferResidentNV)GetProc<glIsNamedBufferResidentNV>();
      return del(buffer);
    }

    public static bool IsNamedStringARB(int namelen, ref sbyte[] name)
    {
      glIsNamedStringARB del = (glIsNamedStringARB)GetProc<glIsNamedStringARB>();
      return del(namelen, ref name);
    }

    public static bool IsObjectBufferATI(uint buffer)
    {
      glIsObjectBufferATI del = (glIsObjectBufferATI)GetProc<glIsObjectBufferATI>();
      return del(buffer);
    }

    public static bool IsOcclusionQueryNV(uint id)
    {
      glIsOcclusionQueryNV del = (glIsOcclusionQueryNV)GetProc<glIsOcclusionQueryNV>();
      return del(id);
    }

    public static bool IsPathNV(uint path)
    {
      glIsPathNV del = (glIsPathNV)GetProc<glIsPathNV>();
      return del(path);
    }

    public static bool IsPointInFillPathNV(uint path, uint mask, float x, float y)
    {
      glIsPointInFillPathNV del = (glIsPointInFillPathNV)GetProc<glIsPointInFillPathNV>();
      return del(path, mask, x, y);
    }

    public static bool IsPointInStrokePathNV(uint path, float x, float y)
    {
      glIsPointInStrokePathNV del = (glIsPointInStrokePathNV)GetProc<glIsPointInStrokePathNV>();
      return del(path, x, y);
    }

    public static bool IsProgram(uint program)
    {
      glIsProgram del = (glIsProgram)GetProc<glIsProgram>();
      return del(program);
    }

    public static bool IsProgramARB(uint program)
    {
      glIsProgramARB del = (glIsProgramARB)GetProc<glIsProgramARB>();
      return del(program);
    }

    public static bool IsProgramNV(uint id)
    {
      glIsProgramNV del = (glIsProgramNV)GetProc<glIsProgramNV>();
      return del(id);
    }

    public static bool IsProgramPipeline(uint pipeline)
    {
      glIsProgramPipeline del = (glIsProgramPipeline)GetProc<glIsProgramPipeline>();
      return del(pipeline);
    }

    public static bool IsQuery(uint id)
    {
      glIsQuery del = (glIsQuery)GetProc<glIsQuery>();
      return del(id);
    }

    public static bool IsQueryARB(uint id)
    {
      glIsQueryARB del = (glIsQueryARB)GetProc<glIsQueryARB>();
      return del(id);
    }

    public static bool IsRenderbuffer(uint renderbuffer)
    {
      glIsRenderbuffer del = (glIsRenderbuffer)GetProc<glIsRenderbuffer>();
      return del(renderbuffer);
    }

    public static bool IsRenderbufferEXT(uint renderbuffer)
    {
      glIsRenderbufferEXT del = (glIsRenderbufferEXT)GetProc<glIsRenderbufferEXT>();
      return del(renderbuffer);
    }

    public static bool IsSampler(uint sampler)
    {
      glIsSampler del = (glIsSampler)GetProc<glIsSampler>();
      return del(sampler);
    }

    public static bool IsShader(uint shader)
    {
      glIsShader del = (glIsShader)GetProc<glIsShader>();
      return del(shader);
    }

    public static bool IsSync(GLsync sync)
    {
      glIsSync del = (glIsSync)GetProc<glIsSync>();
      return del(sync);
    }

    public static bool IsTextureEXT(uint texture)
    {
      glIsTextureEXT del = (glIsTextureEXT)GetProc<glIsTextureEXT>();
      return del(texture);
    }

    public static bool IsTextureHandleResidentARB(ulong handle)
    {
      glIsTextureHandleResidentARB del = (glIsTextureHandleResidentARB)GetProc<glIsTextureHandleResidentARB>();
      return del(handle);
    }

    public static bool IsTextureHandleResidentNV(ulong handle)
    {
      glIsTextureHandleResidentNV del = (glIsTextureHandleResidentNV)GetProc<glIsTextureHandleResidentNV>();
      return del(handle);
    }

    public static bool IsTransformFeedback(uint id)
    {
      glIsTransformFeedback del = (glIsTransformFeedback)GetProc<glIsTransformFeedback>();
      return del(id);
    }

    public static bool IsTransformFeedbackNV(uint id)
    {
      glIsTransformFeedbackNV del = (glIsTransformFeedbackNV)GetProc<glIsTransformFeedbackNV>();
      return del(id);
    }

    public static bool IsVariantEnabledEXT(uint id, uint cap)
    {
      glIsVariantEnabledEXT del = (glIsVariantEnabledEXT)GetProc<glIsVariantEnabledEXT>();
      return del(id, cap);
    }

    public static bool IsVertexArray(uint array)
    {
      glIsVertexArray del = (glIsVertexArray)GetProc<glIsVertexArray>();
      return del(array);
    }

    public static bool IsVertexArrayAPPLE(uint array)
    {
      glIsVertexArrayAPPLE del = (glIsVertexArrayAPPLE)GetProc<glIsVertexArrayAPPLE>();
      return del(array);
    }

    public static bool IsVertexAttribEnabledAPPLE(uint index, uint pname)
    {
      glIsVertexAttribEnabledAPPLE del = (glIsVertexAttribEnabledAPPLE)GetProc<glIsVertexAttribEnabledAPPLE>();
      return del(index, pname);
    }

    public static bool PointAlongPathNV(uint path, int startSegment, int numSegments, float distance, ref float[] x, ref float[] y, ref float[] tangentX, ref float[] tangentY)
    {
      glPointAlongPathNV del = (glPointAlongPathNV)GetProc<glPointAlongPathNV>();
      return del(path, startSegment, numSegments, distance, ref x, ref y, ref tangentX, ref tangentY);
    }

    public static bool TestFenceAPPLE(uint fence)
    {
      glTestFenceAPPLE del = (glTestFenceAPPLE)GetProc<glTestFenceAPPLE>();
      return del(fence);
    }

    public static bool TestFenceNV(uint fence)
    {
      glTestFenceNV del = (glTestFenceNV)GetProc<glTestFenceNV>();
      return del(fence);
    }

    public static bool TestObjectAPPLE(uint obj, uint name)
    {
      glTestObjectAPPLE del = (glTestObjectAPPLE)GetProc<glTestObjectAPPLE>();
      return del(obj, name);
    }

    public static bool UnmapBuffer(uint target)
    {
      glUnmapBuffer del = (glUnmapBuffer)GetProc<glUnmapBuffer>();
      return del(target);
    }

    public static bool UnmapBufferARB(uint target)
    {
      glUnmapBufferARB del = (glUnmapBufferARB)GetProc<glUnmapBufferARB>();
      return del(target);
    }

    public static bool UnmapNamedBufferEXT(uint buffer)
    {
      glUnmapNamedBufferEXT del = (glUnmapNamedBufferEXT)GetProc<glUnmapNamedBufferEXT>();
      return del(buffer);
    }

    public static string GetStringi(uint name, uint index)
    {
      glGetStringi del = (glGetStringi)GetProc<glGetStringi>();
      return del(name, index);
    }

    public static float GetPathLengthNV(uint path, int startSegment, int numSegments)
    {
      glGetPathLengthNV del = (glGetPathLengthNV)GetProc<glGetPathLengthNV>();
      return del(path, startSegment, numSegments);
    }

    public static GLsync FenceSync(uint condition, uint flags)
    {
      glFenceSync del = (glFenceSync)GetProc<glFenceSync>();
      return del(condition, flags);
    }

    public static GLsync ImportSyncEXT(uint external_sync_type, IntPtr external_sync, uint flags)
    {
      glImportSyncEXT del = (glImportSyncEXT)GetProc<glImportSyncEXT>();
      return del(external_sync_type, external_sync, flags);
    }

    public static int FinishAsyncSGIX(ref uint[] markerp)
    {
      glFinishAsyncSGIX del = (glFinishAsyncSGIX)GetProc<glFinishAsyncSGIX>();
      return del(ref markerp);
    }

    public static int GetAttribLocation(uint program, ref sbyte[] name)
    {
      glGetAttribLocation del = (glGetAttribLocation)GetProc<glGetAttribLocation>();
      return del(program, ref name);
    }

    public static int GetAttribLocationARB(uint programObj, ref sbyte[] name)
    {
      glGetAttribLocationARB del = (glGetAttribLocationARB)GetProc<glGetAttribLocationARB>();
      return del(programObj, ref name);
    }

    public static int GetFragDataIndex(uint program, ref sbyte[] name)
    {
      glGetFragDataIndex del = (glGetFragDataIndex)GetProc<glGetFragDataIndex>();
      return del(program, ref name);
    }

    public static int GetFragDataLocation(uint program, ref sbyte[] name)
    {
      glGetFragDataLocation del = (glGetFragDataLocation)GetProc<glGetFragDataLocation>();
      return del(program, ref name);
    }

    public static int GetFragDataLocationEXT(uint program, ref sbyte[] name)
    {
      glGetFragDataLocationEXT del = (glGetFragDataLocationEXT)GetProc<glGetFragDataLocationEXT>();
      return del(program, ref name);
    }

    public static int GetInstrumentsSGIX()
    {
      glGetInstrumentsSGIX del = (glGetInstrumentsSGIX)GetProc<glGetInstrumentsSGIX>();
      return del();
    }

    public static int GetProgramResourceLocation(uint program, uint programInterface, ref sbyte[] name)
    {
      glGetProgramResourceLocation del = (glGetProgramResourceLocation)GetProc<glGetProgramResourceLocation>();
      return del(program, programInterface, ref name);
    }

    public static int GetProgramResourceLocationIndex(uint program, uint programInterface, ref sbyte[] name)
    {
      glGetProgramResourceLocationIndex del = (glGetProgramResourceLocationIndex)GetProc<glGetProgramResourceLocationIndex>();
      return del(program, programInterface, ref name);
    }

    public static int GetSubroutineUniformLocation(uint program, uint shadertype, ref sbyte[] name)
    {
      glGetSubroutineUniformLocation del = (glGetSubroutineUniformLocation)GetProc<glGetSubroutineUniformLocation>();
      return del(program, shadertype, ref name);
    }

    public static int GetUniformBufferSizeEXT(uint program, int location)
    {
      glGetUniformBufferSizeEXT del = (glGetUniformBufferSizeEXT)GetProc<glGetUniformBufferSizeEXT>();
      return del(program, location);
    }

    public static int GetUniformLocation(uint program, ref sbyte[] name)
    {
      glGetUniformLocation del = (glGetUniformLocation)GetProc<glGetUniformLocation>();
      return del(program, ref name);
    }

    public static int GetUniformLocationARB(uint programObj, ref sbyte[] name)
    {
      glGetUniformLocationARB del = (glGetUniformLocationARB)GetProc<glGetUniformLocationARB>();
      return del(programObj, ref name);
    }

    public static int GetVaryingLocationNV(uint program, ref sbyte[] name)
    {
      glGetVaryingLocationNV del = (glGetVaryingLocationNV)GetProc<glGetVaryingLocationNV>();
      return del(program, ref name);
    }

    public static int PollAsyncSGIX(ref uint[] markerp)
    {
      glPollAsyncSGIX del = (glPollAsyncSGIX)GetProc<glPollAsyncSGIX>();
      return del(ref markerp);
    }

    public static int PollInstrumentsSGIX(ref int[] marker_p)
    {
      glPollInstrumentsSGIX del = (glPollInstrumentsSGIX)GetProc<glPollInstrumentsSGIX>();
      return del(ref marker_p);
    }

    public static IntPtr GetUniformOffsetEXT(uint program, int location)
    {
      glGetUniformOffsetEXT del = (glGetUniformOffsetEXT)GetProc<glGetUniformOffsetEXT>();
      return del(program, location);
    }

    public static IntPtr VDPAURegisterOutputSurfaceNV(IntPtr vdpSurface, uint target, int numTextureNames, ref uint[] textureNames)
    {
      glVDPAURegisterOutputSurfaceNV del = (glVDPAURegisterOutputSurfaceNV)GetProc<glVDPAURegisterOutputSurfaceNV>();
      return del(vdpSurface, target, numTextureNames, ref textureNames);
    }

    public static IntPtr VDPAURegisterVideoSurfaceNV(IntPtr vdpSurface, uint target, int numTextureNames, ref uint[] textureNames)
    {
      glVDPAURegisterVideoSurfaceNV del = (glVDPAURegisterVideoSurfaceNV)GetProc<glVDPAURegisterVideoSurfaceNV>();
      return del(vdpSurface, target, numTextureNames, ref textureNames);
    }

    public static uint BindLightParameterEXT(uint light, uint value)
    {
      glBindLightParameterEXT del = (glBindLightParameterEXT)GetProc<glBindLightParameterEXT>();
      return del(light, value);
    }

    public static uint BindMaterialParameterEXT(uint face, uint value)
    {
      glBindMaterialParameterEXT del = (glBindMaterialParameterEXT)GetProc<glBindMaterialParameterEXT>();
      return del(face, value);
    }

    public static uint BindParameterEXT(uint value)
    {
      glBindParameterEXT del = (glBindParameterEXT)GetProc<glBindParameterEXT>();
      return del(value);
    }

    public static uint BindTexGenParameterEXT(uint unit, uint coord, uint value)
    {
      glBindTexGenParameterEXT del = (glBindTexGenParameterEXT)GetProc<glBindTexGenParameterEXT>();
      return del(unit, coord, value);
    }

    public static uint BindTextureUnitParameterEXT(uint unit, uint value)
    {
      glBindTextureUnitParameterEXT del = (glBindTextureUnitParameterEXT)GetProc<glBindTextureUnitParameterEXT>();
      return del(unit, value);
    }

    public static uint CheckFramebufferStatus(uint target)
    {
      glCheckFramebufferStatus del = (glCheckFramebufferStatus)GetProc<glCheckFramebufferStatus>();
      return del(target);
    }

    public static uint CheckFramebufferStatusEXT(uint target)
    {
      glCheckFramebufferStatusEXT del = (glCheckFramebufferStatusEXT)GetProc<glCheckFramebufferStatusEXT>();
      return del(target);
    }

    public static uint CheckNamedFramebufferStatusEXT(uint framebuffer, uint target)
    {
      glCheckNamedFramebufferStatusEXT del = (glCheckNamedFramebufferStatusEXT)GetProc<glCheckNamedFramebufferStatusEXT>();
      return del(framebuffer, target);
    }

    public static uint ClientWaitSync(GLsync sync, uint flags, ulong timeout)
    {
      glClientWaitSync del = (glClientWaitSync)GetProc<glClientWaitSync>();
      return del(sync, flags, timeout);
    }

    public static uint CreateProgram()
    {
      glCreateProgram del = (glCreateProgram)GetProc<glCreateProgram>();
      return del();
    }

    public static uint CreateProgramObjectARB()
    {
      glCreateProgramObjectARB del = (glCreateProgramObjectARB)GetProc<glCreateProgramObjectARB>();
      return del();
    }

    public static uint CreateShader(uint type)
    {
      glCreateShader del = (glCreateShader)GetProc<glCreateShader>();
      return del(type);
    }

    public static uint CreateShaderObjectARB(uint shaderType)
    {
      glCreateShaderObjectARB del = (glCreateShaderObjectARB)GetProc<glCreateShaderObjectARB>();
      return del(shaderType);
    }

    public static uint CreateShaderProgramEXT(uint type, ref sbyte[] str)
    {
      glCreateShaderProgramEXT del = (glCreateShaderProgramEXT)GetProc<glCreateShaderProgramEXT>();
      return del(type, ref str);
    }

    public static uint CreateShaderProgramv(uint type, int count, ref sbyte[] strings)
    {
      glCreateShaderProgramv del = (glCreateShaderProgramv)GetProc<glCreateShaderProgramv>();
      return del(type, count, ref strings);
    }

    public static uint GenAsyncMarkersSGIX(int range)
    {
      glGenAsyncMarkersSGIX del = (glGenAsyncMarkersSGIX)GetProc<glGenAsyncMarkersSGIX>();
      return del(range);
    }

    public static uint GenFragmentShadersATI(uint range)
    {
      glGenFragmentShadersATI del = (glGenFragmentShadersATI)GetProc<glGenFragmentShadersATI>();
      return del(range);
    }

    public static uint GenPathsNV(int range)
    {
      glGenPathsNV del = (glGenPathsNV)GetProc<glGenPathsNV>();
      return del(range);
    }

    public static uint GenSymbolsEXT(uint datatype, uint storagetype, uint range, uint components)
    {
      glGenSymbolsEXT del = (glGenSymbolsEXT)GetProc<glGenSymbolsEXT>();
      return del(datatype, storagetype, range, components);
    }

    public static uint GenVertexShadersEXT(uint range)
    {
      glGenVertexShadersEXT del = (glGenVertexShadersEXT)GetProc<glGenVertexShadersEXT>();
      return del(range);
    }

    public static uint GetDebugMessageLog(uint count, int bufSize, ref uint[] sources, ref uint[] types, ref uint[] ids, ref uint[] severities, ref int[] lengths, ref sbyte[] messageLog)
    {
      glGetDebugMessageLog del = (glGetDebugMessageLog)GetProc<glGetDebugMessageLog>();
      return del(count, bufSize, ref sources, ref types, ref ids, ref severities, ref lengths, ref messageLog);
    }

    public static uint GetDebugMessageLogAMD(uint count, int bufsize, ref uint[] categories, ref uint[] severities, ref uint[] ids, ref int[] lengths, ref sbyte[] message)
    {
      glGetDebugMessageLogAMD del = (glGetDebugMessageLogAMD)GetProc<glGetDebugMessageLogAMD>();
      return del(count, bufsize, ref categories, ref severities, ref ids, ref lengths, ref message);
    }

    public static uint GetDebugMessageLogARB(uint count, int bufSize, ref uint[] sources, ref uint[] types, ref uint[] ids, ref uint[] severities, ref int[] lengths, ref sbyte[] messageLog)
    {
      glGetDebugMessageLogARB del = (glGetDebugMessageLogARB)GetProc<glGetDebugMessageLogARB>();
      return del(count, bufSize, ref sources, ref types, ref ids, ref severities, ref lengths, ref messageLog);
    }

    public static uint GetGraphicsResetStatusARB()
    {
      glGetGraphicsResetStatusARB del = (glGetGraphicsResetStatusARB)GetProc<glGetGraphicsResetStatusARB>();
      return del();
    }

    public static uint GetHandleARB(uint pname)
    {
      glGetHandleARB del = (glGetHandleARB)GetProc<glGetHandleARB>();
      return del(pname);
    }

    public static uint GetProgramResourceIndex(uint program, uint programInterface, ref sbyte[] name)
    {
      glGetProgramResourceIndex del = (glGetProgramResourceIndex)GetProc<glGetProgramResourceIndex>();
      return del(program, programInterface, ref name);
    }

    public static uint GetSubroutineIndex(uint program, uint shadertype, ref sbyte[] name)
    {
      glGetSubroutineIndex del = (glGetSubroutineIndex)GetProc<glGetSubroutineIndex>();
      return del(program, shadertype, ref name);
    }

    public static uint GetUniformBlockIndex(uint program, ref sbyte[] uniformBlockName)
    {
      glGetUniformBlockIndex del = (glGetUniformBlockIndex)GetProc<glGetUniformBlockIndex>();
      return del(program, ref uniformBlockName);
    }

    public static uint NewObjectBufferATI(int size, IntPtr pointer, uint usage)
    {
      glNewObjectBufferATI del = (glNewObjectBufferATI)GetProc<glNewObjectBufferATI>();
      return del(size, pointer, usage);
    }

    public static uint ObjectPurgeableAPPLE(uint objectType, uint name, uint option)
    {
      glObjectPurgeableAPPLE del = (glObjectPurgeableAPPLE)GetProc<glObjectPurgeableAPPLE>();
      return del(objectType, name, option);
    }

    public static uint ObjectUnpurgeableAPPLE(uint objectType, uint name, uint option)
    {
      glObjectUnpurgeableAPPLE del = (glObjectUnpurgeableAPPLE)GetProc<glObjectUnpurgeableAPPLE>();
      return del(objectType, name, option);
    }

    public static uint VideoCaptureNV(uint video_capture_slot, ref uint[] sequence_num, ref ulong[] capture_time)
    {
      glVideoCaptureNV del = (glVideoCaptureNV)GetProc<glVideoCaptureNV>();
      return del(video_capture_slot, ref sequence_num, ref capture_time);
    }

    public static ulong GetImageHandleARB(uint texture, int level, bool layered, int layer, uint format)
    {
      glGetImageHandleARB del = (glGetImageHandleARB)GetProc<glGetImageHandleARB>();
      return del(texture, level, layered, layer, format);
    }

    public static ulong GetImageHandleNV(uint texture, int level, bool layered, int layer, uint format)
    {
      glGetImageHandleNV del = (glGetImageHandleNV)GetProc<glGetImageHandleNV>();
      return del(texture, level, layered, layer, format);
    }

    public static ulong GetTextureHandleARB(uint texture)
    {
      glGetTextureHandleARB del = (glGetTextureHandleARB)GetProc<glGetTextureHandleARB>();
      return del(texture);
    }

    public static ulong GetTextureSamplerHandleARB(uint texture, uint sampler)
    {
      glGetTextureSamplerHandleARB del = (glGetTextureSamplerHandleARB)GetProc<glGetTextureSamplerHandleARB>();
      return del(texture, sampler);
    }

    public static ulong GetTextureSamplerHandleNV(uint texture, uint sampler)
    {
      glGetTextureSamplerHandleNV del = (glGetTextureSamplerHandleNV)GetProc<glGetTextureSamplerHandleNV>();
      return del(texture, sampler);
    }

    public static void AccumxOES(uint op, int value)
    {
      glAccumxOES del = (glAccumxOES)GetProc<glAccumxOES>();
      del(op, value);
    }

    public static void ActiveProgramEXT(uint program)
    {
      glActiveProgramEXT del = (glActiveProgramEXT)GetProc<glActiveProgramEXT>();
      del(program);
    }

    public static void ActiveShaderProgram(uint pipeline, uint program)
    {
      glActiveShaderProgram del = (glActiveShaderProgram)GetProc<glActiveShaderProgram>();
      del(pipeline, program);
    }

    public static void ActiveStencilFaceEXT(uint face)
    {
      glActiveStencilFaceEXT del = (glActiveStencilFaceEXT)GetProc<glActiveStencilFaceEXT>();
      del(face);
    }

    public static void ActiveTexture(uint texture)
    {
      glActiveTexture del = (glActiveTexture)GetProc<glActiveTexture>();
      del(texture);
    }

    public static void ActiveTextureARB(uint texture)
    {
      glActiveTextureARB del = (glActiveTextureARB)GetProc<glActiveTextureARB>();
      del(texture);
    }

    public static void ActiveVaryingNV(uint program, ref sbyte[] name)
    {
      glActiveVaryingNV del = (glActiveVaryingNV)GetProc<glActiveVaryingNV>();
      del(program, ref name);
    }

    public static void AlphaFragmentOp1ATI(uint op, uint dst, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod)
    {
      glAlphaFragmentOp1ATI del = (glAlphaFragmentOp1ATI)GetProc<glAlphaFragmentOp1ATI>();
      del(op, dst, dstMod, arg1, arg1Rep, arg1Mod);
    }

    public static void AlphaFragmentOp2ATI(uint op, uint dst, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod)
    {
      glAlphaFragmentOp2ATI del = (glAlphaFragmentOp2ATI)GetProc<glAlphaFragmentOp2ATI>();
      del(op, dst, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod);
    }

    public static void AlphaFragmentOp3ATI(uint op, uint dst, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod, uint arg3, uint arg3Rep, uint arg3Mod)
    {
      glAlphaFragmentOp3ATI del = (glAlphaFragmentOp3ATI)GetProc<glAlphaFragmentOp3ATI>();
      del(op, dst, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod, arg3, arg3Rep, arg3Mod);
    }

    public static void AlphaFuncxOES(uint func, int reference)
    {
      glAlphaFuncxOES del = (glAlphaFuncxOES)GetProc<glAlphaFuncxOES>();
      del(func, reference);
    }

    public static void ApplyTextureEXT(uint mode)
    {
      glApplyTextureEXT del = (glApplyTextureEXT)GetProc<glApplyTextureEXT>();
      del(mode);
    }

    public static void ArrayElementEXT(int i)
    {
      glArrayElementEXT del = (glArrayElementEXT)GetProc<glArrayElementEXT>();
      del(i);
    }

    public static void ArrayObjectATI(uint array, int size, uint type, int stride, uint buffer, uint offset)
    {
      glArrayObjectATI del = (glArrayObjectATI)GetProc<glArrayObjectATI>();
      del(array, size, type, stride, buffer, offset);
    }

    public static void AsyncMarkerSGIX(uint marker)
    {
      glAsyncMarkerSGIX del = (glAsyncMarkerSGIX)GetProc<glAsyncMarkerSGIX>();
      del(marker);
    }

    public static void AttachObjectARB(uint containerObj, uint obj)
    {
      glAttachObjectARB del = (glAttachObjectARB)GetProc<glAttachObjectARB>();
      del(containerObj, obj);
    }

    public static void AttachShader(uint program, uint shader)
    {
      glAttachShader del = (glAttachShader)GetProc<glAttachShader>();
      del(program, shader);
    }

    public static void BeginConditionalRender(uint id, uint mode)
    {
      glBeginConditionalRender del = (glBeginConditionalRender)GetProc<glBeginConditionalRender>();
      del(id, mode);
    }

    public static void BeginConditionalRenderNV(uint id, uint mode)
    {
      glBeginConditionalRenderNV del = (glBeginConditionalRenderNV)GetProc<glBeginConditionalRenderNV>();
      del(id, mode);
    }

    public static void BeginConditionalRenderNVX(uint id)
    {
      glBeginConditionalRenderNVX del = (glBeginConditionalRenderNVX)GetProc<glBeginConditionalRenderNVX>();
      del(id);
    }

    public static void BeginFragmentShaderATI()
    {
      glBeginFragmentShaderATI del = (glBeginFragmentShaderATI)GetProc<glBeginFragmentShaderATI>();
      del();
    }

    public static void BeginOcclusionQueryNV(uint id)
    {
      glBeginOcclusionQueryNV del = (glBeginOcclusionQueryNV)GetProc<glBeginOcclusionQueryNV>();
      del(id);
    }

    public static void BeginPerfMonitorAMD(uint monitor)
    {
      glBeginPerfMonitorAMD del = (glBeginPerfMonitorAMD)GetProc<glBeginPerfMonitorAMD>();
      del(monitor);
    }

    public static void BeginQuery(uint target, uint id)
    {
      glBeginQuery del = (glBeginQuery)GetProc<glBeginQuery>();
      del(target, id);
    }

    public static void BeginQueryARB(uint target, uint id)
    {
      glBeginQueryARB del = (glBeginQueryARB)GetProc<glBeginQueryARB>();
      del(target, id);
    }

    public static void BeginQueryIndexed(uint target, uint index, uint id)
    {
      glBeginQueryIndexed del = (glBeginQueryIndexed)GetProc<glBeginQueryIndexed>();
      del(target, index, id);
    }

    public static void BeginTransformFeedback(uint primitiveMode)
    {
      glBeginTransformFeedback del = (glBeginTransformFeedback)GetProc<glBeginTransformFeedback>();
      del(primitiveMode);
    }

    public static void BeginTransformFeedbackEXT(uint primitiveMode)
    {
      glBeginTransformFeedbackEXT del = (glBeginTransformFeedbackEXT)GetProc<glBeginTransformFeedbackEXT>();
      del(primitiveMode);
    }

    public static void BeginTransformFeedbackNV(uint primitiveMode)
    {
      glBeginTransformFeedbackNV del = (glBeginTransformFeedbackNV)GetProc<glBeginTransformFeedbackNV>();
      del(primitiveMode);
    }

    public static void BeginVertexShaderEXT()
    {
      glBeginVertexShaderEXT del = (glBeginVertexShaderEXT)GetProc<glBeginVertexShaderEXT>();
      del();
    }

    public static void BeginVideoCaptureNV(uint video_capture_slot)
    {
      glBeginVideoCaptureNV del = (glBeginVideoCaptureNV)GetProc<glBeginVideoCaptureNV>();
      del(video_capture_slot);
    }

    public static void BindAttribLocation(uint program, uint index, ref sbyte[] name)
    {
      glBindAttribLocation del = (glBindAttribLocation)GetProc<glBindAttribLocation>();
      del(program, index, ref name);
    }

    public static void BindAttribLocationARB(uint programObj, uint index, ref sbyte[] name)
    {
      glBindAttribLocationARB del = (glBindAttribLocationARB)GetProc<glBindAttribLocationARB>();
      del(programObj, index, ref name);
    }

    public static void BindBuffer(uint target, uint buffer)
    {
      glBindBuffer del = (glBindBuffer)GetProc<glBindBuffer>();
      del(target, buffer);
    }

    public static void BindBufferARB(uint target, uint buffer)
    {
      glBindBufferARB del = (glBindBufferARB)GetProc<glBindBufferARB>();
      del(target, buffer);
    }

    public static void BindBufferBase(uint target, uint index, uint buffer)
    {
      glBindBufferBase del = (glBindBufferBase)GetProc<glBindBufferBase>();
      del(target, index, buffer);
    }

    public static void BindBufferBaseEXT(uint target, uint index, uint buffer)
    {
      glBindBufferBaseEXT del = (glBindBufferBaseEXT)GetProc<glBindBufferBaseEXT>();
      del(target, index, buffer);
    }

    public static void BindBufferBaseNV(uint target, uint index, uint buffer)
    {
      glBindBufferBaseNV del = (glBindBufferBaseNV)GetProc<glBindBufferBaseNV>();
      del(target, index, buffer);
    }

    public static void BindBufferOffsetEXT(uint target, uint index, uint buffer, IntPtr offset)
    {
      glBindBufferOffsetEXT del = (glBindBufferOffsetEXT)GetProc<glBindBufferOffsetEXT>();
      del(target, index, buffer, offset);
    }

    public static void BindBufferOffsetNV(uint target, uint index, uint buffer, IntPtr offset)
    {
      glBindBufferOffsetNV del = (glBindBufferOffsetNV)GetProc<glBindBufferOffsetNV>();
      del(target, index, buffer, offset);
    }

    public static void BindBufferRange(uint target, uint index, uint buffer, IntPtr offset, IntPtr size)
    {
      glBindBufferRange del = (glBindBufferRange)GetProc<glBindBufferRange>();
      del(target, index, buffer, offset, size);
    }

    public static void BindBufferRangeEXT(uint target, uint index, uint buffer, IntPtr offset, IntPtr size)
    {
      glBindBufferRangeEXT del = (glBindBufferRangeEXT)GetProc<glBindBufferRangeEXT>();
      del(target, index, buffer, offset, size);
    }

    public static void BindBufferRangeNV(uint target, uint index, uint buffer, IntPtr offset, IntPtr size)
    {
      glBindBufferRangeNV del = (glBindBufferRangeNV)GetProc<glBindBufferRangeNV>();
      del(target, index, buffer, offset, size);
    }

    public static void BindBuffersBase(uint target, uint first, int count, ref uint[] buffers)
    {
      glBindBuffersBase del = (glBindBuffersBase)GetProc<glBindBuffersBase>();
      del(target, first, count, ref buffers);
    }

    public static void BindBuffersRange(uint target, uint first, int count, ref uint[] buffers, IntPtr offsets, IntPtr sizes)
    {
      glBindBuffersRange del = (glBindBuffersRange)GetProc<glBindBuffersRange>();
      del(target, first, count, ref buffers, offsets, sizes);
    }

    public static void BindFragDataLocation(uint program, uint color, ref sbyte[] name)
    {
      glBindFragDataLocation del = (glBindFragDataLocation)GetProc<glBindFragDataLocation>();
      del(program, color, ref name);
    }

    public static void BindFragDataLocationEXT(uint program, uint color, ref sbyte[] name)
    {
      glBindFragDataLocationEXT del = (glBindFragDataLocationEXT)GetProc<glBindFragDataLocationEXT>();
      del(program, color, ref name);
    }

    public static void BindFragDataLocationIndexed(uint program, uint colorNumber, uint index, ref sbyte[] name)
    {
      glBindFragDataLocationIndexed del = (glBindFragDataLocationIndexed)GetProc<glBindFragDataLocationIndexed>();
      del(program, colorNumber, index, ref name);
    }

    public static void BindFragmentShaderATI(uint id)
    {
      glBindFragmentShaderATI del = (glBindFragmentShaderATI)GetProc<glBindFragmentShaderATI>();
      del(id);
    }

    public static void BindFramebuffer(uint target, uint framebuffer)
    {
      glBindFramebuffer del = (glBindFramebuffer)GetProc<glBindFramebuffer>();
      del(target, framebuffer);
    }

    public static void BindFramebufferEXT(uint target, uint framebuffer)
    {
      glBindFramebufferEXT del = (glBindFramebufferEXT)GetProc<glBindFramebufferEXT>();
      del(target, framebuffer);
    }

    public static void BindImageTexture(uint unit, uint texture, int level, bool layered, int layer, uint access, uint format)
    {
      glBindImageTexture del = (glBindImageTexture)GetProc<glBindImageTexture>();
      del(unit, texture, level, layered, layer, access, format);
    }

    public static void BindImageTextureEXT(uint index, uint texture, int level, bool layered, int layer, uint access, int format)
    {
      glBindImageTextureEXT del = (glBindImageTextureEXT)GetProc<glBindImageTextureEXT>();
      del(index, texture, level, layered, layer, access, format);
    }

    public static void BindImageTextures(uint first, int count, ref uint[] textures)
    {
      glBindImageTextures del = (glBindImageTextures)GetProc<glBindImageTextures>();
      del(first, count, ref textures);
    }

    public static void BindMultiTextureEXT(uint texunit, uint target, uint texture)
    {
      glBindMultiTextureEXT del = (glBindMultiTextureEXT)GetProc<glBindMultiTextureEXT>();
      del(texunit, target, texture);
    }

    public static void BindProgramARB(uint target, uint program)
    {
      glBindProgramARB del = (glBindProgramARB)GetProc<glBindProgramARB>();
      del(target, program);
    }

    public static void BindProgramNV(uint target, uint id)
    {
      glBindProgramNV del = (glBindProgramNV)GetProc<glBindProgramNV>();
      del(target, id);
    }

    public static void BindProgramPipeline(uint pipeline)
    {
      glBindProgramPipeline del = (glBindProgramPipeline)GetProc<glBindProgramPipeline>();
      del(pipeline);
    }

    public static void BindRenderbuffer(uint target, uint renderbuffer)
    {
      glBindRenderbuffer del = (glBindRenderbuffer)GetProc<glBindRenderbuffer>();
      del(target, renderbuffer);
    }

    public static void BindRenderbufferEXT(uint target, uint renderbuffer)
    {
      glBindRenderbufferEXT del = (glBindRenderbufferEXT)GetProc<glBindRenderbufferEXT>();
      del(target, renderbuffer);
    }

    public static void BindSampler(uint unit, uint sampler)
    {
      glBindSampler del = (glBindSampler)GetProc<glBindSampler>();
      del(unit, sampler);
    }

    public static void BindSamplers(uint first, int count, ref uint[] samplers)
    {
      glBindSamplers del = (glBindSamplers)GetProc<glBindSamplers>();
      del(first, count, ref samplers);
    }

    public static void BindTextureEXT(uint target, uint texture)
    {
      glBindTextureEXT del = (glBindTextureEXT)GetProc<glBindTextureEXT>();
      del(target, texture);
    }

    public static void BindTextures(uint first, int count, ref uint[] textures)
    {
      glBindTextures del = (glBindTextures)GetProc<glBindTextures>();
      del(first, count, ref textures);
    }

    public static void BindTransformFeedback(uint target, uint id)
    {
      glBindTransformFeedback del = (glBindTransformFeedback)GetProc<glBindTransformFeedback>();
      del(target, id);
    }

    public static void BindTransformFeedbackNV(uint target, uint id)
    {
      glBindTransformFeedbackNV del = (glBindTransformFeedbackNV)GetProc<glBindTransformFeedbackNV>();
      del(target, id);
    }

    public static void BindVertexArray(uint array)
    {
      glBindVertexArray del = (glBindVertexArray)GetProc<glBindVertexArray>();
      del(array);
    }

    public static void BindVertexArrayAPPLE(uint array)
    {
      glBindVertexArrayAPPLE del = (glBindVertexArrayAPPLE)GetProc<glBindVertexArrayAPPLE>();
      del(array);
    }

    public static void BindVertexBuffer(uint bindingindex, uint buffer, IntPtr offset, int stride)
    {
      glBindVertexBuffer del = (glBindVertexBuffer)GetProc<glBindVertexBuffer>();
      del(bindingindex, buffer, offset, stride);
    }

    public static void BindVertexBuffers(uint first, int count, ref uint[] buffers, IntPtr offsets, ref int[] strides)
    {
      glBindVertexBuffers del = (glBindVertexBuffers)GetProc<glBindVertexBuffers>();
      del(first, count, ref buffers, offsets, ref strides);
    }

    public static void BindVertexShaderEXT(uint id)
    {
      glBindVertexShaderEXT del = (glBindVertexShaderEXT)GetProc<glBindVertexShaderEXT>();
      del(id);
    }

    public static void BindVideoCaptureStreamBufferNV(uint video_capture_slot, uint stream, uint frame_region, IntPtr offset)
    {
      glBindVideoCaptureStreamBufferNV del = (glBindVideoCaptureStreamBufferNV)GetProc<glBindVideoCaptureStreamBufferNV>();
      del(video_capture_slot, stream, frame_region, offset);
    }

    public static void BindVideoCaptureStreamTextureNV(uint video_capture_slot, uint stream, uint frame_region, uint target, uint texture)
    {
      glBindVideoCaptureStreamTextureNV del = (glBindVideoCaptureStreamTextureNV)GetProc<glBindVideoCaptureStreamTextureNV>();
      del(video_capture_slot, stream, frame_region, target, texture);
    }

    public static void Binormal3bEXT(sbyte bx, sbyte by, sbyte bz)
    {
      glBinormal3bEXT del = (glBinormal3bEXT)GetProc<glBinormal3bEXT>();
      del(bx, by, bz);
    }

    public static void Binormal3bvEXT(ref sbyte[] v)
    {
      glBinormal3bvEXT del = (glBinormal3bvEXT)GetProc<glBinormal3bvEXT>();
      del(ref v);
    }

    public static void Binormal3dEXT(double bx, double by, double bz)
    {
      glBinormal3dEXT del = (glBinormal3dEXT)GetProc<glBinormal3dEXT>();
      del(bx, by, bz);
    }

    public static void Binormal3dvEXT(ref double[] v)
    {
      glBinormal3dvEXT del = (glBinormal3dvEXT)GetProc<glBinormal3dvEXT>();
      del(ref v);
    }

    public static void Binormal3fEXT(float bx, float by, float bz)
    {
      glBinormal3fEXT del = (glBinormal3fEXT)GetProc<glBinormal3fEXT>();
      del(bx, by, bz);
    }

    public static void Binormal3fvEXT(ref float[] v)
    {
      glBinormal3fvEXT del = (glBinormal3fvEXT)GetProc<glBinormal3fvEXT>();
      del(ref v);
    }

    public static void Binormal3iEXT(int bx, int by, int bz)
    {
      glBinormal3iEXT del = (glBinormal3iEXT)GetProc<glBinormal3iEXT>();
      del(bx, by, bz);
    }

    public static void Binormal3ivEXT(ref int[] v)
    {
      glBinormal3ivEXT del = (glBinormal3ivEXT)GetProc<glBinormal3ivEXT>();
      del(ref v);
    }

    public static void Binormal3sEXT(short bx, short by, short bz)
    {
      glBinormal3sEXT del = (glBinormal3sEXT)GetProc<glBinormal3sEXT>();
      del(bx, by, bz);
    }

    public static void Binormal3svEXT(ref short[] v)
    {
      glBinormal3svEXT del = (glBinormal3svEXT)GetProc<glBinormal3svEXT>();
      del(ref v);
    }

    public static void BinormalPointerEXT(uint type, int stride, IntPtr pointer)
    {
      glBinormalPointerEXT del = (glBinormalPointerEXT)GetProc<glBinormalPointerEXT>();
      del(type, stride, pointer);
    }

    public static void BitmapxOES(int width, int height, int xorig, int yorig, int xmove, int ymove, ref byte[] bitmap)
    {
      glBitmapxOES del = (glBitmapxOES)GetProc<glBitmapxOES>();
      del(width, height, xorig, yorig, xmove, ymove, ref bitmap);
    }

    public static void BlendBarrierNV()
    {
      glBlendBarrierNV del = (glBlendBarrierNV)GetProc<glBlendBarrierNV>();
      del();
    }

    public static void BlendColor(float red, float green, float blue, float alpha)
    {
      glBlendColor del = (glBlendColor)GetProc<glBlendColor>();
      del(red, green, blue, alpha);
    }

    public static void BlendColorEXT(float red, float green, float blue, float alpha)
    {
      glBlendColorEXT del = (glBlendColorEXT)GetProc<glBlendColorEXT>();
      del(red, green, blue, alpha);
    }

    public static void BlendColorxOES(int red, int green, int blue, int alpha)
    {
      glBlendColorxOES del = (glBlendColorxOES)GetProc<glBlendColorxOES>();
      del(red, green, blue, alpha);
    }

    public static void BlendEquation(uint mode)
    {
      glBlendEquation del = (glBlendEquation)GetProc<glBlendEquation>();
      del(mode);
    }

    public static void BlendEquationEXT(uint mode)
    {
      glBlendEquationEXT del = (glBlendEquationEXT)GetProc<glBlendEquationEXT>();
      del(mode);
    }

    public static void BlendEquationi(uint buf, uint mode)
    {
      glBlendEquationi del = (glBlendEquationi)GetProc<glBlendEquationi>();
      del(buf, mode);
    }

    public static void BlendEquationiARB(uint buf, uint mode)
    {
      glBlendEquationiARB del = (glBlendEquationiARB)GetProc<glBlendEquationiARB>();
      del(buf, mode);
    }

    public static void BlendEquationIndexedAMD(uint buf, uint mode)
    {
      glBlendEquationIndexedAMD del = (glBlendEquationIndexedAMD)GetProc<glBlendEquationIndexedAMD>();
      del(buf, mode);
    }

    public static void BlendEquationSeparate(uint modeRGB, uint modeAlpha)
    {
      glBlendEquationSeparate del = (glBlendEquationSeparate)GetProc<glBlendEquationSeparate>();
      del(modeRGB, modeAlpha);
    }

    public static void BlendEquationSeparateEXT(uint modeRGB, uint modeAlpha)
    {
      glBlendEquationSeparateEXT del = (glBlendEquationSeparateEXT)GetProc<glBlendEquationSeparateEXT>();
      del(modeRGB, modeAlpha);
    }

    public static void BlendEquationSeparatei(uint buf, uint modeRGB, uint modeAlpha)
    {
      glBlendEquationSeparatei del = (glBlendEquationSeparatei)GetProc<glBlendEquationSeparatei>();
      del(buf, modeRGB, modeAlpha);
    }

    public static void BlendEquationSeparateiARB(uint buf, uint modeRGB, uint modeAlpha)
    {
      glBlendEquationSeparateiARB del = (glBlendEquationSeparateiARB)GetProc<glBlendEquationSeparateiARB>();
      del(buf, modeRGB, modeAlpha);
    }

    public static void BlendEquationSeparateIndexedAMD(uint buf, uint modeRGB, uint modeAlpha)
    {
      glBlendEquationSeparateIndexedAMD del = (glBlendEquationSeparateIndexedAMD)GetProc<glBlendEquationSeparateIndexedAMD>();
      del(buf, modeRGB, modeAlpha);
    }

    public static void BlendFunci(uint buf, uint src, uint dst)
    {
      glBlendFunci del = (glBlendFunci)GetProc<glBlendFunci>();
      del(buf, src, dst);
    }

    public static void BlendFunciARB(uint buf, uint src, uint dst)
    {
      glBlendFunciARB del = (glBlendFunciARB)GetProc<glBlendFunciARB>();
      del(buf, src, dst);
    }

    public static void BlendFuncIndexedAMD(uint buf, uint src, uint dst)
    {
      glBlendFuncIndexedAMD del = (glBlendFuncIndexedAMD)GetProc<glBlendFuncIndexedAMD>();
      del(buf, src, dst);
    }

    public static void BlendFuncSeparate(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha)
    {
      glBlendFuncSeparate del = (glBlendFuncSeparate)GetProc<glBlendFuncSeparate>();
      del(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha);
    }

    public static void BlendFuncSeparateEXT(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha)
    {
      glBlendFuncSeparateEXT del = (glBlendFuncSeparateEXT)GetProc<glBlendFuncSeparateEXT>();
      del(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha);
    }

    public static void BlendFuncSeparatei(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha)
    {
      glBlendFuncSeparatei del = (glBlendFuncSeparatei)GetProc<glBlendFuncSeparatei>();
      del(buf, srcRGB, dstRGB, srcAlpha, dstAlpha);
    }

    public static void BlendFuncSeparateiARB(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha)
    {
      glBlendFuncSeparateiARB del = (glBlendFuncSeparateiARB)GetProc<glBlendFuncSeparateiARB>();
      del(buf, srcRGB, dstRGB, srcAlpha, dstAlpha);
    }

    public static void BlendFuncSeparateIndexedAMD(uint buf, uint srcRGB, uint dstRGB, uint srcAlpha, uint dstAlpha)
    {
      glBlendFuncSeparateIndexedAMD del = (glBlendFuncSeparateIndexedAMD)GetProc<glBlendFuncSeparateIndexedAMD>();
      del(buf, srcRGB, dstRGB, srcAlpha, dstAlpha);
    }

    public static void BlendFuncSeparateINGR(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha)
    {
      glBlendFuncSeparateINGR del = (glBlendFuncSeparateINGR)GetProc<glBlendFuncSeparateINGR>();
      del(sfactorRGB, dfactorRGB, sfactorAlpha, dfactorAlpha);
    }

    public static void BlendParameteriNV(uint pname, int value)
    {
      glBlendParameteriNV del = (glBlendParameteriNV)GetProc<glBlendParameteriNV>();
      del(pname, value);
    }

    public static void BlitFramebuffer(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter)
    {
      glBlitFramebuffer del = (glBlitFramebuffer)GetProc<glBlitFramebuffer>();
      del(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
    }

    public static void BlitFramebufferEXT(int srcX0, int srcY0, int srcX1, int srcY1, int dstX0, int dstY0, int dstX1, int dstY1, uint mask, uint filter)
    {
      glBlitFramebufferEXT del = (glBlitFramebufferEXT)GetProc<glBlitFramebufferEXT>();
      del(srcX0, srcY0, srcX1, srcY1, dstX0, dstY0, dstX1, dstY1, mask, filter);
    }

    public static void BufferAddressRangeNV(uint pname, uint index, ulong address, IntPtr length)
    {
      glBufferAddressRangeNV del = (glBufferAddressRangeNV)GetProc<glBufferAddressRangeNV>();
      del(pname, index, address, length);
    }

    public static void BufferData(uint target, IntPtr size, IntPtr data, uint usage)
    {
      glBufferData del = (glBufferData)GetProc<glBufferData>();
      del(target, size, data, usage);
    }

    public static void BufferDataARB(uint target, IntPtr size, IntPtr data, uint usage)
    {
      glBufferDataARB del = (glBufferDataARB)GetProc<glBufferDataARB>();
      del(target, size, data, usage);
    }

    public static void BufferParameteriAPPLE(uint target, uint pname, int param)
    {
      glBufferParameteriAPPLE del = (glBufferParameteriAPPLE)GetProc<glBufferParameteriAPPLE>();
      del(target, pname, param);
    }

    public static void BufferStorage(uint target, IntPtr size, IntPtr data, uint flags)
    {
      glBufferStorage del = (glBufferStorage)GetProc<glBufferStorage>();
      del(target, size, data, flags);
    }

    public static void BufferSubData(uint target, IntPtr offset, IntPtr size, IntPtr data)
    {
      glBufferSubData del = (glBufferSubData)GetProc<glBufferSubData>();
      del(target, offset, size, data);
    }

    public static void BufferSubDataARB(uint target, IntPtr offset, IntPtr size, IntPtr data)
    {
      glBufferSubDataARB del = (glBufferSubDataARB)GetProc<glBufferSubDataARB>();
      del(target, offset, size, data);
    }

    public static void ClampColor(uint target, uint clamp)
    {
      glClampColor del = (glClampColor)GetProc<glClampColor>();
      del(target, clamp);
    }

    public static void ClampColorARB(uint target, uint clamp)
    {
      glClampColorARB del = (glClampColorARB)GetProc<glClampColorARB>();
      del(target, clamp);
    }

    public static void ClearAccumxOES(int red, int green, int blue, int alpha)
    {
      glClearAccumxOES del = (glClearAccumxOES)GetProc<glClearAccumxOES>();
      del(red, green, blue, alpha);
    }

    public static void ClearBufferData(uint target, uint internalformat, uint format, uint type, IntPtr data)
    {
      glClearBufferData del = (glClearBufferData)GetProc<glClearBufferData>();
      del(target, internalformat, format, type, data);
    }

    public static void ClearBufferfi(uint buffer, int drawbuffer, float depth, int stencil)
    {
      glClearBufferfi del = (glClearBufferfi)GetProc<glClearBufferfi>();
      del(buffer, drawbuffer, depth, stencil);
    }

    public static void ClearBufferfv(uint buffer, int drawbuffer, ref float[] value)
    {
      glClearBufferfv del = (glClearBufferfv)GetProc<glClearBufferfv>();
      del(buffer, drawbuffer, ref value);
    }

    public static void ClearBufferiv(uint buffer, int drawbuffer, ref int[] value)
    {
      glClearBufferiv del = (glClearBufferiv)GetProc<glClearBufferiv>();
      del(buffer, drawbuffer, ref value);
    }

    public static void ClearBufferSubData(uint target, uint internalformat, IntPtr offset, IntPtr size, uint format, uint type, IntPtr data)
    {
      glClearBufferSubData del = (glClearBufferSubData)GetProc<glClearBufferSubData>();
      del(target, internalformat, offset, size, format, type, data);
    }

    public static void ClearBufferuiv(uint buffer, int drawbuffer, ref uint[] value)
    {
      glClearBufferuiv del = (glClearBufferuiv)GetProc<glClearBufferuiv>();
      del(buffer, drawbuffer, ref value);
    }

    public static void ClearColorIiEXT(int red, int green, int blue, int alpha)
    {
      glClearColorIiEXT del = (glClearColorIiEXT)GetProc<glClearColorIiEXT>();
      del(red, green, blue, alpha);
    }

    public static void ClearColorIuiEXT(uint red, uint green, uint blue, uint alpha)
    {
      glClearColorIuiEXT del = (glClearColorIuiEXT)GetProc<glClearColorIuiEXT>();
      del(red, green, blue, alpha);
    }

    public static void ClearColorxOES(int red, int green, int blue, int alpha)
    {
      glClearColorxOES del = (glClearColorxOES)GetProc<glClearColorxOES>();
      del(red, green, blue, alpha);
    }

    public static void ClearDepthdNV(double depth)
    {
      glClearDepthdNV del = (glClearDepthdNV)GetProc<glClearDepthdNV>();
      del(depth);
    }

    public static void ClearDepthf(float d)
    {
      glClearDepthf del = (glClearDepthf)GetProc<glClearDepthf>();
      del(d);
    }

    public static void ClearDepthfOES(float depth)
    {
      glClearDepthfOES del = (glClearDepthfOES)GetProc<glClearDepthfOES>();
      del(depth);
    }

    public static void ClearDepthxOES(int depth)
    {
      glClearDepthxOES del = (glClearDepthxOES)GetProc<glClearDepthxOES>();
      del(depth);
    }

    public static void ClearNamedBufferDataEXT(uint buffer, uint internalformat, uint format, uint type, IntPtr data)
    {
      glClearNamedBufferDataEXT del = (glClearNamedBufferDataEXT)GetProc<glClearNamedBufferDataEXT>();
      del(buffer, internalformat, format, type, data);
    }

    public static void ClearNamedBufferSubDataEXT(uint buffer, uint internalformat, uint format, uint type, IntPtr offset, IntPtr size, IntPtr data)
    {
      glClearNamedBufferSubDataEXT del = (glClearNamedBufferSubDataEXT)GetProc<glClearNamedBufferSubDataEXT>();
      del(buffer, internalformat, format, type, offset, size, data);
    }

    public static void ClearTexImage(uint texture, int level, uint format, uint type, IntPtr data)
    {
      glClearTexImage del = (glClearTexImage)GetProc<glClearTexImage>();
      del(texture, level, format, type, data);
    }

    public static void ClearTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, IntPtr data)
    {
      glClearTexSubImage del = (glClearTexSubImage)GetProc<glClearTexSubImage>();
      del(texture, level, xoffset, yoffset, zoffset, width, height, depth, format, type, data);
    }

    public static void ClientActiveTexture(uint texture)
    {
      glClientActiveTexture del = (glClientActiveTexture)GetProc<glClientActiveTexture>();
      del(texture);
    }

    public static void ClientActiveTextureARB(uint texture)
    {
      glClientActiveTextureARB del = (glClientActiveTextureARB)GetProc<glClientActiveTextureARB>();
      del(texture);
    }

    public static void ClientActiveVertexStreamATI(uint stream)
    {
      glClientActiveVertexStreamATI del = (glClientActiveVertexStreamATI)GetProc<glClientActiveVertexStreamATI>();
      del(stream);
    }

    public static void ClientAttribDefaultEXT(uint mask)
    {
      glClientAttribDefaultEXT del = (glClientAttribDefaultEXT)GetProc<glClientAttribDefaultEXT>();
      del(mask);
    }

    public static void ClipPlanefOES(uint plane, ref float[] equation)
    {
      glClipPlanefOES del = (glClipPlanefOES)GetProc<glClipPlanefOES>();
      del(plane, ref equation);
    }

    public static void ClipPlanexOES(uint plane, ref int[] equation)
    {
      glClipPlanexOES del = (glClipPlanexOES)GetProc<glClipPlanexOES>();
      del(plane, ref equation);
    }

    public static void Color3fVertex3fSUN(float r, float g, float b, float x, float y, float z)
    {
      glColor3fVertex3fSUN del = (glColor3fVertex3fSUN)GetProc<glColor3fVertex3fSUN>();
      del(r, g, b, x, y, z);
    }

    public static void Color3fVertex3fvSUN(ref float[] c, ref float[] v)
    {
      glColor3fVertex3fvSUN del = (glColor3fVertex3fvSUN)GetProc<glColor3fVertex3fvSUN>();
      del(ref c, ref v);
    }

    public static void Color3hNV(ushort red, ushort green, ushort blue)
    {
      glColor3hNV del = (glColor3hNV)GetProc<glColor3hNV>();
      del(red, green, blue);
    }

    public static void Color3hvNV(ref ushort[] v)
    {
      glColor3hvNV del = (glColor3hvNV)GetProc<glColor3hvNV>();
      del(ref v);
    }

    public static void Color3xOES(int red, int green, int blue)
    {
      glColor3xOES del = (glColor3xOES)GetProc<glColor3xOES>();
      del(red, green, blue);
    }

    public static void Color3xvOES(ref int[] components)
    {
      glColor3xvOES del = (glColor3xvOES)GetProc<glColor3xvOES>();
      del(ref components);
    }

    public static void Color4fNormal3fVertex3fSUN(float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z)
    {
      glColor4fNormal3fVertex3fSUN del = (glColor4fNormal3fVertex3fSUN)GetProc<glColor4fNormal3fVertex3fSUN>();
      del(r, g, b, a, nx, ny, nz, x, y, z);
    }

    public static void Color4fNormal3fVertex3fvSUN(ref float[] c, ref float[] n, ref float[] v)
    {
      glColor4fNormal3fVertex3fvSUN del = (glColor4fNormal3fVertex3fvSUN)GetProc<glColor4fNormal3fVertex3fvSUN>();
      del(ref c, ref n, ref v);
    }

    public static void Color4hNV(ushort red, ushort green, ushort blue, ushort alpha)
    {
      glColor4hNV del = (glColor4hNV)GetProc<glColor4hNV>();
      del(red, green, blue, alpha);
    }

    public static void Color4hvNV(ref ushort[] v)
    {
      glColor4hvNV del = (glColor4hvNV)GetProc<glColor4hvNV>();
      del(ref v);
    }

    public static void Color4ubVertex2fSUN(byte r, byte g, byte b, byte a, float x, float y)
    {
      glColor4ubVertex2fSUN del = (glColor4ubVertex2fSUN)GetProc<glColor4ubVertex2fSUN>();
      del(r, g, b, a, x, y);
    }

    public static void Color4ubVertex2fvSUN(ref byte[] c, ref float[] v)
    {
      glColor4ubVertex2fvSUN del = (glColor4ubVertex2fvSUN)GetProc<glColor4ubVertex2fvSUN>();
      del(ref c, ref v);
    }

    public static void Color4ubVertex3fSUN(byte r, byte g, byte b, byte a, float x, float y, float z)
    {
      glColor4ubVertex3fSUN del = (glColor4ubVertex3fSUN)GetProc<glColor4ubVertex3fSUN>();
      del(r, g, b, a, x, y, z);
    }

    public static void Color4ubVertex3fvSUN(ref byte[] c, ref float[] v)
    {
      glColor4ubVertex3fvSUN del = (glColor4ubVertex3fvSUN)GetProc<glColor4ubVertex3fvSUN>();
      del(ref c, ref v);
    }

    public static void Color4xOES(int red, int green, int blue, int alpha)
    {
      glColor4xOES del = (glColor4xOES)GetProc<glColor4xOES>();
      del(red, green, blue, alpha);
    }

    public static void Color4xvOES(ref int[] components)
    {
      glColor4xvOES del = (glColor4xvOES)GetProc<glColor4xvOES>();
      del(ref components);
    }

    public static void ColorFormatNV(int size, uint type, int stride)
    {
      glColorFormatNV del = (glColorFormatNV)GetProc<glColorFormatNV>();
      del(size, type, stride);
    }

    public static void ColorFragmentOp1ATI(uint op, uint dst, uint dstMask, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod)
    {
      glColorFragmentOp1ATI del = (glColorFragmentOp1ATI)GetProc<glColorFragmentOp1ATI>();
      del(op, dst, dstMask, dstMod, arg1, arg1Rep, arg1Mod);
    }

    public static void ColorFragmentOp2ATI(uint op, uint dst, uint dstMask, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod)
    {
      glColorFragmentOp2ATI del = (glColorFragmentOp2ATI)GetProc<glColorFragmentOp2ATI>();
      del(op, dst, dstMask, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod);
    }

    public static void ColorFragmentOp3ATI(uint op, uint dst, uint dstMask, uint dstMod, uint arg1, uint arg1Rep, uint arg1Mod, uint arg2, uint arg2Rep, uint arg2Mod, uint arg3, uint arg3Rep, uint arg3Mod)
    {
      glColorFragmentOp3ATI del = (glColorFragmentOp3ATI)GetProc<glColorFragmentOp3ATI>();
      del(op, dst, dstMask, dstMod, arg1, arg1Rep, arg1Mod, arg2, arg2Rep, arg2Mod, arg3, arg3Rep, arg3Mod);
    }

    public static void ColorMaski(uint index, bool r, bool g, bool b, bool a)
    {
      glColorMaski del = (glColorMaski)GetProc<glColorMaski>();
      del(index, r, g, b, a);
    }

    public static void ColorMaskIndexedEXT(uint index, bool r, bool g, bool b, bool a)
    {
      glColorMaskIndexedEXT del = (glColorMaskIndexedEXT)GetProc<glColorMaskIndexedEXT>();
      del(index, r, g, b, a);
    }

    public static void ColorP3ui(uint type, uint color)
    {
      glColorP3ui del = (glColorP3ui)GetProc<glColorP3ui>();
      del(type, color);
    }

    public static void ColorP3uiv(uint type, ref uint[] color)
    {
      glColorP3uiv del = (glColorP3uiv)GetProc<glColorP3uiv>();
      del(type, ref color);
    }

    public static void ColorP4ui(uint type, uint color)
    {
      glColorP4ui del = (glColorP4ui)GetProc<glColorP4ui>();
      del(type, color);
    }

    public static void ColorP4uiv(uint type, ref uint[] color)
    {
      glColorP4uiv del = (glColorP4uiv)GetProc<glColorP4uiv>();
      del(type, ref color);
    }

    public static void ColorPointerEXT(int size, uint type, int stride, int count, IntPtr pointer)
    {
      glColorPointerEXT del = (glColorPointerEXT)GetProc<glColorPointerEXT>();
      del(size, type, stride, count, pointer);
    }

    public static void ColorPointerListIBM(int size, uint type, int stride, IntPtr pointer, int ptrstride)
    {
      glColorPointerListIBM del = (glColorPointerListIBM)GetProc<glColorPointerListIBM>();
      del(size, type, stride, pointer, ptrstride);
    }

    public static void ColorPointervINTEL(int size, uint type, IntPtr pointer)
    {
      glColorPointervINTEL del = (glColorPointervINTEL)GetProc<glColorPointervINTEL>();
      del(size, type, pointer);
    }

    public static void ColorSubTable(uint target, int start, int count, uint format, uint type, IntPtr data)
    {
      glColorSubTable del = (glColorSubTable)GetProc<glColorSubTable>();
      del(target, start, count, format, type, data);
    }

    public static void ColorSubTableEXT(uint target, int start, int count, uint format, uint type, IntPtr data)
    {
      glColorSubTableEXT del = (glColorSubTableEXT)GetProc<glColorSubTableEXT>();
      del(target, start, count, format, type, data);
    }

    public static void ColorTable(uint target, uint internalformat, int width, uint format, uint type, IntPtr table)
    {
      glColorTable del = (glColorTable)GetProc<glColorTable>();
      del(target, internalformat, width, format, type, table);
    }

    public static void ColorTableEXT(uint target, uint internalFormat, int width, uint format, uint type, IntPtr table)
    {
      glColorTableEXT del = (glColorTableEXT)GetProc<glColorTableEXT>();
      del(target, internalFormat, width, format, type, table);
    }

    public static void ColorTableParameterfv(uint target, uint pname, ref float[] parameters)
    {
      glColorTableParameterfv del = (glColorTableParameterfv)GetProc<glColorTableParameterfv>();
      del(target, pname, ref parameters);
    }

    public static void ColorTableParameterfvSGI(uint target, uint pname, ref float[] parameters)
    {
      glColorTableParameterfvSGI del = (glColorTableParameterfvSGI)GetProc<glColorTableParameterfvSGI>();
      del(target, pname, ref parameters);
    }

    public static void ColorTableParameteriv(uint target, uint pname, ref int[] parameters)
    {
      glColorTableParameteriv del = (glColorTableParameteriv)GetProc<glColorTableParameteriv>();
      del(target, pname, ref parameters);
    }

    public static void ColorTableParameterivSGI(uint target, uint pname, ref int[] parameters)
    {
      glColorTableParameterivSGI del = (glColorTableParameterivSGI)GetProc<glColorTableParameterivSGI>();
      del(target, pname, ref parameters);
    }

    public static void ColorTableSGI(uint target, uint internalformat, int width, uint format, uint type, IntPtr table)
    {
      glColorTableSGI del = (glColorTableSGI)GetProc<glColorTableSGI>();
      del(target, internalformat, width, format, type, table);
    }

    public static void CombinerInputNV(uint stage, uint portion, uint variable, uint input, uint mapping, uint componentUsage)
    {
      glCombinerInputNV del = (glCombinerInputNV)GetProc<glCombinerInputNV>();
      del(stage, portion, variable, input, mapping, componentUsage);
    }

    public static void CombinerOutputNV(uint stage, uint portion, uint abOutput, uint cdOutput, uint sumOutput, uint scale, uint bias, bool abDotProduct, bool cdDotProduct, bool muxSum)
    {
      glCombinerOutputNV del = (glCombinerOutputNV)GetProc<glCombinerOutputNV>();
      del(stage, portion, abOutput, cdOutput, sumOutput, scale, bias, abDotProduct, cdDotProduct, muxSum);
    }

    public static void CombinerParameterfNV(uint pname, float param)
    {
      glCombinerParameterfNV del = (glCombinerParameterfNV)GetProc<glCombinerParameterfNV>();
      del(pname, param);
    }

    public static void CombinerParameterfvNV(uint pname, ref float[] parameters)
    {
      glCombinerParameterfvNV del = (glCombinerParameterfvNV)GetProc<glCombinerParameterfvNV>();
      del(pname, ref parameters);
    }

    public static void CombinerParameteriNV(uint pname, int param)
    {
      glCombinerParameteriNV del = (glCombinerParameteriNV)GetProc<glCombinerParameteriNV>();
      del(pname, param);
    }

    public static void CombinerParameterivNV(uint pname, ref int[] parameters)
    {
      glCombinerParameterivNV del = (glCombinerParameterivNV)GetProc<glCombinerParameterivNV>();
      del(pname, ref parameters);
    }

    public static void CombinerStageParameterfvNV(uint stage, uint pname, ref float[] parameters)
    {
      glCombinerStageParameterfvNV del = (glCombinerStageParameterfvNV)GetProc<glCombinerStageParameterfvNV>();
      del(stage, pname, ref parameters);
    }

    public static void CompileShader(uint shader)
    {
      glCompileShader del = (glCompileShader)GetProc<glCompileShader>();
      del(shader);
    }

    public static void CompileShaderARB(uint shaderObj)
    {
      glCompileShaderARB del = (glCompileShaderARB)GetProc<glCompileShaderARB>();
      del(shaderObj);
    }

    public static void CompileShaderIncludeARB(uint shader, int count, ref sbyte[] path, ref int[] length)
    {
      glCompileShaderIncludeARB del = (glCompileShaderIncludeARB)GetProc<glCompileShaderIncludeARB>();
      del(shader, count, ref path, ref length);
    }

    public static void CompressedMultiTexImage1DEXT(uint texunit, uint target, int level, uint internalformat, int width, int border, int imageSize, IntPtr bits)
    {
      glCompressedMultiTexImage1DEXT del = (glCompressedMultiTexImage1DEXT)GetProc<glCompressedMultiTexImage1DEXT>();
      del(texunit, target, level, internalformat, width, border, imageSize, bits);
    }

    public static void CompressedMultiTexImage2DEXT(uint texunit, uint target, int level, uint internalformat, int width, int height, int border, int imageSize, IntPtr bits)
    {
      glCompressedMultiTexImage2DEXT del = (glCompressedMultiTexImage2DEXT)GetProc<glCompressedMultiTexImage2DEXT>();
      del(texunit, target, level, internalformat, width, height, border, imageSize, bits);
    }

    public static void CompressedMultiTexImage3DEXT(uint texunit, uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, IntPtr bits)
    {
      glCompressedMultiTexImage3DEXT del = (glCompressedMultiTexImage3DEXT)GetProc<glCompressedMultiTexImage3DEXT>();
      del(texunit, target, level, internalformat, width, height, depth, border, imageSize, bits);
    }

    public static void CompressedMultiTexSubImage1DEXT(uint texunit, uint target, int level, int xoffset, int width, uint format, int imageSize, IntPtr bits)
    {
      glCompressedMultiTexSubImage1DEXT del = (glCompressedMultiTexSubImage1DEXT)GetProc<glCompressedMultiTexSubImage1DEXT>();
      del(texunit, target, level, xoffset, width, format, imageSize, bits);
    }

    public static void CompressedMultiTexSubImage2DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, IntPtr bits)
    {
      glCompressedMultiTexSubImage2DEXT del = (glCompressedMultiTexSubImage2DEXT)GetProc<glCompressedMultiTexSubImage2DEXT>();
      del(texunit, target, level, xoffset, yoffset, width, height, format, imageSize, bits);
    }

    public static void CompressedMultiTexSubImage3DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, IntPtr bits)
    {
      glCompressedMultiTexSubImage3DEXT del = (glCompressedMultiTexSubImage3DEXT)GetProc<glCompressedMultiTexSubImage3DEXT>();
      del(texunit, target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, bits);
    }

    public static void CompressedTexImage1D(uint target, int level, uint internalformat, int width, int border, int imageSize, IntPtr data)
    {
      glCompressedTexImage1D del = (glCompressedTexImage1D)GetProc<glCompressedTexImage1D>();
      del(target, level, internalformat, width, border, imageSize, data);
    }

    public static void CompressedTexImage1DARB(uint target, int level, uint internalformat, int width, int border, int imageSize, IntPtr data)
    {
      glCompressedTexImage1DARB del = (glCompressedTexImage1DARB)GetProc<glCompressedTexImage1DARB>();
      del(target, level, internalformat, width, border, imageSize, data);
    }

    public static void CompressedTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, int imageSize, IntPtr data)
    {
      glCompressedTexImage2D del = (glCompressedTexImage2D)GetProc<glCompressedTexImage2D>();
      del(target, level, internalformat, width, height, border, imageSize, data);
    }

    public static void CompressedTexImage2DARB(uint target, int level, uint internalformat, int width, int height, int border, int imageSize, IntPtr data)
    {
      glCompressedTexImage2DARB del = (glCompressedTexImage2DARB)GetProc<glCompressedTexImage2DARB>();
      del(target, level, internalformat, width, height, border, imageSize, data);
    }

    public static void CompressedTexImage3D(uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data)
    {
      glCompressedTexImage3D del = (glCompressedTexImage3D)GetProc<glCompressedTexImage3D>();
      del(target, level, internalformat, width, height, depth, border, imageSize, data);
    }

    public static void CompressedTexImage3DARB(uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data)
    {
      glCompressedTexImage3DARB del = (glCompressedTexImage3DARB)GetProc<glCompressedTexImage3DARB>();
      del(target, level, internalformat, width, height, depth, border, imageSize, data);
    }

    public static void CompressedTexSubImage1D(uint target, int level, int xoffset, int width, uint format, int imageSize, IntPtr data)
    {
      glCompressedTexSubImage1D del = (glCompressedTexSubImage1D)GetProc<glCompressedTexSubImage1D>();
      del(target, level, xoffset, width, format, imageSize, data);
    }

    public static void CompressedTexSubImage1DARB(uint target, int level, int xoffset, int width, uint format, int imageSize, IntPtr data)
    {
      glCompressedTexSubImage1DARB del = (glCompressedTexSubImage1DARB)GetProc<glCompressedTexSubImage1DARB>();
      del(target, level, xoffset, width, format, imageSize, data);
    }

    public static void CompressedTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, IntPtr data)
    {
      glCompressedTexSubImage2D del = (glCompressedTexSubImage2D)GetProc<glCompressedTexSubImage2D>();
      del(target, level, xoffset, yoffset, width, height, format, imageSize, data);
    }

    public static void CompressedTexSubImage2DARB(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, IntPtr data)
    {
      glCompressedTexSubImage2DARB del = (glCompressedTexSubImage2DARB)GetProc<glCompressedTexSubImage2DARB>();
      del(target, level, xoffset, yoffset, width, height, format, imageSize, data);
    }

    public static void CompressedTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, IntPtr data)
    {
      glCompressedTexSubImage3D del = (glCompressedTexSubImage3D)GetProc<glCompressedTexSubImage3D>();
      del(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
    }

    public static void CompressedTexSubImage3DARB(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, IntPtr data)
    {
      glCompressedTexSubImage3DARB del = (glCompressedTexSubImage3DARB)GetProc<glCompressedTexSubImage3DARB>();
      del(target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, data);
    }

    public static void CompressedTextureImage1DEXT(uint texture, uint target, int level, uint internalformat, int width, int border, int imageSize, IntPtr bits)
    {
      glCompressedTextureImage1DEXT del = (glCompressedTextureImage1DEXT)GetProc<glCompressedTextureImage1DEXT>();
      del(texture, target, level, internalformat, width, border, imageSize, bits);
    }

    public static void CompressedTextureImage2DEXT(uint texture, uint target, int level, uint internalformat, int width, int height, int border, int imageSize, IntPtr bits)
    {
      glCompressedTextureImage2DEXT del = (glCompressedTextureImage2DEXT)GetProc<glCompressedTextureImage2DEXT>();
      del(texture, target, level, internalformat, width, height, border, imageSize, bits);
    }

    public static void CompressedTextureImage3DEXT(uint texture, uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, IntPtr bits)
    {
      glCompressedTextureImage3DEXT del = (glCompressedTextureImage3DEXT)GetProc<glCompressedTextureImage3DEXT>();
      del(texture, target, level, internalformat, width, height, depth, border, imageSize, bits);
    }

    public static void CompressedTextureSubImage1DEXT(uint texture, uint target, int level, int xoffset, int width, uint format, int imageSize, IntPtr bits)
    {
      glCompressedTextureSubImage1DEXT del = (glCompressedTextureSubImage1DEXT)GetProc<glCompressedTextureSubImage1DEXT>();
      del(texture, target, level, xoffset, width, format, imageSize, bits);
    }

    public static void CompressedTextureSubImage2DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, IntPtr bits)
    {
      glCompressedTextureSubImage2DEXT del = (glCompressedTextureSubImage2DEXT)GetProc<glCompressedTextureSubImage2DEXT>();
      del(texture, target, level, xoffset, yoffset, width, height, format, imageSize, bits);
    }

    public static void CompressedTextureSubImage3DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, IntPtr bits)
    {
      glCompressedTextureSubImage3DEXT del = (glCompressedTextureSubImage3DEXT)GetProc<glCompressedTextureSubImage3DEXT>();
      del(texture, target, level, xoffset, yoffset, zoffset, width, height, depth, format, imageSize, bits);
    }

    public static void ConvolutionFilter1D(uint target, uint internalformat, int width, uint format, uint type, IntPtr image)
    {
      glConvolutionFilter1D del = (glConvolutionFilter1D)GetProc<glConvolutionFilter1D>();
      del(target, internalformat, width, format, type, image);
    }

    public static void ConvolutionFilter1DEXT(uint target, uint internalformat, int width, uint format, uint type, IntPtr image)
    {
      glConvolutionFilter1DEXT del = (glConvolutionFilter1DEXT)GetProc<glConvolutionFilter1DEXT>();
      del(target, internalformat, width, format, type, image);
    }

    public static void ConvolutionFilter2D(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr image)
    {
      glConvolutionFilter2D del = (glConvolutionFilter2D)GetProc<glConvolutionFilter2D>();
      del(target, internalformat, width, height, format, type, image);
    }

    public static void ConvolutionFilter2DEXT(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr image)
    {
      glConvolutionFilter2DEXT del = (glConvolutionFilter2DEXT)GetProc<glConvolutionFilter2DEXT>();
      del(target, internalformat, width, height, format, type, image);
    }

    public static void ConvolutionParameterf(uint target, uint pname, float parameters)
    {
      glConvolutionParameterf del = (glConvolutionParameterf)GetProc<glConvolutionParameterf>();
      del(target, pname, parameters);
    }

    public static void ConvolutionParameterfEXT(uint target, uint pname, float parameters)
    {
      glConvolutionParameterfEXT del = (glConvolutionParameterfEXT)GetProc<glConvolutionParameterfEXT>();
      del(target, pname, parameters);
    }

    public static void ConvolutionParameterfv(uint target, uint pname, ref float[] parameters)
    {
      glConvolutionParameterfv del = (glConvolutionParameterfv)GetProc<glConvolutionParameterfv>();
      del(target, pname, ref parameters);
    }

    public static void ConvolutionParameterfvEXT(uint target, uint pname, ref float[] parameters)
    {
      glConvolutionParameterfvEXT del = (glConvolutionParameterfvEXT)GetProc<glConvolutionParameterfvEXT>();
      del(target, pname, ref parameters);
    }

    public static void ConvolutionParameteri(uint target, uint pname, int parameters)
    {
      glConvolutionParameteri del = (glConvolutionParameteri)GetProc<glConvolutionParameteri>();
      del(target, pname, parameters);
    }

    public static void ConvolutionParameteriEXT(uint target, uint pname, int parameters)
    {
      glConvolutionParameteriEXT del = (glConvolutionParameteriEXT)GetProc<glConvolutionParameteriEXT>();
      del(target, pname, parameters);
    }

    public static void ConvolutionParameteriv(uint target, uint pname, ref int[] parameters)
    {
      glConvolutionParameteriv del = (glConvolutionParameteriv)GetProc<glConvolutionParameteriv>();
      del(target, pname, ref parameters);
    }

    public static void ConvolutionParameterivEXT(uint target, uint pname, ref int[] parameters)
    {
      glConvolutionParameterivEXT del = (glConvolutionParameterivEXT)GetProc<glConvolutionParameterivEXT>();
      del(target, pname, ref parameters);
    }

    public static void ConvolutionParameterxOES(uint target, uint pname, int param)
    {
      glConvolutionParameterxOES del = (glConvolutionParameterxOES)GetProc<glConvolutionParameterxOES>();
      del(target, pname, param);
    }

    public static void ConvolutionParameterxvOES(uint target, uint pname, ref int[] parameters)
    {
      glConvolutionParameterxvOES del = (glConvolutionParameterxvOES)GetProc<glConvolutionParameterxvOES>();
      del(target, pname, ref parameters);
    }

    public static void CopyBufferSubData(uint readTarget, uint writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size)
    {
      glCopyBufferSubData del = (glCopyBufferSubData)GetProc<glCopyBufferSubData>();
      del(readTarget, writeTarget, readOffset, writeOffset, size);
    }

    public static void CopyColorSubTable(uint target, int start, int x, int y, int width)
    {
      glCopyColorSubTable del = (glCopyColorSubTable)GetProc<glCopyColorSubTable>();
      del(target, start, x, y, width);
    }

    public static void CopyColorSubTableEXT(uint target, int start, int x, int y, int width)
    {
      glCopyColorSubTableEXT del = (glCopyColorSubTableEXT)GetProc<glCopyColorSubTableEXT>();
      del(target, start, x, y, width);
    }

    public static void CopyColorTable(uint target, uint internalformat, int x, int y, int width)
    {
      glCopyColorTable del = (glCopyColorTable)GetProc<glCopyColorTable>();
      del(target, internalformat, x, y, width);
    }

    public static void CopyColorTableSGI(uint target, uint internalformat, int x, int y, int width)
    {
      glCopyColorTableSGI del = (glCopyColorTableSGI)GetProc<glCopyColorTableSGI>();
      del(target, internalformat, x, y, width);
    }

    public static void CopyConvolutionFilter1D(uint target, uint internalformat, int x, int y, int width)
    {
      glCopyConvolutionFilter1D del = (glCopyConvolutionFilter1D)GetProc<glCopyConvolutionFilter1D>();
      del(target, internalformat, x, y, width);
    }

    public static void CopyConvolutionFilter1DEXT(uint target, uint internalformat, int x, int y, int width)
    {
      glCopyConvolutionFilter1DEXT del = (glCopyConvolutionFilter1DEXT)GetProc<glCopyConvolutionFilter1DEXT>();
      del(target, internalformat, x, y, width);
    }

    public static void CopyConvolutionFilter2D(uint target, uint internalformat, int x, int y, int width, int height)
    {
      glCopyConvolutionFilter2D del = (glCopyConvolutionFilter2D)GetProc<glCopyConvolutionFilter2D>();
      del(target, internalformat, x, y, width, height);
    }

    public static void CopyConvolutionFilter2DEXT(uint target, uint internalformat, int x, int y, int width, int height)
    {
      glCopyConvolutionFilter2DEXT del = (glCopyConvolutionFilter2DEXT)GetProc<glCopyConvolutionFilter2DEXT>();
      del(target, internalformat, x, y, width, height);
    }

    public static void CopyImageSubData(uint srcName, uint srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, uint dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int srcWidth, int srcHeight, int srcDepth)
    {
      glCopyImageSubData del = (glCopyImageSubData)GetProc<glCopyImageSubData>();
      del(srcName, srcTarget, srcLevel, srcX, srcY, srcZ, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, srcWidth, srcHeight, srcDepth);
    }

    public static void CopyImageSubDataNV(uint srcName, uint srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName, uint dstTarget, int dstLevel, int dstX, int dstY, int dstZ, int width, int height, int depth)
    {
      glCopyImageSubDataNV del = (glCopyImageSubDataNV)GetProc<glCopyImageSubDataNV>();
      del(srcName, srcTarget, srcLevel, srcX, srcY, srcZ, dstName, dstTarget, dstLevel, dstX, dstY, dstZ, width, height, depth);
    }

    public static void CopyMultiTexImage1DEXT(uint texunit, uint target, int level, uint internalformat, int x, int y, int width, int border)
    {
      glCopyMultiTexImage1DEXT del = (glCopyMultiTexImage1DEXT)GetProc<glCopyMultiTexImage1DEXT>();
      del(texunit, target, level, internalformat, x, y, width, border);
    }

    public static void CopyMultiTexImage2DEXT(uint texunit, uint target, int level, uint internalformat, int x, int y, int width, int height, int border)
    {
      glCopyMultiTexImage2DEXT del = (glCopyMultiTexImage2DEXT)GetProc<glCopyMultiTexImage2DEXT>();
      del(texunit, target, level, internalformat, x, y, width, height, border);
    }

    public static void CopyMultiTexSubImage1DEXT(uint texunit, uint target, int level, int xoffset, int x, int y, int width)
    {
      glCopyMultiTexSubImage1DEXT del = (glCopyMultiTexSubImage1DEXT)GetProc<glCopyMultiTexSubImage1DEXT>();
      del(texunit, target, level, xoffset, x, y, width);
    }

    public static void CopyMultiTexSubImage2DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
    {
      glCopyMultiTexSubImage2DEXT del = (glCopyMultiTexSubImage2DEXT)GetProc<glCopyMultiTexSubImage2DEXT>();
      del(texunit, target, level, xoffset, yoffset, x, y, width, height);
    }

    public static void CopyMultiTexSubImage3DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
    {
      glCopyMultiTexSubImage3DEXT del = (glCopyMultiTexSubImage3DEXT)GetProc<glCopyMultiTexSubImage3DEXT>();
      del(texunit, target, level, xoffset, yoffset, zoffset, x, y, width, height);
    }

    public static void CopyPathNV(uint resultPath, uint srcPath)
    {
      glCopyPathNV del = (glCopyPathNV)GetProc<glCopyPathNV>();
      del(resultPath, srcPath);
    }

    public static void CopyTexImage1DEXT(uint target, int level, uint internalformat, int x, int y, int width, int border)
    {
      glCopyTexImage1DEXT del = (glCopyTexImage1DEXT)GetProc<glCopyTexImage1DEXT>();
      del(target, level, internalformat, x, y, width, border);
    }

    public static void CopyTexImage2DEXT(uint target, int level, uint internalformat, int x, int y, int width, int height, int border)
    {
      glCopyTexImage2DEXT del = (glCopyTexImage2DEXT)GetProc<glCopyTexImage2DEXT>();
      del(target, level, internalformat, x, y, width, height, border);
    }

    public static void CopyTexSubImage1DEXT(uint target, int level, int xoffset, int x, int y, int width)
    {
      glCopyTexSubImage1DEXT del = (glCopyTexSubImage1DEXT)GetProc<glCopyTexSubImage1DEXT>();
      del(target, level, xoffset, x, y, width);
    }

    public static void CopyTexSubImage2DEXT(uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
    {
      glCopyTexSubImage2DEXT del = (glCopyTexSubImage2DEXT)GetProc<glCopyTexSubImage2DEXT>();
      del(target, level, xoffset, yoffset, x, y, width, height);
    }

    public static void CopyTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
    {
      glCopyTexSubImage3D del = (glCopyTexSubImage3D)GetProc<glCopyTexSubImage3D>();
      del(target, level, xoffset, yoffset, zoffset, x, y, width, height);
    }

    public static void CopyTexSubImage3DEXT(uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
    {
      glCopyTexSubImage3DEXT del = (glCopyTexSubImage3DEXT)GetProc<glCopyTexSubImage3DEXT>();
      del(target, level, xoffset, yoffset, zoffset, x, y, width, height);
    }

    public static void CopyTextureImage1DEXT(uint texture, uint target, int level, uint internalformat, int x, int y, int width, int border)
    {
      glCopyTextureImage1DEXT del = (glCopyTextureImage1DEXT)GetProc<glCopyTextureImage1DEXT>();
      del(texture, target, level, internalformat, x, y, width, border);
    }

    public static void CopyTextureImage2DEXT(uint texture, uint target, int level, uint internalformat, int x, int y, int width, int height, int border)
    {
      glCopyTextureImage2DEXT del = (glCopyTextureImage2DEXT)GetProc<glCopyTextureImage2DEXT>();
      del(texture, target, level, internalformat, x, y, width, height, border);
    }

    public static void CopyTextureSubImage1DEXT(uint texture, uint target, int level, int xoffset, int x, int y, int width)
    {
      glCopyTextureSubImage1DEXT del = (glCopyTextureSubImage1DEXT)GetProc<glCopyTextureSubImage1DEXT>();
      del(texture, target, level, xoffset, x, y, width);
    }

    public static void CopyTextureSubImage2DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int x, int y, int width, int height)
    {
      glCopyTextureSubImage2DEXT del = (glCopyTextureSubImage2DEXT)GetProc<glCopyTextureSubImage2DEXT>();
      del(texture, target, level, xoffset, yoffset, x, y, width, height);
    }

    public static void CopyTextureSubImage3DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height)
    {
      glCopyTextureSubImage3DEXT del = (glCopyTextureSubImage3DEXT)GetProc<glCopyTextureSubImage3DEXT>();
      del(texture, target, level, xoffset, yoffset, zoffset, x, y, width, height);
    }

    public static void CoverFillPathInstancedNV(int numPaths, uint pathNameType, IntPtr paths, uint pathBase, uint coverMode, uint transformType, ref float[] transformValues)
    {
      glCoverFillPathInstancedNV del = (glCoverFillPathInstancedNV)GetProc<glCoverFillPathInstancedNV>();
      del(numPaths, pathNameType, paths, pathBase, coverMode, transformType, ref transformValues);
    }

    public static void CoverFillPathNV(uint path, uint coverMode)
    {
      glCoverFillPathNV del = (glCoverFillPathNV)GetProc<glCoverFillPathNV>();
      del(path, coverMode);
    }

    public static void CoverStrokePathInstancedNV(int numPaths, uint pathNameType, IntPtr paths, uint pathBase, uint coverMode, uint transformType, ref float[] transformValues)
    {
      glCoverStrokePathInstancedNV del = (glCoverStrokePathInstancedNV)GetProc<glCoverStrokePathInstancedNV>();
      del(numPaths, pathNameType, paths, pathBase, coverMode, transformType, ref transformValues);
    }

    public static void CoverStrokePathNV(uint path, uint coverMode)
    {
      glCoverStrokePathNV del = (glCoverStrokePathNV)GetProc<glCoverStrokePathNV>();
      del(path, coverMode);
    }

    public static void CullParameterdvEXT(uint pname, ref double[] parameters)
    {
      glCullParameterdvEXT del = (glCullParameterdvEXT)GetProc<glCullParameterdvEXT>();
      del(pname, ref parameters);
    }

    public static void CullParameterfvEXT(uint pname, ref float[] parameters)
    {
      glCullParameterfvEXT del = (glCullParameterfvEXT)GetProc<glCullParameterfvEXT>();
      del(pname, ref parameters);
    }

    public static void CurrentPaletteMatrixARB(int index)
    {
      glCurrentPaletteMatrixARB del = (glCurrentPaletteMatrixARB)GetProc<glCurrentPaletteMatrixARB>();
      del(index);
    }

    public static void DebugMessageControl(uint source, uint type, uint severity, int count, ref uint[] ids, bool enabled)
    {
      glDebugMessageControl del = (glDebugMessageControl)GetProc<glDebugMessageControl>();
      del(source, type, severity, count, ref ids, enabled);
    }

    public static void DebugMessageControlARB(uint source, uint type, uint severity, int count, ref uint[] ids, bool enabled)
    {
      glDebugMessageControlARB del = (glDebugMessageControlARB)GetProc<glDebugMessageControlARB>();
      del(source, type, severity, count, ref ids, enabled);
    }

    public static void DebugMessageEnableAMD(uint category, uint severity, int count, ref uint[] ids, bool enabled)
    {
      glDebugMessageEnableAMD del = (glDebugMessageEnableAMD)GetProc<glDebugMessageEnableAMD>();
      del(category, severity, count, ref ids, enabled);
    }

    public static void DebugMessageInsert(uint source, uint type, uint id, uint severity, int length, ref sbyte[] buf)
    {
      glDebugMessageInsert del = (glDebugMessageInsert)GetProc<glDebugMessageInsert>();
      del(source, type, id, severity, length, ref buf);
    }

    public static void DebugMessageInsertAMD(uint category, uint severity, uint id, int length, ref sbyte[] buf)
    {
      glDebugMessageInsertAMD del = (glDebugMessageInsertAMD)GetProc<glDebugMessageInsertAMD>();
      del(category, severity, id, length, ref buf);
    }

    public static void DebugMessageInsertARB(uint source, uint type, uint id, uint severity, int length, ref sbyte[] buf)
    {
      glDebugMessageInsertARB del = (glDebugMessageInsertARB)GetProc<glDebugMessageInsertARB>();
      del(source, type, id, severity, length, ref buf);
    }

    public static void DeformationMap3dSGIX(uint target, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, double w1, double w2, int wstride, int worder, ref double[] points)
    {
      glDeformationMap3dSGIX del = (glDeformationMap3dSGIX)GetProc<glDeformationMap3dSGIX>();
      del(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, w1, w2, wstride, worder, ref points);
    }

    public static void DeformationMap3fSGIX(uint target, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, float w1, float w2, int wstride, int worder, ref float[] points)
    {
      glDeformationMap3fSGIX del = (glDeformationMap3fSGIX)GetProc<glDeformationMap3fSGIX>();
      del(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, w1, w2, wstride, worder, ref points);
    }

    public static void DeformSGIX(uint mask)
    {
      glDeformSGIX del = (glDeformSGIX)GetProc<glDeformSGIX>();
      del(mask);
    }

    public static void DeleteAsyncMarkersSGIX(uint marker, int range)
    {
      glDeleteAsyncMarkersSGIX del = (glDeleteAsyncMarkersSGIX)GetProc<glDeleteAsyncMarkersSGIX>();
      del(marker, range);
    }

    public static void DeleteBuffers(int n, ref uint[] buffers)
    {
      glDeleteBuffers del = (glDeleteBuffers)GetProc<glDeleteBuffers>();
      del(n, ref buffers);
    }

    public static void DeleteBuffersARB(int n, ref uint[] buffers)
    {
      glDeleteBuffersARB del = (glDeleteBuffersARB)GetProc<glDeleteBuffersARB>();
      del(n, ref buffers);
    }

    public static void DeleteFencesAPPLE(int n, ref uint[] fences)
    {
      glDeleteFencesAPPLE del = (glDeleteFencesAPPLE)GetProc<glDeleteFencesAPPLE>();
      del(n, ref fences);
    }

    public static void DeleteFencesNV(int n, ref uint[] fences)
    {
      glDeleteFencesNV del = (glDeleteFencesNV)GetProc<glDeleteFencesNV>();
      del(n, ref fences);
    }

    public static void DeleteFragmentShaderATI(uint id)
    {
      glDeleteFragmentShaderATI del = (glDeleteFragmentShaderATI)GetProc<glDeleteFragmentShaderATI>();
      del(id);
    }

    public static void DeleteFramebuffers(int n, ref uint[] framebuffers)
    {
      glDeleteFramebuffers del = (glDeleteFramebuffers)GetProc<glDeleteFramebuffers>();
      del(n, ref framebuffers);
    }

    public static void DeleteFramebuffersEXT(int n, ref uint[] framebuffers)
    {
      glDeleteFramebuffersEXT del = (glDeleteFramebuffersEXT)GetProc<glDeleteFramebuffersEXT>();
      del(n, ref framebuffers);
    }

    public static void DeleteNamedStringARB(int namelen, ref sbyte[] name)
    {
      glDeleteNamedStringARB del = (glDeleteNamedStringARB)GetProc<glDeleteNamedStringARB>();
      del(namelen, ref name);
    }

    public static void DeleteNamesAMD(uint identifier, uint num, ref uint[] names)
    {
      glDeleteNamesAMD del = (glDeleteNamesAMD)GetProc<glDeleteNamesAMD>();
      del(identifier, num, ref names);
    }

    public static void DeleteObjectARB(uint obj)
    {
      glDeleteObjectARB del = (glDeleteObjectARB)GetProc<glDeleteObjectARB>();
      del(obj);
    }

    public static void DeleteOcclusionQueriesNV(int n, ref uint[] ids)
    {
      glDeleteOcclusionQueriesNV del = (glDeleteOcclusionQueriesNV)GetProc<glDeleteOcclusionQueriesNV>();
      del(n, ref ids);
    }

    public static void DeletePathsNV(uint path, int range)
    {
      glDeletePathsNV del = (glDeletePathsNV)GetProc<glDeletePathsNV>();
      del(path, range);
    }

    public static void DeletePerfMonitorsAMD(int n, ref uint[] monitors)
    {
      glDeletePerfMonitorsAMD del = (glDeletePerfMonitorsAMD)GetProc<glDeletePerfMonitorsAMD>();
      del(n, ref monitors);
    }

    public static void DeleteProgram(uint program)
    {
      glDeleteProgram del = (glDeleteProgram)GetProc<glDeleteProgram>();
      del(program);
    }

    public static void DeleteProgramPipelines(int n, ref uint[] pipelines)
    {
      glDeleteProgramPipelines del = (glDeleteProgramPipelines)GetProc<glDeleteProgramPipelines>();
      del(n, ref pipelines);
    }

    public static void DeleteProgramsARB(int n, ref uint[] programs)
    {
      glDeleteProgramsARB del = (glDeleteProgramsARB)GetProc<glDeleteProgramsARB>();
      del(n, ref programs);
    }

    public static void DeleteProgramsNV(int n, ref uint[] programs)
    {
      glDeleteProgramsNV del = (glDeleteProgramsNV)GetProc<glDeleteProgramsNV>();
      del(n, ref programs);
    }

    public static void DeleteQueries(int n, ref uint[] ids)
    {
      glDeleteQueries del = (glDeleteQueries)GetProc<glDeleteQueries>();
      del(n, ref ids);
    }

    public static void DeleteQueriesARB(int n, ref uint[] ids)
    {
      glDeleteQueriesARB del = (glDeleteQueriesARB)GetProc<glDeleteQueriesARB>();
      del(n, ref ids);
    }

    public static void DeleteRenderbuffers(int n, ref uint[] renderbuffers)
    {
      glDeleteRenderbuffers del = (glDeleteRenderbuffers)GetProc<glDeleteRenderbuffers>();
      del(n, ref renderbuffers);
    }

    public static void DeleteRenderbuffersEXT(int n, ref uint[] renderbuffers)
    {
      glDeleteRenderbuffersEXT del = (glDeleteRenderbuffersEXT)GetProc<glDeleteRenderbuffersEXT>();
      del(n, ref renderbuffers);
    }

    public static void DeleteSamplers(int count, ref uint[] samplers)
    {
      glDeleteSamplers del = (glDeleteSamplers)GetProc<glDeleteSamplers>();
      del(count, ref samplers);
    }

    public static void DeleteShader(uint shader)
    {
      glDeleteShader del = (glDeleteShader)GetProc<glDeleteShader>();
      del(shader);
    }

    public static void DeleteSync(GLsync sync)
    {
      glDeleteSync del = (glDeleteSync)GetProc<glDeleteSync>();
      del(sync);
    }

    public static void DeleteTexturesEXT(int n, ref uint[] textures)
    {
      glDeleteTexturesEXT del = (glDeleteTexturesEXT)GetProc<glDeleteTexturesEXT>();
      del(n, ref textures);
    }

    public static void DeleteTransformFeedbacks(int n, ref uint[] ids)
    {
      glDeleteTransformFeedbacks del = (glDeleteTransformFeedbacks)GetProc<glDeleteTransformFeedbacks>();
      del(n, ref ids);
    }

    public static void DeleteTransformFeedbacksNV(int n, ref uint[] ids)
    {
      glDeleteTransformFeedbacksNV del = (glDeleteTransformFeedbacksNV)GetProc<glDeleteTransformFeedbacksNV>();
      del(n, ref ids);
    }

    public static void DeleteVertexArrays(int n, ref uint[] arrays)
    {
      glDeleteVertexArrays del = (glDeleteVertexArrays)GetProc<glDeleteVertexArrays>();
      del(n, ref arrays);
    }

    public static void DeleteVertexArraysAPPLE(int n, ref uint[] arrays)
    {
      glDeleteVertexArraysAPPLE del = (glDeleteVertexArraysAPPLE)GetProc<glDeleteVertexArraysAPPLE>();
      del(n, ref arrays);
    }

    public static void DeleteVertexShaderEXT(uint id)
    {
      glDeleteVertexShaderEXT del = (glDeleteVertexShaderEXT)GetProc<glDeleteVertexShaderEXT>();
      del(id);
    }

    public static void DepthBoundsdNV(double zmin, double zmax)
    {
      glDepthBoundsdNV del = (glDepthBoundsdNV)GetProc<glDepthBoundsdNV>();
      del(zmin, zmax);
    }

    public static void DepthBoundsEXT(double zmin, double zmax)
    {
      glDepthBoundsEXT del = (glDepthBoundsEXT)GetProc<glDepthBoundsEXT>();
      del(zmin, zmax);
    }

    public static void DepthRangeArrayv(uint first, int count, ref double[] v)
    {
      glDepthRangeArrayv del = (glDepthRangeArrayv)GetProc<glDepthRangeArrayv>();
      del(first, count, ref v);
    }

    public static void DepthRangedNV(double zNear, double zFar)
    {
      glDepthRangedNV del = (glDepthRangedNV)GetProc<glDepthRangedNV>();
      del(zNear, zFar);
    }

    public static void DepthRangef(float n, float f)
    {
      glDepthRangef del = (glDepthRangef)GetProc<glDepthRangef>();
      del(n, f);
    }

    public static void DepthRangefOES(float n, float f)
    {
      glDepthRangefOES del = (glDepthRangefOES)GetProc<glDepthRangefOES>();
      del(n, f);
    }

    public static void DepthRangeIndexed(uint index, double n, double f)
    {
      glDepthRangeIndexed del = (glDepthRangeIndexed)GetProc<glDepthRangeIndexed>();
      del(index, n, f);
    }

    public static void DepthRangexOES(int n, int f)
    {
      glDepthRangexOES del = (glDepthRangexOES)GetProc<glDepthRangexOES>();
      del(n, f);
    }

    public static void DetachObjectARB(uint containerObj, uint attachedObj)
    {
      glDetachObjectARB del = (glDetachObjectARB)GetProc<glDetachObjectARB>();
      del(containerObj, attachedObj);
    }

    public static void DetachShader(uint program, uint shader)
    {
      glDetachShader del = (glDetachShader)GetProc<glDetachShader>();
      del(program, shader);
    }

    public static void DetailTexFuncSGIS(uint target, int n, ref float[] points)
    {
      glDetailTexFuncSGIS del = (glDetailTexFuncSGIS)GetProc<glDetailTexFuncSGIS>();
      del(target, n, ref points);
    }

    public static void DisableClientStateiEXT(uint array, uint index)
    {
      glDisableClientStateiEXT del = (glDisableClientStateiEXT)GetProc<glDisableClientStateiEXT>();
      del(array, index);
    }

    public static void DisableClientStateIndexedEXT(uint array, uint index)
    {
      glDisableClientStateIndexedEXT del = (glDisableClientStateIndexedEXT)GetProc<glDisableClientStateIndexedEXT>();
      del(array, index);
    }

    public static void Disablei(uint target, uint index)
    {
      glDisablei del = (glDisablei)GetProc<glDisablei>();
      del(target, index);
    }

    public static void DisableIndexedEXT(uint target, uint index)
    {
      glDisableIndexedEXT del = (glDisableIndexedEXT)GetProc<glDisableIndexedEXT>();
      del(target, index);
    }

    public static void DisableVariantClientStateEXT(uint id)
    {
      glDisableVariantClientStateEXT del = (glDisableVariantClientStateEXT)GetProc<glDisableVariantClientStateEXT>();
      del(id);
    }

    public static void DisableVertexArrayAttribEXT(uint vaobj, uint index)
    {
      glDisableVertexArrayAttribEXT del = (glDisableVertexArrayAttribEXT)GetProc<glDisableVertexArrayAttribEXT>();
      del(vaobj, index);
    }

    public static void DisableVertexArrayEXT(uint vaobj, uint array)
    {
      glDisableVertexArrayEXT del = (glDisableVertexArrayEXT)GetProc<glDisableVertexArrayEXT>();
      del(vaobj, array);
    }

    public static void DisableVertexAttribAPPLE(uint index, uint pname)
    {
      glDisableVertexAttribAPPLE del = (glDisableVertexAttribAPPLE)GetProc<glDisableVertexAttribAPPLE>();
      del(index, pname);
    }

    public static void DisableVertexAttribArray(uint index)
    {
      glDisableVertexAttribArray del = (glDisableVertexAttribArray)GetProc<glDisableVertexAttribArray>();
      del(index);
    }

    public static void DisableVertexAttribArrayARB(uint index)
    {
      glDisableVertexAttribArrayARB del = (glDisableVertexAttribArrayARB)GetProc<glDisableVertexAttribArrayARB>();
      del(index);
    }

    public static void DispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z)
    {
      glDispatchCompute del = (glDispatchCompute)GetProc<glDispatchCompute>();
      del(num_groups_x, num_groups_y, num_groups_z);
    }

    public static void DispatchComputeGroupSizeARB(uint num_groups_x, uint num_groups_y, uint num_groups_z, uint group_size_x, uint group_size_y, uint group_size_z)
    {
      glDispatchComputeGroupSizeARB del = (glDispatchComputeGroupSizeARB)GetProc<glDispatchComputeGroupSizeARB>();
      del(num_groups_x, num_groups_y, num_groups_z, group_size_x, group_size_y, group_size_z);
    }

    public static void DispatchComputeIndirect(IntPtr indirect)
    {
      glDispatchComputeIndirect del = (glDispatchComputeIndirect)GetProc<glDispatchComputeIndirect>();
      del(indirect);
    }

    public static void DrawArraysEXT(uint mode, int first, int count)
    {
      glDrawArraysEXT del = (glDrawArraysEXT)GetProc<glDrawArraysEXT>();
      del(mode, first, count);
    }

    public static void DrawArraysIndirect(uint mode, IntPtr indirect)
    {
      glDrawArraysIndirect del = (glDrawArraysIndirect)GetProc<glDrawArraysIndirect>();
      del(mode, indirect);
    }

    public static void DrawArraysInstanced(uint mode, int first, int count, int instancecount)
    {
      glDrawArraysInstanced del = (glDrawArraysInstanced)GetProc<glDrawArraysInstanced>();
      del(mode, first, count, instancecount);
    }

    public static void DrawArraysInstancedARB(uint mode, int first, int count, int primcount)
    {
      glDrawArraysInstancedARB del = (glDrawArraysInstancedARB)GetProc<glDrawArraysInstancedARB>();
      del(mode, first, count, primcount);
    }

    public static void DrawArraysInstancedBaseInstance(uint mode, int first, int count, int instancecount, uint baseinstance)
    {
      glDrawArraysInstancedBaseInstance del = (glDrawArraysInstancedBaseInstance)GetProc<glDrawArraysInstancedBaseInstance>();
      del(mode, first, count, instancecount, baseinstance);
    }

    public static void DrawArraysInstancedEXT(uint mode, int start, int count, int primcount)
    {
      glDrawArraysInstancedEXT del = (glDrawArraysInstancedEXT)GetProc<glDrawArraysInstancedEXT>();
      del(mode, start, count, primcount);
    }

    public static void DrawBuffers(int n, ref uint[] bufs)
    {
      glDrawBuffers del = (glDrawBuffers)GetProc<glDrawBuffers>();
      del(n, ref bufs);
    }

    public static void DrawBuffersARB(int n, ref uint[] bufs)
    {
      glDrawBuffersARB del = (glDrawBuffersARB)GetProc<glDrawBuffersARB>();
      del(n, ref bufs);
    }

    public static void DrawBuffersATI(int n, ref uint[] bufs)
    {
      glDrawBuffersATI del = (glDrawBuffersATI)GetProc<glDrawBuffersATI>();
      del(n, ref bufs);
    }

    public static void DrawElementArrayAPPLE(uint mode, int first, int count)
    {
      glDrawElementArrayAPPLE del = (glDrawElementArrayAPPLE)GetProc<glDrawElementArrayAPPLE>();
      del(mode, first, count);
    }

    public static void DrawElementArrayATI(uint mode, int count)
    {
      glDrawElementArrayATI del = (glDrawElementArrayATI)GetProc<glDrawElementArrayATI>();
      del(mode, count);
    }

    public static void DrawElementsBaseVertex(uint mode, int count, uint type, IntPtr indices, int basevertex)
    {
      glDrawElementsBaseVertex del = (glDrawElementsBaseVertex)GetProc<glDrawElementsBaseVertex>();
      del(mode, count, type, indices, basevertex);
    }

    public static void DrawElementsIndirect(uint mode, uint type, IntPtr indirect)
    {
      glDrawElementsIndirect del = (glDrawElementsIndirect)GetProc<glDrawElementsIndirect>();
      del(mode, type, indirect);
    }

    public static void DrawElementsInstanced(uint mode, int count, uint type, IntPtr indices, int instancecount)
    {
      glDrawElementsInstanced del = (glDrawElementsInstanced)GetProc<glDrawElementsInstanced>();
      del(mode, count, type, indices, instancecount);
    }

    public static void DrawElementsInstancedARB(uint mode, int count, uint type, IntPtr indices, int primcount)
    {
      glDrawElementsInstancedARB del = (glDrawElementsInstancedARB)GetProc<glDrawElementsInstancedARB>();
      del(mode, count, type, indices, primcount);
    }

    public static void DrawElementsInstancedBaseInstance(uint mode, int count, uint type, IntPtr indices, int instancecount, uint baseinstance)
    {
      glDrawElementsInstancedBaseInstance del = (glDrawElementsInstancedBaseInstance)GetProc<glDrawElementsInstancedBaseInstance>();
      del(mode, count, type, indices, instancecount, baseinstance);
    }

    public static void DrawElementsInstancedBaseVertex(uint mode, int count, uint type, IntPtr indices, int instancecount, int basevertex)
    {
      glDrawElementsInstancedBaseVertex del = (glDrawElementsInstancedBaseVertex)GetProc<glDrawElementsInstancedBaseVertex>();
      del(mode, count, type, indices, instancecount, basevertex);
    }

    public static void DrawElementsInstancedBaseVertexBaseInstance(uint mode, int count, uint type, IntPtr indices, int instancecount, int basevertex, uint baseinstance)
    {
      glDrawElementsInstancedBaseVertexBaseInstance del = (glDrawElementsInstancedBaseVertexBaseInstance)GetProc<glDrawElementsInstancedBaseVertexBaseInstance>();
      del(mode, count, type, indices, instancecount, basevertex, baseinstance);
    }

    public static void DrawElementsInstancedEXT(uint mode, int count, uint type, IntPtr indices, int primcount)
    {
      glDrawElementsInstancedEXT del = (glDrawElementsInstancedEXT)GetProc<glDrawElementsInstancedEXT>();
      del(mode, count, type, indices, primcount);
    }

    public static void DrawMeshArraysSUN(uint mode, int first, int count, int width)
    {
      glDrawMeshArraysSUN del = (glDrawMeshArraysSUN)GetProc<glDrawMeshArraysSUN>();
      del(mode, first, count, width);
    }

    public static void DrawRangeElementArrayAPPLE(uint mode, uint start, uint end, int first, int count)
    {
      glDrawRangeElementArrayAPPLE del = (glDrawRangeElementArrayAPPLE)GetProc<glDrawRangeElementArrayAPPLE>();
      del(mode, start, end, first, count);
    }

    public static void DrawRangeElementArrayATI(uint mode, uint start, uint end, int count)
    {
      glDrawRangeElementArrayATI del = (glDrawRangeElementArrayATI)GetProc<glDrawRangeElementArrayATI>();
      del(mode, start, end, count);
    }

    public static void DrawRangeElements(uint mode, uint start, uint end, int count, uint type, IntPtr indices)
    {
      glDrawRangeElements del = (glDrawRangeElements)GetProc<glDrawRangeElements>();
      del(mode, start, end, count, type, indices);
    }

    public static void DrawRangeElementsBaseVertex(uint mode, uint start, uint end, int count, uint type, IntPtr indices, int basevertex)
    {
      glDrawRangeElementsBaseVertex del = (glDrawRangeElementsBaseVertex)GetProc<glDrawRangeElementsBaseVertex>();
      del(mode, start, end, count, type, indices, basevertex);
    }

    public static void DrawRangeElementsEXT(uint mode, uint start, uint end, int count, uint type, IntPtr indices)
    {
      glDrawRangeElementsEXT del = (glDrawRangeElementsEXT)GetProc<glDrawRangeElementsEXT>();
      del(mode, start, end, count, type, indices);
    }

    public static void DrawTextureNV(uint texture, uint sampler, float x0, float y0, float x1, float y1, float z, float s0, float t0, float s1, float t1)
    {
      glDrawTextureNV del = (glDrawTextureNV)GetProc<glDrawTextureNV>();
      del(texture, sampler, x0, y0, x1, y1, z, s0, t0, s1, t1);
    }

    public static void DrawTransformFeedback(uint mode, uint id)
    {
      glDrawTransformFeedback del = (glDrawTransformFeedback)GetProc<glDrawTransformFeedback>();
      del(mode, id);
    }

    public static void DrawTransformFeedbackInstanced(uint mode, uint id, int instancecount)
    {
      glDrawTransformFeedbackInstanced del = (glDrawTransformFeedbackInstanced)GetProc<glDrawTransformFeedbackInstanced>();
      del(mode, id, instancecount);
    }

    public static void DrawTransformFeedbackNV(uint mode, uint id)
    {
      glDrawTransformFeedbackNV del = (glDrawTransformFeedbackNV)GetProc<glDrawTransformFeedbackNV>();
      del(mode, id);
    }

    public static void DrawTransformFeedbackStream(uint mode, uint id, uint stream)
    {
      glDrawTransformFeedbackStream del = (glDrawTransformFeedbackStream)GetProc<glDrawTransformFeedbackStream>();
      del(mode, id, stream);
    }

    public static void DrawTransformFeedbackStreamInstanced(uint mode, uint id, uint stream, int instancecount)
    {
      glDrawTransformFeedbackStreamInstanced del = (glDrawTransformFeedbackStreamInstanced)GetProc<glDrawTransformFeedbackStreamInstanced>();
      del(mode, id, stream, instancecount);
    }

    public static void EdgeFlagFormatNV(int stride)
    {
      glEdgeFlagFormatNV del = (glEdgeFlagFormatNV)GetProc<glEdgeFlagFormatNV>();
      del(stride);
    }

    public static void EdgeFlagPointerEXT(int stride, int count, ref byte[] pointer)
    {
      glEdgeFlagPointerEXT del = (glEdgeFlagPointerEXT)GetProc<glEdgeFlagPointerEXT>();
      del(stride, count, ref pointer);
    }

    public static void EdgeFlagPointerListIBM(int stride, IntPtr pointer, int ptrstride)
    {
      glEdgeFlagPointerListIBM del = (glEdgeFlagPointerListIBM)GetProc<glEdgeFlagPointerListIBM>();
      del(stride, pointer, ptrstride);
    }

    public static void ElementPointerAPPLE(uint type, IntPtr pointer)
    {
      glElementPointerAPPLE del = (glElementPointerAPPLE)GetProc<glElementPointerAPPLE>();
      del(type, pointer);
    }

    public static void ElementPointerATI(uint type, IntPtr pointer)
    {
      glElementPointerATI del = (glElementPointerATI)GetProc<glElementPointerATI>();
      del(type, pointer);
    }

    public static void EnableClientStateiEXT(uint array, uint index)
    {
      glEnableClientStateiEXT del = (glEnableClientStateiEXT)GetProc<glEnableClientStateiEXT>();
      del(array, index);
    }

    public static void EnableClientStateIndexedEXT(uint array, uint index)
    {
      glEnableClientStateIndexedEXT del = (glEnableClientStateIndexedEXT)GetProc<glEnableClientStateIndexedEXT>();
      del(array, index);
    }

    public static void Enablei(uint target, uint index)
    {
      glEnablei del = (glEnablei)GetProc<glEnablei>();
      del(target, index);
    }

    public static void EnableIndexedEXT(uint target, uint index)
    {
      glEnableIndexedEXT del = (glEnableIndexedEXT)GetProc<glEnableIndexedEXT>();
      del(target, index);
    }

    public static void EnableVariantClientStateEXT(uint id)
    {
      glEnableVariantClientStateEXT del = (glEnableVariantClientStateEXT)GetProc<glEnableVariantClientStateEXT>();
      del(id);
    }

    public static void EnableVertexArrayAttribEXT(uint vaobj, uint index)
    {
      glEnableVertexArrayAttribEXT del = (glEnableVertexArrayAttribEXT)GetProc<glEnableVertexArrayAttribEXT>();
      del(vaobj, index);
    }

    public static void EnableVertexArrayEXT(uint vaobj, uint array)
    {
      glEnableVertexArrayEXT del = (glEnableVertexArrayEXT)GetProc<glEnableVertexArrayEXT>();
      del(vaobj, array);
    }

    public static void EnableVertexAttribAPPLE(uint index, uint pname)
    {
      glEnableVertexAttribAPPLE del = (glEnableVertexAttribAPPLE)GetProc<glEnableVertexAttribAPPLE>();
      del(index, pname);
    }

    public static void EnableVertexAttribArray(uint index)
    {
      glEnableVertexAttribArray del = (glEnableVertexAttribArray)GetProc<glEnableVertexAttribArray>();
      del(index);
    }

    public static void EnableVertexAttribArrayARB(uint index)
    {
      glEnableVertexAttribArrayARB del = (glEnableVertexAttribArrayARB)GetProc<glEnableVertexAttribArrayARB>();
      del(index);
    }

    public static void EndConditionalRender()
    {
      glEndConditionalRender del = (glEndConditionalRender)GetProc<glEndConditionalRender>();
      del();
    }

    public static void EndConditionalRenderNV()
    {
      glEndConditionalRenderNV del = (glEndConditionalRenderNV)GetProc<glEndConditionalRenderNV>();
      del();
    }

    public static void EndConditionalRenderNVX()
    {
      glEndConditionalRenderNVX del = (glEndConditionalRenderNVX)GetProc<glEndConditionalRenderNVX>();
      del();
    }

    public static void EndFragmentShaderATI()
    {
      glEndFragmentShaderATI del = (glEndFragmentShaderATI)GetProc<glEndFragmentShaderATI>();
      del();
    }

    public static void EndOcclusionQueryNV()
    {
      glEndOcclusionQueryNV del = (glEndOcclusionQueryNV)GetProc<glEndOcclusionQueryNV>();
      del();
    }

    public static void EndPerfMonitorAMD(uint monitor)
    {
      glEndPerfMonitorAMD del = (glEndPerfMonitorAMD)GetProc<glEndPerfMonitorAMD>();
      del(monitor);
    }

    public static void EndQuery(uint target)
    {
      glEndQuery del = (glEndQuery)GetProc<glEndQuery>();
      del(target);
    }

    public static void EndQueryARB(uint target)
    {
      glEndQueryARB del = (glEndQueryARB)GetProc<glEndQueryARB>();
      del(target);
    }

    public static void EndQueryIndexed(uint target, uint index)
    {
      glEndQueryIndexed del = (glEndQueryIndexed)GetProc<glEndQueryIndexed>();
      del(target, index);
    }

    public static void EndTransformFeedback()
    {
      glEndTransformFeedback del = (glEndTransformFeedback)GetProc<glEndTransformFeedback>();
      del();
    }

    public static void EndTransformFeedbackEXT()
    {
      glEndTransformFeedbackEXT del = (glEndTransformFeedbackEXT)GetProc<glEndTransformFeedbackEXT>();
      del();
    }

    public static void EndTransformFeedbackNV()
    {
      glEndTransformFeedbackNV del = (glEndTransformFeedbackNV)GetProc<glEndTransformFeedbackNV>();
      del();
    }

    public static void EndVertexShaderEXT()
    {
      glEndVertexShaderEXT del = (glEndVertexShaderEXT)GetProc<glEndVertexShaderEXT>();
      del();
    }

    public static void EndVideoCaptureNV(uint video_capture_slot)
    {
      glEndVideoCaptureNV del = (glEndVideoCaptureNV)GetProc<glEndVideoCaptureNV>();
      del(video_capture_slot);
    }

    public static void EvalCoord1xOES(int u)
    {
      glEvalCoord1xOES del = (glEvalCoord1xOES)GetProc<glEvalCoord1xOES>();
      del(u);
    }

    public static void EvalCoord1xvOES(ref int[] coords)
    {
      glEvalCoord1xvOES del = (glEvalCoord1xvOES)GetProc<glEvalCoord1xvOES>();
      del(ref coords);
    }

    public static void EvalCoord2xOES(int u, int v)
    {
      glEvalCoord2xOES del = (glEvalCoord2xOES)GetProc<glEvalCoord2xOES>();
      del(u, v);
    }

    public static void EvalCoord2xvOES(ref int[] coords)
    {
      glEvalCoord2xvOES del = (glEvalCoord2xvOES)GetProc<glEvalCoord2xvOES>();
      del(ref coords);
    }

    public static void EvalMapsNV(uint target, uint mode)
    {
      glEvalMapsNV del = (glEvalMapsNV)GetProc<glEvalMapsNV>();
      del(target, mode);
    }

    public static void ExecuteProgramNV(uint target, uint id, ref float[] parameters)
    {
      glExecuteProgramNV del = (glExecuteProgramNV)GetProc<glExecuteProgramNV>();
      del(target, id, ref parameters);
    }

    public static void ExtractComponentEXT(uint res, uint src, uint num)
    {
      glExtractComponentEXT del = (glExtractComponentEXT)GetProc<glExtractComponentEXT>();
      del(res, src, num);
    }

    public static void FeedbackBufferxOES(int n, uint type, ref int[] buffer)
    {
      glFeedbackBufferxOES del = (glFeedbackBufferxOES)GetProc<glFeedbackBufferxOES>();
      del(n, type, ref buffer);
    }

    public static void FinalCombinerInputNV(uint variable, uint input, uint mapping, uint componentUsage)
    {
      glFinalCombinerInputNV del = (glFinalCombinerInputNV)GetProc<glFinalCombinerInputNV>();
      del(variable, input, mapping, componentUsage);
    }

    public static void FinishFenceAPPLE(uint fence)
    {
      glFinishFenceAPPLE del = (glFinishFenceAPPLE)GetProc<glFinishFenceAPPLE>();
      del(fence);
    }

    public static void FinishFenceNV(uint fence)
    {
      glFinishFenceNV del = (glFinishFenceNV)GetProc<glFinishFenceNV>();
      del(fence);
    }

    public static void FinishObjectAPPLE(uint obj, int name)
    {
      glFinishObjectAPPLE del = (glFinishObjectAPPLE)GetProc<glFinishObjectAPPLE>();
      del(obj, name);
    }

    public static void FinishTextureSUNX()
    {
      glFinishTextureSUNX del = (glFinishTextureSUNX)GetProc<glFinishTextureSUNX>();
      del();
    }

    public static void FlushMappedBufferRange(uint target, IntPtr offset, IntPtr length)
    {
      glFlushMappedBufferRange del = (glFlushMappedBufferRange)GetProc<glFlushMappedBufferRange>();
      del(target, offset, length);
    }

    public static void FlushMappedBufferRangeAPPLE(uint target, IntPtr offset, IntPtr size)
    {
      glFlushMappedBufferRangeAPPLE del = (glFlushMappedBufferRangeAPPLE)GetProc<glFlushMappedBufferRangeAPPLE>();
      del(target, offset, size);
    }

    public static void FlushMappedNamedBufferRangeEXT(uint buffer, IntPtr offset, IntPtr length)
    {
      glFlushMappedNamedBufferRangeEXT del = (glFlushMappedNamedBufferRangeEXT)GetProc<glFlushMappedNamedBufferRangeEXT>();
      del(buffer, offset, length);
    }

    public static void FlushPixelDataRangeNV(uint target)
    {
      glFlushPixelDataRangeNV del = (glFlushPixelDataRangeNV)GetProc<glFlushPixelDataRangeNV>();
      del(target);
    }

    public static void FlushRasterSGIX()
    {
      glFlushRasterSGIX del = (glFlushRasterSGIX)GetProc<glFlushRasterSGIX>();
      del();
    }

    public static void FlushStaticDataIBM(uint target)
    {
      glFlushStaticDataIBM del = (glFlushStaticDataIBM)GetProc<glFlushStaticDataIBM>();
      del(target);
    }

    public static void FlushVertexArrayRangeAPPLE(int length, IntPtr pointer)
    {
      glFlushVertexArrayRangeAPPLE del = (glFlushVertexArrayRangeAPPLE)GetProc<glFlushVertexArrayRangeAPPLE>();
      del(length, pointer);
    }

    public static void FlushVertexArrayRangeNV()
    {
      glFlushVertexArrayRangeNV del = (glFlushVertexArrayRangeNV)GetProc<glFlushVertexArrayRangeNV>();
      del();
    }

    public static void FogCoordd(double coord)
    {
      glFogCoordd del = (glFogCoordd)GetProc<glFogCoordd>();
      del(coord);
    }

    public static void FogCoorddEXT(double coord)
    {
      glFogCoorddEXT del = (glFogCoorddEXT)GetProc<glFogCoorddEXT>();
      del(coord);
    }

    public static void FogCoorddv(ref double[] coord)
    {
      glFogCoorddv del = (glFogCoorddv)GetProc<glFogCoorddv>();
      del(ref coord);
    }

    public static void FogCoorddvEXT(ref double[] coord)
    {
      glFogCoorddvEXT del = (glFogCoorddvEXT)GetProc<glFogCoorddvEXT>();
      del(ref coord);
    }

    public static void FogCoordf(float coord)
    {
      glFogCoordf del = (glFogCoordf)GetProc<glFogCoordf>();
      del(coord);
    }

    public static void FogCoordfEXT(float coord)
    {
      glFogCoordfEXT del = (glFogCoordfEXT)GetProc<glFogCoordfEXT>();
      del(coord);
    }

    public static void FogCoordFormatNV(uint type, int stride)
    {
      glFogCoordFormatNV del = (glFogCoordFormatNV)GetProc<glFogCoordFormatNV>();
      del(type, stride);
    }

    public static void FogCoordfv(ref float[] coord)
    {
      glFogCoordfv del = (glFogCoordfv)GetProc<glFogCoordfv>();
      del(ref coord);
    }

    public static void FogCoordfvEXT(ref float[] coord)
    {
      glFogCoordfvEXT del = (glFogCoordfvEXT)GetProc<glFogCoordfvEXT>();
      del(ref coord);
    }

    public static void FogCoordhNV(ushort fog)
    {
      glFogCoordhNV del = (glFogCoordhNV)GetProc<glFogCoordhNV>();
      del(fog);
    }

    public static void FogCoordhvNV(ref ushort[] fog)
    {
      glFogCoordhvNV del = (glFogCoordhvNV)GetProc<glFogCoordhvNV>();
      del(ref fog);
    }

    public static void FogCoordPointer(uint type, int stride, IntPtr pointer)
    {
      glFogCoordPointer del = (glFogCoordPointer)GetProc<glFogCoordPointer>();
      del(type, stride, pointer);
    }

    public static void FogCoordPointerEXT(uint type, int stride, IntPtr pointer)
    {
      glFogCoordPointerEXT del = (glFogCoordPointerEXT)GetProc<glFogCoordPointerEXT>();
      del(type, stride, pointer);
    }

    public static void FogCoordPointerListIBM(uint type, int stride, IntPtr pointer, int ptrstride)
    {
      glFogCoordPointerListIBM del = (glFogCoordPointerListIBM)GetProc<glFogCoordPointerListIBM>();
      del(type, stride, pointer, ptrstride);
    }

    public static void FogFuncSGIS(int n, ref float[] points)
    {
      glFogFuncSGIS del = (glFogFuncSGIS)GetProc<glFogFuncSGIS>();
      del(n, ref points);
    }

    public static void FogxOES(uint pname, int param)
    {
      glFogxOES del = (glFogxOES)GetProc<glFogxOES>();
      del(pname, param);
    }

    public static void FogxvOES(uint pname, ref int[] param)
    {
      glFogxvOES del = (glFogxvOES)GetProc<glFogxvOES>();
      del(pname, ref param);
    }

    public static void FragmentColorMaterialSGIX(uint face, uint mode)
    {
      glFragmentColorMaterialSGIX del = (glFragmentColorMaterialSGIX)GetProc<glFragmentColorMaterialSGIX>();
      del(face, mode);
    }

    public static void FragmentLightfSGIX(uint light, uint pname, float param)
    {
      glFragmentLightfSGIX del = (glFragmentLightfSGIX)GetProc<glFragmentLightfSGIX>();
      del(light, pname, param);
    }

    public static void FragmentLightfvSGIX(uint light, uint pname, ref float[] parameters)
    {
      glFragmentLightfvSGIX del = (glFragmentLightfvSGIX)GetProc<glFragmentLightfvSGIX>();
      del(light, pname, ref parameters);
    }

    public static void FragmentLightiSGIX(uint light, uint pname, int param)
    {
      glFragmentLightiSGIX del = (glFragmentLightiSGIX)GetProc<glFragmentLightiSGIX>();
      del(light, pname, param);
    }

    public static void FragmentLightivSGIX(uint light, uint pname, ref int[] parameters)
    {
      glFragmentLightivSGIX del = (glFragmentLightivSGIX)GetProc<glFragmentLightivSGIX>();
      del(light, pname, ref parameters);
    }

    public static void FragmentLightModelfSGIX(uint pname, float param)
    {
      glFragmentLightModelfSGIX del = (glFragmentLightModelfSGIX)GetProc<glFragmentLightModelfSGIX>();
      del(pname, param);
    }

    public static void FragmentLightModelfvSGIX(uint pname, ref float[] parameters)
    {
      glFragmentLightModelfvSGIX del = (glFragmentLightModelfvSGIX)GetProc<glFragmentLightModelfvSGIX>();
      del(pname, ref parameters);
    }

    public static void FragmentLightModeliSGIX(uint pname, int param)
    {
      glFragmentLightModeliSGIX del = (glFragmentLightModeliSGIX)GetProc<glFragmentLightModeliSGIX>();
      del(pname, param);
    }

    public static void FragmentLightModelivSGIX(uint pname, ref int[] parameters)
    {
      glFragmentLightModelivSGIX del = (glFragmentLightModelivSGIX)GetProc<glFragmentLightModelivSGIX>();
      del(pname, ref parameters);
    }

    public static void FragmentMaterialfSGIX(uint face, uint pname, float param)
    {
      glFragmentMaterialfSGIX del = (glFragmentMaterialfSGIX)GetProc<glFragmentMaterialfSGIX>();
      del(face, pname, param);
    }

    public static void FragmentMaterialfvSGIX(uint face, uint pname, ref float[] parameters)
    {
      glFragmentMaterialfvSGIX del = (glFragmentMaterialfvSGIX)GetProc<glFragmentMaterialfvSGIX>();
      del(face, pname, ref parameters);
    }

    public static void FragmentMaterialiSGIX(uint face, uint pname, int param)
    {
      glFragmentMaterialiSGIX del = (glFragmentMaterialiSGIX)GetProc<glFragmentMaterialiSGIX>();
      del(face, pname, param);
    }

    public static void FragmentMaterialivSGIX(uint face, uint pname, ref int[] parameters)
    {
      glFragmentMaterialivSGIX del = (glFragmentMaterialivSGIX)GetProc<glFragmentMaterialivSGIX>();
      del(face, pname, ref parameters);
    }

    public static void FramebufferDrawBufferEXT(uint framebuffer, uint mode)
    {
      glFramebufferDrawBufferEXT del = (glFramebufferDrawBufferEXT)GetProc<glFramebufferDrawBufferEXT>();
      del(framebuffer, mode);
    }

    public static void FramebufferDrawBuffersEXT(uint framebuffer, int n, ref uint[] bufs)
    {
      glFramebufferDrawBuffersEXT del = (glFramebufferDrawBuffersEXT)GetProc<glFramebufferDrawBuffersEXT>();
      del(framebuffer, n, ref bufs);
    }

    public static void FramebufferParameteri(uint target, uint pname, int param)
    {
      glFramebufferParameteri del = (glFramebufferParameteri)GetProc<glFramebufferParameteri>();
      del(target, pname, param);
    }

    public static void FramebufferReadBufferEXT(uint framebuffer, uint mode)
    {
      glFramebufferReadBufferEXT del = (glFramebufferReadBufferEXT)GetProc<glFramebufferReadBufferEXT>();
      del(framebuffer, mode);
    }

    public static void FramebufferRenderbuffer(uint target, uint attachment, uint renderbuffertarget, uint renderbuffer)
    {
      glFramebufferRenderbuffer del = (glFramebufferRenderbuffer)GetProc<glFramebufferRenderbuffer>();
      del(target, attachment, renderbuffertarget, renderbuffer);
    }

    public static void FramebufferRenderbufferEXT(uint target, uint attachment, uint renderbuffertarget, uint renderbuffer)
    {
      glFramebufferRenderbufferEXT del = (glFramebufferRenderbufferEXT)GetProc<glFramebufferRenderbufferEXT>();
      del(target, attachment, renderbuffertarget, renderbuffer);
    }

    public static void FramebufferTexture(uint target, uint attachment, uint texture, int level)
    {
      glFramebufferTexture del = (glFramebufferTexture)GetProc<glFramebufferTexture>();
      del(target, attachment, texture, level);
    }

    public static void FramebufferTexture1D(uint target, uint attachment, uint textarget, uint texture, int level)
    {
      glFramebufferTexture1D del = (glFramebufferTexture1D)GetProc<glFramebufferTexture1D>();
      del(target, attachment, textarget, texture, level);
    }

    public static void FramebufferTexture1DEXT(uint target, uint attachment, uint textarget, uint texture, int level)
    {
      glFramebufferTexture1DEXT del = (glFramebufferTexture1DEXT)GetProc<glFramebufferTexture1DEXT>();
      del(target, attachment, textarget, texture, level);
    }

    public static void FramebufferTexture2D(uint target, uint attachment, uint textarget, uint texture, int level)
    {
      glFramebufferTexture2D del = (glFramebufferTexture2D)GetProc<glFramebufferTexture2D>();
      del(target, attachment, textarget, texture, level);
    }

    public static void FramebufferTexture2DEXT(uint target, uint attachment, uint textarget, uint texture, int level)
    {
      glFramebufferTexture2DEXT del = (glFramebufferTexture2DEXT)GetProc<glFramebufferTexture2DEXT>();
      del(target, attachment, textarget, texture, level);
    }

    public static void FramebufferTexture3D(uint target, uint attachment, uint textarget, uint texture, int level, int zoffset)
    {
      glFramebufferTexture3D del = (glFramebufferTexture3D)GetProc<glFramebufferTexture3D>();
      del(target, attachment, textarget, texture, level, zoffset);
    }

    public static void FramebufferTexture3DEXT(uint target, uint attachment, uint textarget, uint texture, int level, int zoffset)
    {
      glFramebufferTexture3DEXT del = (glFramebufferTexture3DEXT)GetProc<glFramebufferTexture3DEXT>();
      del(target, attachment, textarget, texture, level, zoffset);
    }

    public static void FramebufferTextureARB(uint target, uint attachment, uint texture, int level)
    {
      glFramebufferTextureARB del = (glFramebufferTextureARB)GetProc<glFramebufferTextureARB>();
      del(target, attachment, texture, level);
    }

    public static void FramebufferTextureEXT(uint target, uint attachment, uint texture, int level)
    {
      glFramebufferTextureEXT del = (glFramebufferTextureEXT)GetProc<glFramebufferTextureEXT>();
      del(target, attachment, texture, level);
    }

    public static void FramebufferTextureFaceARB(uint target, uint attachment, uint texture, int level, uint face)
    {
      glFramebufferTextureFaceARB del = (glFramebufferTextureFaceARB)GetProc<glFramebufferTextureFaceARB>();
      del(target, attachment, texture, level, face);
    }

    public static void FramebufferTextureFaceEXT(uint target, uint attachment, uint texture, int level, uint face)
    {
      glFramebufferTextureFaceEXT del = (glFramebufferTextureFaceEXT)GetProc<glFramebufferTextureFaceEXT>();
      del(target, attachment, texture, level, face);
    }

    public static void FramebufferTextureLayer(uint target, uint attachment, uint texture, int level, int layer)
    {
      glFramebufferTextureLayer del = (glFramebufferTextureLayer)GetProc<glFramebufferTextureLayer>();
      del(target, attachment, texture, level, layer);
    }

    public static void FramebufferTextureLayerARB(uint target, uint attachment, uint texture, int level, int layer)
    {
      glFramebufferTextureLayerARB del = (glFramebufferTextureLayerARB)GetProc<glFramebufferTextureLayerARB>();
      del(target, attachment, texture, level, layer);
    }

    public static void FramebufferTextureLayerEXT(uint target, uint attachment, uint texture, int level, int layer)
    {
      glFramebufferTextureLayerEXT del = (glFramebufferTextureLayerEXT)GetProc<glFramebufferTextureLayerEXT>();
      del(target, attachment, texture, level, layer);
    }

    public static void FrameTerminatorGREMEDY()
    {
      glFrameTerminatorGREMEDY del = (glFrameTerminatorGREMEDY)GetProc<glFrameTerminatorGREMEDY>();
      del();
    }

    public static void FrameZoomSGIX(int factor)
    {
      glFrameZoomSGIX del = (glFrameZoomSGIX)GetProc<glFrameZoomSGIX>();
      del(factor);
    }

    public static void FreeObjectBufferATI(uint buffer)
    {
      glFreeObjectBufferATI del = (glFreeObjectBufferATI)GetProc<glFreeObjectBufferATI>();
      del(buffer);
    }

    public static void FrustumfOES(float l, float r, float b, float t, float n, float f)
    {
      glFrustumfOES del = (glFrustumfOES)GetProc<glFrustumfOES>();
      del(l, r, b, t, n, f);
    }

    public static void FrustumxOES(int l, int r, int b, int t, int n, int f)
    {
      glFrustumxOES del = (glFrustumxOES)GetProc<glFrustumxOES>();
      del(l, r, b, t, n, f);
    }

    public static void GenBuffers(int n, ref uint[] buffers)
    {
      glGenBuffers del = (glGenBuffers)GetProc<glGenBuffers>();
      del(n, ref buffers);
    }

    public static void GenBuffersARB(int n, ref uint[] buffers)
    {
      glGenBuffersARB del = (glGenBuffersARB)GetProc<glGenBuffersARB>();
      del(n, ref buffers);
    }

    public static void GenerateMipmap(uint target)
    {
      glGenerateMipmap del = (glGenerateMipmap)GetProc<glGenerateMipmap>();
      del(target);
    }

    public static void GenerateMipmapEXT(uint target)
    {
      glGenerateMipmapEXT del = (glGenerateMipmapEXT)GetProc<glGenerateMipmapEXT>();
      del(target);
    }

    public static void GenerateMultiTexMipmapEXT(uint texunit, uint target)
    {
      glGenerateMultiTexMipmapEXT del = (glGenerateMultiTexMipmapEXT)GetProc<glGenerateMultiTexMipmapEXT>();
      del(texunit, target);
    }

    public static void GenerateTextureMipmapEXT(uint texture, uint target)
    {
      glGenerateTextureMipmapEXT del = (glGenerateTextureMipmapEXT)GetProc<glGenerateTextureMipmapEXT>();
      del(texture, target);
    }

    public static void GenFencesAPPLE(int n, ref uint[] fences)
    {
      glGenFencesAPPLE del = (glGenFencesAPPLE)GetProc<glGenFencesAPPLE>();
      del(n, ref fences);
    }

    public static void GenFencesNV(int n, ref uint[] fences)
    {
      glGenFencesNV del = (glGenFencesNV)GetProc<glGenFencesNV>();
      del(n, ref fences);
    }

    public static void GenFramebuffers(int n, ref uint[] framebuffers)
    {
      glGenFramebuffers del = (glGenFramebuffers)GetProc<glGenFramebuffers>();
      del(n, ref framebuffers);
    }

    public static void GenFramebuffersEXT(int n, ref uint[] framebuffers)
    {
      glGenFramebuffersEXT del = (glGenFramebuffersEXT)GetProc<glGenFramebuffersEXT>();
      del(n, ref framebuffers);
    }

    public static void GenNamesAMD(uint identifier, uint num, ref uint[] names)
    {
      glGenNamesAMD del = (glGenNamesAMD)GetProc<glGenNamesAMD>();
      del(identifier, num, ref names);
    }

    public static void GenOcclusionQueriesNV(int n, ref uint[] ids)
    {
      glGenOcclusionQueriesNV del = (glGenOcclusionQueriesNV)GetProc<glGenOcclusionQueriesNV>();
      del(n, ref ids);
    }

    public static void GenPerfMonitorsAMD(int n, ref uint[] monitors)
    {
      glGenPerfMonitorsAMD del = (glGenPerfMonitorsAMD)GetProc<glGenPerfMonitorsAMD>();
      del(n, ref monitors);
    }

    public static void GenProgramPipelines(int n, ref uint[] pipelines)
    {
      glGenProgramPipelines del = (glGenProgramPipelines)GetProc<glGenProgramPipelines>();
      del(n, ref pipelines);
    }

    public static void GenProgramsARB(int n, ref uint[] programs)
    {
      glGenProgramsARB del = (glGenProgramsARB)GetProc<glGenProgramsARB>();
      del(n, ref programs);
    }

    public static void GenProgramsNV(int n, ref uint[] programs)
    {
      glGenProgramsNV del = (glGenProgramsNV)GetProc<glGenProgramsNV>();
      del(n, ref programs);
    }

    public static void GenQueries(int n, ref uint[] ids)
    {
      glGenQueries del = (glGenQueries)GetProc<glGenQueries>();
      del(n, ref ids);
    }

    public static void GenQueriesARB(int n, ref uint[] ids)
    {
      glGenQueriesARB del = (glGenQueriesARB)GetProc<glGenQueriesARB>();
      del(n, ref ids);
    }

    public static void GenRenderbuffers(int n, ref uint[] renderbuffers)
    {
      glGenRenderbuffers del = (glGenRenderbuffers)GetProc<glGenRenderbuffers>();
      del(n, ref renderbuffers);
    }

    public static void GenRenderbuffersEXT(int n, ref uint[] renderbuffers)
    {
      glGenRenderbuffersEXT del = (glGenRenderbuffersEXT)GetProc<glGenRenderbuffersEXT>();
      del(n, ref renderbuffers);
    }

    public static void GenSamplers(int count, ref uint[] samplers)
    {
      glGenSamplers del = (glGenSamplers)GetProc<glGenSamplers>();
      del(count, ref samplers);
    }

    public static void GenTexturesEXT(int n, ref uint[] textures)
    {
      glGenTexturesEXT del = (glGenTexturesEXT)GetProc<glGenTexturesEXT>();
      del(n, ref textures);
    }

    public static void GenTransformFeedbacks(int n, ref uint[] ids)
    {
      glGenTransformFeedbacks del = (glGenTransformFeedbacks)GetProc<glGenTransformFeedbacks>();
      del(n, ref ids);
    }

    public static void GenTransformFeedbacksNV(int n, ref uint[] ids)
    {
      glGenTransformFeedbacksNV del = (glGenTransformFeedbacksNV)GetProc<glGenTransformFeedbacksNV>();
      del(n, ref ids);
    }

    public static void GenVertexArrays(int n, ref uint[] arrays)
    {
      glGenVertexArrays del = (glGenVertexArrays)GetProc<glGenVertexArrays>();
      del(n, ref arrays);
    }

    public static void GenVertexArraysAPPLE(int n, ref uint[] arrays)
    {
      glGenVertexArraysAPPLE del = (glGenVertexArraysAPPLE)GetProc<glGenVertexArraysAPPLE>();
      del(n, ref arrays);
    }

    public static void GetActiveAtomicCounterBufferiv(uint program, uint bufferIndex, uint pname, ref int[] parameters)
    {
      glGetActiveAtomicCounterBufferiv del = (glGetActiveAtomicCounterBufferiv)GetProc<glGetActiveAtomicCounterBufferiv>();
      del(program, bufferIndex, pname, ref parameters);
    }

    public static void GetActiveAttrib(uint program, uint index, int bufSize, ref int[] length, ref int[] size, ref uint[] type, ref sbyte[] name)
    {
      glGetActiveAttrib del = (glGetActiveAttrib)GetProc<glGetActiveAttrib>();
      del(program, index, bufSize, ref length, ref size, ref type, ref name);
    }

    public static void GetActiveAttribARB(uint programObj, uint index, int maxLength, ref int[] length, ref int[] size, ref uint[] type, ref sbyte[] name)
    {
      glGetActiveAttribARB del = (glGetActiveAttribARB)GetProc<glGetActiveAttribARB>();
      del(programObj, index, maxLength, ref length, ref size, ref type, ref name);
    }

    public static void GetActiveSubroutineName(uint program, uint shadertype, uint index, int bufsize, ref int[] length, ref sbyte[] name)
    {
      glGetActiveSubroutineName del = (glGetActiveSubroutineName)GetProc<glGetActiveSubroutineName>();
      del(program, shadertype, index, bufsize, ref length, ref name);
    }

    public static void GetActiveSubroutineUniformiv(uint program, uint shadertype, uint index, uint pname, ref int[] values)
    {
      glGetActiveSubroutineUniformiv del = (glGetActiveSubroutineUniformiv)GetProc<glGetActiveSubroutineUniformiv>();
      del(program, shadertype, index, pname, ref values);
    }

    public static void GetActiveSubroutineUniformName(uint program, uint shadertype, uint index, int bufsize, ref int[] length, ref sbyte[] name)
    {
      glGetActiveSubroutineUniformName del = (glGetActiveSubroutineUniformName)GetProc<glGetActiveSubroutineUniformName>();
      del(program, shadertype, index, bufsize, ref length, ref name);
    }

    public static void GetActiveUniform(uint program, uint index, int bufSize, ref int[] length, ref int[] size, ref uint[] type, ref sbyte[] name)
    {
      glGetActiveUniform del = (glGetActiveUniform)GetProc<glGetActiveUniform>();
      del(program, index, bufSize, ref length, ref size, ref type, ref name);
    }

    public static void GetActiveUniformARB(uint programObj, uint index, int maxLength, ref int[] length, ref int[] size, ref uint[] type, ref sbyte[] name)
    {
      glGetActiveUniformARB del = (glGetActiveUniformARB)GetProc<glGetActiveUniformARB>();
      del(programObj, index, maxLength, ref length, ref size, ref type, ref name);
    }

    public static void GetActiveUniformBlockiv(uint program, uint uniformBlockIndex, uint pname, ref int[] parameters)
    {
      glGetActiveUniformBlockiv del = (glGetActiveUniformBlockiv)GetProc<glGetActiveUniformBlockiv>();
      del(program, uniformBlockIndex, pname, ref parameters);
    }

    public static void GetActiveUniformBlockName(uint program, uint uniformBlockIndex, int bufSize, ref int[] length, ref sbyte[] uniformBlockName)
    {
      glGetActiveUniformBlockName del = (glGetActiveUniformBlockName)GetProc<glGetActiveUniformBlockName>();
      del(program, uniformBlockIndex, bufSize, ref length, ref uniformBlockName);
    }

    public static void GetActiveUniformName(uint program, uint uniformIndex, int bufSize, ref int[] length, ref sbyte[] uniformName)
    {
      glGetActiveUniformName del = (glGetActiveUniformName)GetProc<glGetActiveUniformName>();
      del(program, uniformIndex, bufSize, ref length, ref uniformName);
    }

    public static void GetActiveUniformsiv(uint program, int uniformCount, ref uint[] uniformIndices, uint pname, ref int[] parameters)
    {
      glGetActiveUniformsiv del = (glGetActiveUniformsiv)GetProc<glGetActiveUniformsiv>();
      del(program, uniformCount, ref uniformIndices, pname, ref parameters);
    }

    public static void GetActiveVaryingNV(uint program, uint index, int bufSize, ref int[] length, ref int[] size, ref uint[] type, ref sbyte[] name)
    {
      glGetActiveVaryingNV del = (glGetActiveVaryingNV)GetProc<glGetActiveVaryingNV>();
      del(program, index, bufSize, ref length, ref size, ref type, ref name);
    }

    public static void GetArrayObjectfvATI(uint array, uint pname, ref float[] parameters)
    {
      glGetArrayObjectfvATI del = (glGetArrayObjectfvATI)GetProc<glGetArrayObjectfvATI>();
      del(array, pname, ref parameters);
    }

    public static void GetArrayObjectivATI(uint array, uint pname, ref int[] parameters)
    {
      glGetArrayObjectivATI del = (glGetArrayObjectivATI)GetProc<glGetArrayObjectivATI>();
      del(array, pname, ref parameters);
    }

    public static void GetAttachedObjectsARB(uint containerObj, int maxCount, ref int[] count, ref uint[] obj)
    {
      glGetAttachedObjectsARB del = (glGetAttachedObjectsARB)GetProc<glGetAttachedObjectsARB>();
      del(containerObj, maxCount, ref count, ref obj);
    }

    public static void GetAttachedShaders(uint program, int maxCount, ref int[] count, ref uint[] shaders)
    {
      glGetAttachedShaders del = (glGetAttachedShaders)GetProc<glGetAttachedShaders>();
      del(program, maxCount, ref count, ref shaders);
    }

    public static void GetBooleani_v(uint target, uint index, ref byte[] data)
    {
      glGetBooleani_v del = (glGetBooleani_v)GetProc<glGetBooleani_v>();
      del(target, index, ref data);
    }

    public static void GetBooleanIndexedvEXT(uint target, uint index, ref byte[] data)
    {
      glGetBooleanIndexedvEXT del = (glGetBooleanIndexedvEXT)GetProc<glGetBooleanIndexedvEXT>();
      del(target, index, ref data);
    }

    public static void GetBufferParameteri64v(uint target, uint pname, ref long[] parameters)
    {
      glGetBufferParameteri64v del = (glGetBufferParameteri64v)GetProc<glGetBufferParameteri64v>();
      del(target, pname, ref parameters);
    }

    public static void GetBufferParameteriv(uint target, uint pname, ref int[] parameters)
    {
      glGetBufferParameteriv del = (glGetBufferParameteriv)GetProc<glGetBufferParameteriv>();
      del(target, pname, ref parameters);
    }

    public static void GetBufferParameterivARB(uint target, uint pname, ref int[] parameters)
    {
      glGetBufferParameterivARB del = (glGetBufferParameterivARB)GetProc<glGetBufferParameterivARB>();
      del(target, pname, ref parameters);
    }

    public static void GetBufferParameterui64vNV(uint target, uint pname, ref ulong[] parameters)
    {
      glGetBufferParameterui64vNV del = (glGetBufferParameterui64vNV)GetProc<glGetBufferParameterui64vNV>();
      del(target, pname, ref parameters);
    }

    public static void GetBufferPointerv(uint target, uint pname, IntPtr parameters)
    {
      glGetBufferPointerv del = (glGetBufferPointerv)GetProc<glGetBufferPointerv>();
      del(target, pname, parameters);
    }

    public static void GetBufferPointervARB(uint target, uint pname, IntPtr parameters)
    {
      glGetBufferPointervARB del = (glGetBufferPointervARB)GetProc<glGetBufferPointervARB>();
      del(target, pname, parameters);
    }

    public static void GetBufferSubData(uint target, IntPtr offset, IntPtr size, IntPtr data)
    {
      glGetBufferSubData del = (glGetBufferSubData)GetProc<glGetBufferSubData>();
      del(target, offset, size, data);
    }

    public static void GetBufferSubDataARB(uint target, IntPtr offset, IntPtr size, IntPtr data)
    {
      glGetBufferSubDataARB del = (glGetBufferSubDataARB)GetProc<glGetBufferSubDataARB>();
      del(target, offset, size, data);
    }

    public static void GetClipPlanefOES(uint plane, ref float[] equation)
    {
      glGetClipPlanefOES del = (glGetClipPlanefOES)GetProc<glGetClipPlanefOES>();
      del(plane, ref equation);
    }

    public static void GetClipPlanexOES(uint plane, ref int[] equation)
    {
      glGetClipPlanexOES del = (glGetClipPlanexOES)GetProc<glGetClipPlanexOES>();
      del(plane, ref equation);
    }

    public static void GetColorTable(uint target, uint format, uint type, IntPtr table)
    {
      glGetColorTable del = (glGetColorTable)GetProc<glGetColorTable>();
      del(target, format, type, table);
    }

    public static void GetColorTableEXT(uint target, uint format, uint type, IntPtr data)
    {
      glGetColorTableEXT del = (glGetColorTableEXT)GetProc<glGetColorTableEXT>();
      del(target, format, type, data);
    }

    public static void GetColorTableParameterfv(uint target, uint pname, ref float[] parameters)
    {
      glGetColorTableParameterfv del = (glGetColorTableParameterfv)GetProc<glGetColorTableParameterfv>();
      del(target, pname, ref parameters);
    }

    public static void GetColorTableParameterfvEXT(uint target, uint pname, ref float[] parameters)
    {
      glGetColorTableParameterfvEXT del = (glGetColorTableParameterfvEXT)GetProc<glGetColorTableParameterfvEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetColorTableParameterfvSGI(uint target, uint pname, ref float[] parameters)
    {
      glGetColorTableParameterfvSGI del = (glGetColorTableParameterfvSGI)GetProc<glGetColorTableParameterfvSGI>();
      del(target, pname, ref parameters);
    }

    public static void GetColorTableParameteriv(uint target, uint pname, ref int[] parameters)
    {
      glGetColorTableParameteriv del = (glGetColorTableParameteriv)GetProc<glGetColorTableParameteriv>();
      del(target, pname, ref parameters);
    }

    public static void GetColorTableParameterivEXT(uint target, uint pname, ref int[] parameters)
    {
      glGetColorTableParameterivEXT del = (glGetColorTableParameterivEXT)GetProc<glGetColorTableParameterivEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetColorTableParameterivSGI(uint target, uint pname, ref int[] parameters)
    {
      glGetColorTableParameterivSGI del = (glGetColorTableParameterivSGI)GetProc<glGetColorTableParameterivSGI>();
      del(target, pname, ref parameters);
    }

    public static void GetColorTableSGI(uint target, uint format, uint type, IntPtr table)
    {
      glGetColorTableSGI del = (glGetColorTableSGI)GetProc<glGetColorTableSGI>();
      del(target, format, type, table);
    }

    public static void GetCombinerInputParameterfvNV(uint stage, uint portion, uint variable, uint pname, ref float[] parameters)
    {
      glGetCombinerInputParameterfvNV del = (glGetCombinerInputParameterfvNV)GetProc<glGetCombinerInputParameterfvNV>();
      del(stage, portion, variable, pname, ref parameters);
    }

    public static void GetCombinerInputParameterivNV(uint stage, uint portion, uint variable, uint pname, ref int[] parameters)
    {
      glGetCombinerInputParameterivNV del = (glGetCombinerInputParameterivNV)GetProc<glGetCombinerInputParameterivNV>();
      del(stage, portion, variable, pname, ref parameters);
    }

    public static void GetCombinerOutputParameterfvNV(uint stage, uint portion, uint pname, ref float[] parameters)
    {
      glGetCombinerOutputParameterfvNV del = (glGetCombinerOutputParameterfvNV)GetProc<glGetCombinerOutputParameterfvNV>();
      del(stage, portion, pname, ref parameters);
    }

    public static void GetCombinerOutputParameterivNV(uint stage, uint portion, uint pname, ref int[] parameters)
    {
      glGetCombinerOutputParameterivNV del = (glGetCombinerOutputParameterivNV)GetProc<glGetCombinerOutputParameterivNV>();
      del(stage, portion, pname, ref parameters);
    }

    public static void GetCombinerStageParameterfvNV(uint stage, uint pname, ref float[] parameters)
    {
      glGetCombinerStageParameterfvNV del = (glGetCombinerStageParameterfvNV)GetProc<glGetCombinerStageParameterfvNV>();
      del(stage, pname, ref parameters);
    }

    public static void GetCompressedMultiTexImageEXT(uint texunit, uint target, int lod, IntPtr img)
    {
      glGetCompressedMultiTexImageEXT del = (glGetCompressedMultiTexImageEXT)GetProc<glGetCompressedMultiTexImageEXT>();
      del(texunit, target, lod, img);
    }

    public static void GetCompressedTexImage(uint target, int level, IntPtr img)
    {
      glGetCompressedTexImage del = (glGetCompressedTexImage)GetProc<glGetCompressedTexImage>();
      del(target, level, img);
    }

    public static void GetCompressedTexImageARB(uint target, int level, IntPtr img)
    {
      glGetCompressedTexImageARB del = (glGetCompressedTexImageARB)GetProc<glGetCompressedTexImageARB>();
      del(target, level, img);
    }

    public static void GetCompressedTextureImageEXT(uint texture, uint target, int lod, IntPtr img)
    {
      glGetCompressedTextureImageEXT del = (glGetCompressedTextureImageEXT)GetProc<glGetCompressedTextureImageEXT>();
      del(texture, target, lod, img);
    }

    public static void GetConvolutionFilter(uint target, uint format, uint type, IntPtr image)
    {
      glGetConvolutionFilter del = (glGetConvolutionFilter)GetProc<glGetConvolutionFilter>();
      del(target, format, type, image);
    }

    public static void GetConvolutionFilterEXT(uint target, uint format, uint type, IntPtr image)
    {
      glGetConvolutionFilterEXT del = (glGetConvolutionFilterEXT)GetProc<glGetConvolutionFilterEXT>();
      del(target, format, type, image);
    }

    public static void GetConvolutionParameterfv(uint target, uint pname, ref float[] parameters)
    {
      glGetConvolutionParameterfv del = (glGetConvolutionParameterfv)GetProc<glGetConvolutionParameterfv>();
      del(target, pname, ref parameters);
    }

    public static void GetConvolutionParameterfvEXT(uint target, uint pname, ref float[] parameters)
    {
      glGetConvolutionParameterfvEXT del = (glGetConvolutionParameterfvEXT)GetProc<glGetConvolutionParameterfvEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetConvolutionParameteriv(uint target, uint pname, ref int[] parameters)
    {
      glGetConvolutionParameteriv del = (glGetConvolutionParameteriv)GetProc<glGetConvolutionParameteriv>();
      del(target, pname, ref parameters);
    }

    public static void GetConvolutionParameterivEXT(uint target, uint pname, ref int[] parameters)
    {
      glGetConvolutionParameterivEXT del = (glGetConvolutionParameterivEXT)GetProc<glGetConvolutionParameterivEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetConvolutionParameterxvOES(uint target, uint pname, ref int[] parameters)
    {
      glGetConvolutionParameterxvOES del = (glGetConvolutionParameterxvOES)GetProc<glGetConvolutionParameterxvOES>();
      del(target, pname, ref parameters);
    }

    public static void GetDetailTexFuncSGIS(uint target, ref float[] points)
    {
      glGetDetailTexFuncSGIS del = (glGetDetailTexFuncSGIS)GetProc<glGetDetailTexFuncSGIS>();
      del(target, ref points);
    }

    public static void GetDoublei_v(uint target, uint index, ref double[] data)
    {
      glGetDoublei_v del = (glGetDoublei_v)GetProc<glGetDoublei_v>();
      del(target, index, ref data);
    }

    public static void GetDoublei_vEXT(uint pname, uint index, ref double[] parameters)
    {
      glGetDoublei_vEXT del = (glGetDoublei_vEXT)GetProc<glGetDoublei_vEXT>();
      del(pname, index, ref parameters);
    }

    public static void GetDoubleIndexedvEXT(uint target, uint index, ref double[] data)
    {
      glGetDoubleIndexedvEXT del = (glGetDoubleIndexedvEXT)GetProc<glGetDoubleIndexedvEXT>();
      del(target, index, ref data);
    }

    public static void GetFenceivNV(uint fence, uint pname, ref int[] parameters)
    {
      glGetFenceivNV del = (glGetFenceivNV)GetProc<glGetFenceivNV>();
      del(fence, pname, ref parameters);
    }

    public static void GetFinalCombinerInputParameterfvNV(uint variable, uint pname, ref float[] parameters)
    {
      glGetFinalCombinerInputParameterfvNV del = (glGetFinalCombinerInputParameterfvNV)GetProc<glGetFinalCombinerInputParameterfvNV>();
      del(variable, pname, ref parameters);
    }

    public static void GetFinalCombinerInputParameterivNV(uint variable, uint pname, ref int[] parameters)
    {
      glGetFinalCombinerInputParameterivNV del = (glGetFinalCombinerInputParameterivNV)GetProc<glGetFinalCombinerInputParameterivNV>();
      del(variable, pname, ref parameters);
    }

    public static void GetFixedvOES(uint pname, ref int[] parameters)
    {
      glGetFixedvOES del = (glGetFixedvOES)GetProc<glGetFixedvOES>();
      del(pname, ref parameters);
    }

    public static void GetFloati_v(uint target, uint index, ref float[] data)
    {
      glGetFloati_v del = (glGetFloati_v)GetProc<glGetFloati_v>();
      del(target, index, ref data);
    }

    public static void GetFloati_vEXT(uint pname, uint index, ref float[] parameters)
    {
      glGetFloati_vEXT del = (glGetFloati_vEXT)GetProc<glGetFloati_vEXT>();
      del(pname, index, ref parameters);
    }

    public static void GetFloatIndexedvEXT(uint target, uint index, ref float[] data)
    {
      glGetFloatIndexedvEXT del = (glGetFloatIndexedvEXT)GetProc<glGetFloatIndexedvEXT>();
      del(target, index, ref data);
    }

    public static void GetFogFuncSGIS(ref float[] points)
    {
      glGetFogFuncSGIS del = (glGetFogFuncSGIS)GetProc<glGetFogFuncSGIS>();
      del(ref points);
    }

    public static void GetFragmentLightfvSGIX(uint light, uint pname, ref float[] parameters)
    {
      glGetFragmentLightfvSGIX del = (glGetFragmentLightfvSGIX)GetProc<glGetFragmentLightfvSGIX>();
      del(light, pname, ref parameters);
    }

    public static void GetFragmentLightivSGIX(uint light, uint pname, ref int[] parameters)
    {
      glGetFragmentLightivSGIX del = (glGetFragmentLightivSGIX)GetProc<glGetFragmentLightivSGIX>();
      del(light, pname, ref parameters);
    }

    public static void GetFragmentMaterialfvSGIX(uint face, uint pname, ref float[] parameters)
    {
      glGetFragmentMaterialfvSGIX del = (glGetFragmentMaterialfvSGIX)GetProc<glGetFragmentMaterialfvSGIX>();
      del(face, pname, ref parameters);
    }

    public static void GetFragmentMaterialivSGIX(uint face, uint pname, ref int[] parameters)
    {
      glGetFragmentMaterialivSGIX del = (glGetFragmentMaterialivSGIX)GetProc<glGetFragmentMaterialivSGIX>();
      del(face, pname, ref parameters);
    }

    public static void GetFramebufferAttachmentParameteriv(uint target, uint attachment, uint pname, ref int[] parameters)
    {
      glGetFramebufferAttachmentParameteriv del = (glGetFramebufferAttachmentParameteriv)GetProc<glGetFramebufferAttachmentParameteriv>();
      del(target, attachment, pname, ref parameters);
    }

    public static void GetFramebufferAttachmentParameterivEXT(uint target, uint attachment, uint pname, ref int[] parameters)
    {
      glGetFramebufferAttachmentParameterivEXT del = (glGetFramebufferAttachmentParameterivEXT)GetProc<glGetFramebufferAttachmentParameterivEXT>();
      del(target, attachment, pname, ref parameters);
    }

    public static void GetFramebufferParameteriv(uint target, uint pname, ref int[] parameters)
    {
      glGetFramebufferParameteriv del = (glGetFramebufferParameteriv)GetProc<glGetFramebufferParameteriv>();
      del(target, pname, ref parameters);
    }

    public static void GetFramebufferParameterivEXT(uint framebuffer, uint pname, ref int[] parameters)
    {
      glGetFramebufferParameterivEXT del = (glGetFramebufferParameterivEXT)GetProc<glGetFramebufferParameterivEXT>();
      del(framebuffer, pname, ref parameters);
    }

    public static void GetHistogram(uint target, bool reset, uint format, uint type, IntPtr values)
    {
      glGetHistogram del = (glGetHistogram)GetProc<glGetHistogram>();
      del(target, reset, format, type, values);
    }

    public static void GetHistogramEXT(uint target, bool reset, uint format, uint type, IntPtr values)
    {
      glGetHistogramEXT del = (glGetHistogramEXT)GetProc<glGetHistogramEXT>();
      del(target, reset, format, type, values);
    }

    public static void GetHistogramParameterfv(uint target, uint pname, ref float[] parameters)
    {
      glGetHistogramParameterfv del = (glGetHistogramParameterfv)GetProc<glGetHistogramParameterfv>();
      del(target, pname, ref parameters);
    }

    public static void GetHistogramParameterfvEXT(uint target, uint pname, ref float[] parameters)
    {
      glGetHistogramParameterfvEXT del = (glGetHistogramParameterfvEXT)GetProc<glGetHistogramParameterfvEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetHistogramParameteriv(uint target, uint pname, ref int[] parameters)
    {
      glGetHistogramParameteriv del = (glGetHistogramParameteriv)GetProc<glGetHistogramParameteriv>();
      del(target, pname, ref parameters);
    }

    public static void GetHistogramParameterivEXT(uint target, uint pname, ref int[] parameters)
    {
      glGetHistogramParameterivEXT del = (glGetHistogramParameterivEXT)GetProc<glGetHistogramParameterivEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetHistogramParameterxvOES(uint target, uint pname, ref int[] parameters)
    {
      glGetHistogramParameterxvOES del = (glGetHistogramParameterxvOES)GetProc<glGetHistogramParameterxvOES>();
      del(target, pname, ref parameters);
    }

    public static void GetImageTransformParameterfvHP(uint target, uint pname, ref float[] parameters)
    {
      glGetImageTransformParameterfvHP del = (glGetImageTransformParameterfvHP)GetProc<glGetImageTransformParameterfvHP>();
      del(target, pname, ref parameters);
    }

    public static void GetImageTransformParameterivHP(uint target, uint pname, ref int[] parameters)
    {
      glGetImageTransformParameterivHP del = (glGetImageTransformParameterivHP)GetProc<glGetImageTransformParameterivHP>();
      del(target, pname, ref parameters);
    }

    public static void GetInfoLogARB(uint obj, int maxLength, ref int[] length, ref sbyte[] infoLog)
    {
      glGetInfoLogARB del = (glGetInfoLogARB)GetProc<glGetInfoLogARB>();
      del(obj, maxLength, ref length, ref infoLog);
    }

    public static void GetInteger64i_v(uint target, uint index, ref long[] data)
    {
      glGetInteger64i_v del = (glGetInteger64i_v)GetProc<glGetInteger64i_v>();
      del(target, index, ref data);
    }

    public static void GetInteger64v(uint pname, ref long[] parameters)
    {
      glGetInteger64v del = (glGetInteger64v)GetProc<glGetInteger64v>();
      del(pname, ref parameters);
    }

    public static void GetIntegeri_v(uint target, uint index, ref int[] data)
    {
      glGetIntegeri_v del = (glGetIntegeri_v)GetProc<glGetIntegeri_v>();
      del(target, index, ref data);
    }

    public static void GetIntegerIndexedvEXT(uint target, uint index, ref int[] data)
    {
      glGetIntegerIndexedvEXT del = (glGetIntegerIndexedvEXT)GetProc<glGetIntegerIndexedvEXT>();
      del(target, index, ref data);
    }

    public static void GetIntegerui64i_vNV(uint value, uint index, ref ulong[] result)
    {
      glGetIntegerui64i_vNV del = (glGetIntegerui64i_vNV)GetProc<glGetIntegerui64i_vNV>();
      del(value, index, ref result);
    }

    public static void GetIntegerui64vNV(uint value, ref ulong[] result)
    {
      glGetIntegerui64vNV del = (glGetIntegerui64vNV)GetProc<glGetIntegerui64vNV>();
      del(value, ref result);
    }

    public static void GetInternalformati64v(uint target, uint internalformat, uint pname, int bufSize, ref long[] parameters)
    {
      glGetInternalformati64v del = (glGetInternalformati64v)GetProc<glGetInternalformati64v>();
      del(target, internalformat, pname, bufSize, ref parameters);
    }

    public static void GetInternalformativ(uint target, uint internalformat, uint pname, int bufSize, ref int[] parameters)
    {
      glGetInternalformativ del = (glGetInternalformativ)GetProc<glGetInternalformativ>();
      del(target, internalformat, pname, bufSize, ref parameters);
    }

    public static void GetInvariantBooleanvEXT(uint id, uint value, ref byte[] data)
    {
      glGetInvariantBooleanvEXT del = (glGetInvariantBooleanvEXT)GetProc<glGetInvariantBooleanvEXT>();
      del(id, value, ref data);
    }

    public static void GetInvariantFloatvEXT(uint id, uint value, ref float[] data)
    {
      glGetInvariantFloatvEXT del = (glGetInvariantFloatvEXT)GetProc<glGetInvariantFloatvEXT>();
      del(id, value, ref data);
    }

    public static void GetInvariantIntegervEXT(uint id, uint value, ref int[] data)
    {
      glGetInvariantIntegervEXT del = (glGetInvariantIntegervEXT)GetProc<glGetInvariantIntegervEXT>();
      del(id, value, ref data);
    }

    public static void GetLightxOES(uint light, uint pname, ref int[] parameters)
    {
      glGetLightxOES del = (glGetLightxOES)GetProc<glGetLightxOES>();
      del(light, pname, ref parameters);
    }

    public static void GetListParameterfvSGIX(uint list, uint pname, ref float[] parameters)
    {
      glGetListParameterfvSGIX del = (glGetListParameterfvSGIX)GetProc<glGetListParameterfvSGIX>();
      del(list, pname, ref parameters);
    }

    public static void GetListParameterivSGIX(uint list, uint pname, ref int[] parameters)
    {
      glGetListParameterivSGIX del = (glGetListParameterivSGIX)GetProc<glGetListParameterivSGIX>();
      del(list, pname, ref parameters);
    }

    public static void GetLocalConstantBooleanvEXT(uint id, uint value, ref byte[] data)
    {
      glGetLocalConstantBooleanvEXT del = (glGetLocalConstantBooleanvEXT)GetProc<glGetLocalConstantBooleanvEXT>();
      del(id, value, ref data);
    }

    public static void GetLocalConstantFloatvEXT(uint id, uint value, ref float[] data)
    {
      glGetLocalConstantFloatvEXT del = (glGetLocalConstantFloatvEXT)GetProc<glGetLocalConstantFloatvEXT>();
      del(id, value, ref data);
    }

    public static void GetLocalConstantIntegervEXT(uint id, uint value, ref int[] data)
    {
      glGetLocalConstantIntegervEXT del = (glGetLocalConstantIntegervEXT)GetProc<glGetLocalConstantIntegervEXT>();
      del(id, value, ref data);
    }

    public static void GetMapAttribParameterfvNV(uint target, uint index, uint pname, ref float[] parameters)
    {
      glGetMapAttribParameterfvNV del = (glGetMapAttribParameterfvNV)GetProc<glGetMapAttribParameterfvNV>();
      del(target, index, pname, ref parameters);
    }

    public static void GetMapAttribParameterivNV(uint target, uint index, uint pname, ref int[] parameters)
    {
      glGetMapAttribParameterivNV del = (glGetMapAttribParameterivNV)GetProc<glGetMapAttribParameterivNV>();
      del(target, index, pname, ref parameters);
    }

    public static void GetMapControlPointsNV(uint target, uint index, uint type, int ustride, int vstride, bool packed, IntPtr points)
    {
      glGetMapControlPointsNV del = (glGetMapControlPointsNV)GetProc<glGetMapControlPointsNV>();
      del(target, index, type, ustride, vstride, packed, points);
    }

    public static void GetMapParameterfvNV(uint target, uint pname, ref float[] parameters)
    {
      glGetMapParameterfvNV del = (glGetMapParameterfvNV)GetProc<glGetMapParameterfvNV>();
      del(target, pname, ref parameters);
    }

    public static void GetMapParameterivNV(uint target, uint pname, ref int[] parameters)
    {
      glGetMapParameterivNV del = (glGetMapParameterivNV)GetProc<glGetMapParameterivNV>();
      del(target, pname, ref parameters);
    }

    public static void GetMapxvOES(uint target, uint query, ref int[] v)
    {
      glGetMapxvOES del = (glGetMapxvOES)GetProc<glGetMapxvOES>();
      del(target, query, ref v);
    }

    public static void GetMaterialxOES(uint face, uint pname, int param)
    {
      glGetMaterialxOES del = (glGetMaterialxOES)GetProc<glGetMaterialxOES>();
      del(face, pname, param);
    }

    public static void GetMinmax(uint target, bool reset, uint format, uint type, IntPtr values)
    {
      glGetMinmax del = (glGetMinmax)GetProc<glGetMinmax>();
      del(target, reset, format, type, values);
    }

    public static void GetMinmaxEXT(uint target, bool reset, uint format, uint type, IntPtr values)
    {
      glGetMinmaxEXT del = (glGetMinmaxEXT)GetProc<glGetMinmaxEXT>();
      del(target, reset, format, type, values);
    }

    public static void GetMinmaxParameterfv(uint target, uint pname, ref float[] parameters)
    {
      glGetMinmaxParameterfv del = (glGetMinmaxParameterfv)GetProc<glGetMinmaxParameterfv>();
      del(target, pname, ref parameters);
    }

    public static void GetMinmaxParameterfvEXT(uint target, uint pname, ref float[] parameters)
    {
      glGetMinmaxParameterfvEXT del = (glGetMinmaxParameterfvEXT)GetProc<glGetMinmaxParameterfvEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetMinmaxParameteriv(uint target, uint pname, ref int[] parameters)
    {
      glGetMinmaxParameteriv del = (glGetMinmaxParameteriv)GetProc<glGetMinmaxParameteriv>();
      del(target, pname, ref parameters);
    }

    public static void GetMinmaxParameterivEXT(uint target, uint pname, ref int[] parameters)
    {
      glGetMinmaxParameterivEXT del = (glGetMinmaxParameterivEXT)GetProc<glGetMinmaxParameterivEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetMultisamplefv(uint pname, uint index, ref float[] val)
    {
      glGetMultisamplefv del = (glGetMultisamplefv)GetProc<glGetMultisamplefv>();
      del(pname, index, ref val);
    }

    public static void GetMultisamplefvNV(uint pname, uint index, ref float[] val)
    {
      glGetMultisamplefvNV del = (glGetMultisamplefvNV)GetProc<glGetMultisamplefvNV>();
      del(pname, index, ref val);
    }

    public static void GetMultiTexEnvfvEXT(uint texunit, uint target, uint pname, ref float[] parameters)
    {
      glGetMultiTexEnvfvEXT del = (glGetMultiTexEnvfvEXT)GetProc<glGetMultiTexEnvfvEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void GetMultiTexEnvivEXT(uint texunit, uint target, uint pname, ref int[] parameters)
    {
      glGetMultiTexEnvivEXT del = (glGetMultiTexEnvivEXT)GetProc<glGetMultiTexEnvivEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void GetMultiTexGendvEXT(uint texunit, uint coord, uint pname, ref double[] parameters)
    {
      glGetMultiTexGendvEXT del = (glGetMultiTexGendvEXT)GetProc<glGetMultiTexGendvEXT>();
      del(texunit, coord, pname, ref parameters);
    }

    public static void GetMultiTexGenfvEXT(uint texunit, uint coord, uint pname, ref float[] parameters)
    {
      glGetMultiTexGenfvEXT del = (glGetMultiTexGenfvEXT)GetProc<glGetMultiTexGenfvEXT>();
      del(texunit, coord, pname, ref parameters);
    }

    public static void GetMultiTexGenivEXT(uint texunit, uint coord, uint pname, ref int[] parameters)
    {
      glGetMultiTexGenivEXT del = (glGetMultiTexGenivEXT)GetProc<glGetMultiTexGenivEXT>();
      del(texunit, coord, pname, ref parameters);
    }

    public static void GetMultiTexImageEXT(uint texunit, uint target, int level, uint format, uint type, IntPtr pixels)
    {
      glGetMultiTexImageEXT del = (glGetMultiTexImageEXT)GetProc<glGetMultiTexImageEXT>();
      del(texunit, target, level, format, type, pixels);
    }

    public static void GetMultiTexLevelParameterfvEXT(uint texunit, uint target, int level, uint pname, ref float[] parameters)
    {
      glGetMultiTexLevelParameterfvEXT del = (glGetMultiTexLevelParameterfvEXT)GetProc<glGetMultiTexLevelParameterfvEXT>();
      del(texunit, target, level, pname, ref parameters);
    }

    public static void GetMultiTexLevelParameterivEXT(uint texunit, uint target, int level, uint pname, ref int[] parameters)
    {
      glGetMultiTexLevelParameterivEXT del = (glGetMultiTexLevelParameterivEXT)GetProc<glGetMultiTexLevelParameterivEXT>();
      del(texunit, target, level, pname, ref parameters);
    }

    public static void GetMultiTexParameterfvEXT(uint texunit, uint target, uint pname, ref float[] parameters)
    {
      glGetMultiTexParameterfvEXT del = (glGetMultiTexParameterfvEXT)GetProc<glGetMultiTexParameterfvEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void GetMultiTexParameterIivEXT(uint texunit, uint target, uint pname, ref int[] parameters)
    {
      glGetMultiTexParameterIivEXT del = (glGetMultiTexParameterIivEXT)GetProc<glGetMultiTexParameterIivEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void GetMultiTexParameterIuivEXT(uint texunit, uint target, uint pname, ref uint[] parameters)
    {
      glGetMultiTexParameterIuivEXT del = (glGetMultiTexParameterIuivEXT)GetProc<glGetMultiTexParameterIuivEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void GetMultiTexParameterivEXT(uint texunit, uint target, uint pname, ref int[] parameters)
    {
      glGetMultiTexParameterivEXT del = (glGetMultiTexParameterivEXT)GetProc<glGetMultiTexParameterivEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void GetNamedBufferParameterivEXT(uint buffer, uint pname, ref int[] parameters)
    {
      glGetNamedBufferParameterivEXT del = (glGetNamedBufferParameterivEXT)GetProc<glGetNamedBufferParameterivEXT>();
      del(buffer, pname, ref parameters);
    }

    public static void GetNamedBufferParameterui64vNV(uint buffer, uint pname, ref ulong[] parameters)
    {
      glGetNamedBufferParameterui64vNV del = (glGetNamedBufferParameterui64vNV)GetProc<glGetNamedBufferParameterui64vNV>();
      del(buffer, pname, ref parameters);
    }

    public static void GetNamedBufferPointervEXT(uint buffer, uint pname, IntPtr parameters)
    {
      glGetNamedBufferPointervEXT del = (glGetNamedBufferPointervEXT)GetProc<glGetNamedBufferPointervEXT>();
      del(buffer, pname, parameters);
    }

    public static void GetNamedBufferSubDataEXT(uint buffer, IntPtr offset, IntPtr size, IntPtr data)
    {
      glGetNamedBufferSubDataEXT del = (glGetNamedBufferSubDataEXT)GetProc<glGetNamedBufferSubDataEXT>();
      del(buffer, offset, size, data);
    }

    public static void GetNamedFramebufferAttachmentParameterivEXT(uint framebuffer, uint attachment, uint pname, ref int[] parameters)
    {
      glGetNamedFramebufferAttachmentParameterivEXT del = (glGetNamedFramebufferAttachmentParameterivEXT)GetProc<glGetNamedFramebufferAttachmentParameterivEXT>();
      del(framebuffer, attachment, pname, ref parameters);
    }

    public static void GetNamedFramebufferParameterivEXT(uint framebuffer, uint pname, ref int[] parameters)
    {
      glGetNamedFramebufferParameterivEXT del = (glGetNamedFramebufferParameterivEXT)GetProc<glGetNamedFramebufferParameterivEXT>();
      del(framebuffer, pname, ref parameters);
    }

    public static void GetNamedProgramivEXT(uint program, uint target, uint pname, ref int[] parameters)
    {
      glGetNamedProgramivEXT del = (glGetNamedProgramivEXT)GetProc<glGetNamedProgramivEXT>();
      del(program, target, pname, ref parameters);
    }

    public static void GetNamedProgramLocalParameterdvEXT(uint program, uint target, uint index, ref double[] parameters)
    {
      glGetNamedProgramLocalParameterdvEXT del = (glGetNamedProgramLocalParameterdvEXT)GetProc<glGetNamedProgramLocalParameterdvEXT>();
      del(program, target, index, ref parameters);
    }

    public static void GetNamedProgramLocalParameterfvEXT(uint program, uint target, uint index, ref float[] parameters)
    {
      glGetNamedProgramLocalParameterfvEXT del = (glGetNamedProgramLocalParameterfvEXT)GetProc<glGetNamedProgramLocalParameterfvEXT>();
      del(program, target, index, ref parameters);
    }

    public static void GetNamedProgramLocalParameterIivEXT(uint program, uint target, uint index, ref int[] parameters)
    {
      glGetNamedProgramLocalParameterIivEXT del = (glGetNamedProgramLocalParameterIivEXT)GetProc<glGetNamedProgramLocalParameterIivEXT>();
      del(program, target, index, ref parameters);
    }

    public static void GetNamedProgramLocalParameterIuivEXT(uint program, uint target, uint index, ref uint[] parameters)
    {
      glGetNamedProgramLocalParameterIuivEXT del = (glGetNamedProgramLocalParameterIuivEXT)GetProc<glGetNamedProgramLocalParameterIuivEXT>();
      del(program, target, index, ref parameters);
    }

    public static void GetNamedProgramStringEXT(uint program, uint target, uint pname, IntPtr str)
    {
      glGetNamedProgramStringEXT del = (glGetNamedProgramStringEXT)GetProc<glGetNamedProgramStringEXT>();
      del(program, target, pname, str);
    }

    public static void GetNamedRenderbufferParameterivEXT(uint renderbuffer, uint pname, ref int[] parameters)
    {
      glGetNamedRenderbufferParameterivEXT del = (glGetNamedRenderbufferParameterivEXT)GetProc<glGetNamedRenderbufferParameterivEXT>();
      del(renderbuffer, pname, ref parameters);
    }

    public static void GetNamedStringARB(int namelen, ref sbyte[] name, int bufSize, ref int[] stringlen, ref sbyte[] str)
    {
      glGetNamedStringARB del = (glGetNamedStringARB)GetProc<glGetNamedStringARB>();
      del(namelen, ref name, bufSize, ref stringlen, ref str);
    }

    public static void GetNamedStringivARB(int namelen, ref sbyte[] name, uint pname, ref int[] parameters)
    {
      glGetNamedStringivARB del = (glGetNamedStringivARB)GetProc<glGetNamedStringivARB>();
      del(namelen, ref name, pname, ref parameters);
    }

    public static void GetnColorTableARB(uint target, uint format, uint type, int bufSize, IntPtr table)
    {
      glGetnColorTableARB del = (glGetnColorTableARB)GetProc<glGetnColorTableARB>();
      del(target, format, type, bufSize, table);
    }

    public static void GetnCompressedTexImageARB(uint target, int lod, int bufSize, IntPtr img)
    {
      glGetnCompressedTexImageARB del = (glGetnCompressedTexImageARB)GetProc<glGetnCompressedTexImageARB>();
      del(target, lod, bufSize, img);
    }

    public static void GetnConvolutionFilterARB(uint target, uint format, uint type, int bufSize, IntPtr image)
    {
      glGetnConvolutionFilterARB del = (glGetnConvolutionFilterARB)GetProc<glGetnConvolutionFilterARB>();
      del(target, format, type, bufSize, image);
    }

    public static void GetnHistogramARB(uint target, bool reset, uint format, uint type, int bufSize, IntPtr values)
    {
      glGetnHistogramARB del = (glGetnHistogramARB)GetProc<glGetnHistogramARB>();
      del(target, reset, format, type, bufSize, values);
    }

    public static void GetnMapdvARB(uint target, uint query, int bufSize, ref double[] v)
    {
      glGetnMapdvARB del = (glGetnMapdvARB)GetProc<glGetnMapdvARB>();
      del(target, query, bufSize, ref v);
    }

    public static void GetnMapfvARB(uint target, uint query, int bufSize, ref float[] v)
    {
      glGetnMapfvARB del = (glGetnMapfvARB)GetProc<glGetnMapfvARB>();
      del(target, query, bufSize, ref v);
    }

    public static void GetnMapivARB(uint target, uint query, int bufSize, ref int[] v)
    {
      glGetnMapivARB del = (glGetnMapivARB)GetProc<glGetnMapivARB>();
      del(target, query, bufSize, ref v);
    }

    public static void GetnMinmaxARB(uint target, bool reset, uint format, uint type, int bufSize, IntPtr values)
    {
      glGetnMinmaxARB del = (glGetnMinmaxARB)GetProc<glGetnMinmaxARB>();
      del(target, reset, format, type, bufSize, values);
    }

    public static void GetnPixelMapfvARB(uint map, int bufSize, ref float[] values)
    {
      glGetnPixelMapfvARB del = (glGetnPixelMapfvARB)GetProc<glGetnPixelMapfvARB>();
      del(map, bufSize, ref values);
    }

    public static void GetnPixelMapuivARB(uint map, int bufSize, ref uint[] values)
    {
      glGetnPixelMapuivARB del = (glGetnPixelMapuivARB)GetProc<glGetnPixelMapuivARB>();
      del(map, bufSize, ref values);
    }

    public static void GetnPixelMapusvARB(uint map, int bufSize, ref ushort[] values)
    {
      glGetnPixelMapusvARB del = (glGetnPixelMapusvARB)GetProc<glGetnPixelMapusvARB>();
      del(map, bufSize, ref values);
    }

    public static void GetnPolygonStippleARB(int bufSize, ref byte[] pattern)
    {
      glGetnPolygonStippleARB del = (glGetnPolygonStippleARB)GetProc<glGetnPolygonStippleARB>();
      del(bufSize, ref pattern);
    }

    public static void GetnSeparableFilterARB(uint target, uint format, uint type, int rowBufSize, IntPtr row, int columnBufSize, IntPtr column, IntPtr span)
    {
      glGetnSeparableFilterARB del = (glGetnSeparableFilterARB)GetProc<glGetnSeparableFilterARB>();
      del(target, format, type, rowBufSize, row, columnBufSize, column, span);
    }

    public static void GetnTexImageARB(uint target, int level, uint format, uint type, int bufSize, IntPtr img)
    {
      glGetnTexImageARB del = (glGetnTexImageARB)GetProc<glGetnTexImageARB>();
      del(target, level, format, type, bufSize, img);
    }

    public static void GetnUniformdvARB(uint program, int location, int bufSize, ref double[] parameters)
    {
      glGetnUniformdvARB del = (glGetnUniformdvARB)GetProc<glGetnUniformdvARB>();
      del(program, location, bufSize, ref parameters);
    }

    public static void GetnUniformfvARB(uint program, int location, int bufSize, ref float[] parameters)
    {
      glGetnUniformfvARB del = (glGetnUniformfvARB)GetProc<glGetnUniformfvARB>();
      del(program, location, bufSize, ref parameters);
    }

    public static void GetnUniformivARB(uint program, int location, int bufSize, ref int[] parameters)
    {
      glGetnUniformivARB del = (glGetnUniformivARB)GetProc<glGetnUniformivARB>();
      del(program, location, bufSize, ref parameters);
    }

    public static void GetnUniformuivARB(uint program, int location, int bufSize, ref uint[] parameters)
    {
      glGetnUniformuivARB del = (glGetnUniformuivARB)GetProc<glGetnUniformuivARB>();
      del(program, location, bufSize, ref parameters);
    }

    public static void GetObjectBufferfvATI(uint buffer, uint pname, ref float[] parameters)
    {
      glGetObjectBufferfvATI del = (glGetObjectBufferfvATI)GetProc<glGetObjectBufferfvATI>();
      del(buffer, pname, ref parameters);
    }

    public static void GetObjectBufferivATI(uint buffer, uint pname, ref int[] parameters)
    {
      glGetObjectBufferivATI del = (glGetObjectBufferivATI)GetProc<glGetObjectBufferivATI>();
      del(buffer, pname, ref parameters);
    }

    public static void GetObjectLabel(uint identifier, uint name, int bufSize, ref int[] length, ref sbyte[] label)
    {
      glGetObjectLabel del = (glGetObjectLabel)GetProc<glGetObjectLabel>();
      del(identifier, name, bufSize, ref length, ref label);
    }

    public static void GetObjectParameterfvARB(uint obj, uint pname, ref float[] parameters)
    {
      glGetObjectParameterfvARB del = (glGetObjectParameterfvARB)GetProc<glGetObjectParameterfvARB>();
      del(obj, pname, ref parameters);
    }

    public static void GetObjectParameterivAPPLE(uint objectType, uint name, uint pname, ref int[] parameters)
    {
      glGetObjectParameterivAPPLE del = (glGetObjectParameterivAPPLE)GetProc<glGetObjectParameterivAPPLE>();
      del(objectType, name, pname, ref parameters);
    }

    public static void GetObjectParameterivARB(uint obj, uint pname, ref int[] parameters)
    {
      glGetObjectParameterivARB del = (glGetObjectParameterivARB)GetProc<glGetObjectParameterivARB>();
      del(obj, pname, ref parameters);
    }

    public static void GetObjectPtrLabel(IntPtr ptr, int bufSize, ref int[] length, ref sbyte[] label)
    {
      glGetObjectPtrLabel del = (glGetObjectPtrLabel)GetProc<glGetObjectPtrLabel>();
      del(ptr, bufSize, ref length, ref label);
    }

    public static void GetOcclusionQueryivNV(uint id, uint pname, ref int[] parameters)
    {
      glGetOcclusionQueryivNV del = (glGetOcclusionQueryivNV)GetProc<glGetOcclusionQueryivNV>();
      del(id, pname, ref parameters);
    }

    public static void GetOcclusionQueryuivNV(uint id, uint pname, ref uint[] parameters)
    {
      glGetOcclusionQueryuivNV del = (glGetOcclusionQueryuivNV)GetProc<glGetOcclusionQueryuivNV>();
      del(id, pname, ref parameters);
    }

    public static void GetPathColorGenfvNV(uint color, uint pname, ref float[] value)
    {
      glGetPathColorGenfvNV del = (glGetPathColorGenfvNV)GetProc<glGetPathColorGenfvNV>();
      del(color, pname, ref value);
    }

    public static void GetPathColorGenivNV(uint color, uint pname, ref int[] value)
    {
      glGetPathColorGenivNV del = (glGetPathColorGenivNV)GetProc<glGetPathColorGenivNV>();
      del(color, pname, ref value);
    }

    public static void GetPathCommandsNV(uint path, ref byte[] commands)
    {
      glGetPathCommandsNV del = (glGetPathCommandsNV)GetProc<glGetPathCommandsNV>();
      del(path, ref commands);
    }

    public static void GetPathCoordsNV(uint path, ref float[] coords)
    {
      glGetPathCoordsNV del = (glGetPathCoordsNV)GetProc<glGetPathCoordsNV>();
      del(path, ref coords);
    }

    public static void GetPathDashArrayNV(uint path, ref float[] dashArray)
    {
      glGetPathDashArrayNV del = (glGetPathDashArrayNV)GetProc<glGetPathDashArrayNV>();
      del(path, ref dashArray);
    }

    public static void GetPathMetricRangeNV(uint metricQueryMask, uint firstPathName, int numPaths, int stride, ref float[] metrics)
    {
      glGetPathMetricRangeNV del = (glGetPathMetricRangeNV)GetProc<glGetPathMetricRangeNV>();
      del(metricQueryMask, firstPathName, numPaths, stride, ref metrics);
    }

    public static void GetPathMetricsNV(uint metricQueryMask, int numPaths, uint pathNameType, IntPtr paths, uint pathBase, int stride, ref float[] metrics)
    {
      glGetPathMetricsNV del = (glGetPathMetricsNV)GetProc<glGetPathMetricsNV>();
      del(metricQueryMask, numPaths, pathNameType, paths, pathBase, stride, ref metrics);
    }

    public static void GetPathParameterfvNV(uint path, uint pname, ref float[] value)
    {
      glGetPathParameterfvNV del = (glGetPathParameterfvNV)GetProc<glGetPathParameterfvNV>();
      del(path, pname, ref value);
    }

    public static void GetPathParameterivNV(uint path, uint pname, ref int[] value)
    {
      glGetPathParameterivNV del = (glGetPathParameterivNV)GetProc<glGetPathParameterivNV>();
      del(path, pname, ref value);
    }

    public static void GetPathSpacingNV(uint pathListMode, int numPaths, uint pathNameType, IntPtr paths, uint pathBase, float advanceScale, float kerningScale, uint transformType, ref float[] returnedSpacing)
    {
      glGetPathSpacingNV del = (glGetPathSpacingNV)GetProc<glGetPathSpacingNV>();
      del(pathListMode, numPaths, pathNameType, paths, pathBase, advanceScale, kerningScale, transformType, ref returnedSpacing);
    }

    public static void GetPathTexGenfvNV(uint texCoordSet, uint pname, ref float[] value)
    {
      glGetPathTexGenfvNV del = (glGetPathTexGenfvNV)GetProc<glGetPathTexGenfvNV>();
      del(texCoordSet, pname, ref value);
    }

    public static void GetPathTexGenivNV(uint texCoordSet, uint pname, ref int[] value)
    {
      glGetPathTexGenivNV del = (glGetPathTexGenivNV)GetProc<glGetPathTexGenivNV>();
      del(texCoordSet, pname, ref value);
    }

    public static void GetPerfMonitorCounterDataAMD(uint monitor, uint pname, int dataSize, ref uint[] data, ref int[] bytesWritten)
    {
      glGetPerfMonitorCounterDataAMD del = (glGetPerfMonitorCounterDataAMD)GetProc<glGetPerfMonitorCounterDataAMD>();
      del(monitor, pname, dataSize, ref data, ref bytesWritten);
    }

    public static void GetPerfMonitorCounterInfoAMD(uint group, uint counter, uint pname, IntPtr data)
    {
      glGetPerfMonitorCounterInfoAMD del = (glGetPerfMonitorCounterInfoAMD)GetProc<glGetPerfMonitorCounterInfoAMD>();
      del(group, counter, pname, data);
    }

    public static void GetPerfMonitorCountersAMD(uint group, ref int[] numCounters, ref int[] maxActiveCounters, int counterSize, ref uint[] counters)
    {
      glGetPerfMonitorCountersAMD del = (glGetPerfMonitorCountersAMD)GetProc<glGetPerfMonitorCountersAMD>();
      del(group, ref numCounters, ref maxActiveCounters, counterSize, ref counters);
    }

    public static void GetPerfMonitorCounterStringAMD(uint group, uint counter, int bufSize, ref int[] length, ref sbyte[] counterString)
    {
      glGetPerfMonitorCounterStringAMD del = (glGetPerfMonitorCounterStringAMD)GetProc<glGetPerfMonitorCounterStringAMD>();
      del(group, counter, bufSize, ref length, ref counterString);
    }

    public static void GetPerfMonitorGroupsAMD(ref int[] numGroups, int groupsSize, ref uint[] groups)
    {
      glGetPerfMonitorGroupsAMD del = (glGetPerfMonitorGroupsAMD)GetProc<glGetPerfMonitorGroupsAMD>();
      del(ref numGroups, groupsSize, ref groups);
    }

    public static void GetPerfMonitorGroupStringAMD(uint group, int bufSize, ref int[] length, ref sbyte[] groupString)
    {
      glGetPerfMonitorGroupStringAMD del = (glGetPerfMonitorGroupStringAMD)GetProc<glGetPerfMonitorGroupStringAMD>();
      del(group, bufSize, ref length, ref groupString);
    }

    public static void GetPixelMapxv(uint map, int size, ref int[] values)
    {
      glGetPixelMapxv del = (glGetPixelMapxv)GetProc<glGetPixelMapxv>();
      del(map, size, ref values);
    }

    public static void GetPixelTexGenParameterfvSGIS(uint pname, ref float[] parameters)
    {
      glGetPixelTexGenParameterfvSGIS del = (glGetPixelTexGenParameterfvSGIS)GetProc<glGetPixelTexGenParameterfvSGIS>();
      del(pname, ref parameters);
    }

    public static void GetPixelTexGenParameterivSGIS(uint pname, ref int[] parameters)
    {
      glGetPixelTexGenParameterivSGIS del = (glGetPixelTexGenParameterivSGIS)GetProc<glGetPixelTexGenParameterivSGIS>();
      del(pname, ref parameters);
    }

    public static void GetPixelTransformParameterfvEXT(uint target, uint pname, ref float[] parameters)
    {
      glGetPixelTransformParameterfvEXT del = (glGetPixelTransformParameterfvEXT)GetProc<glGetPixelTransformParameterfvEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetPixelTransformParameterivEXT(uint target, uint pname, ref int[] parameters)
    {
      glGetPixelTransformParameterivEXT del = (glGetPixelTransformParameterivEXT)GetProc<glGetPixelTransformParameterivEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetPointeri_vEXT(uint pname, uint index, IntPtr parameters)
    {
      glGetPointeri_vEXT del = (glGetPointeri_vEXT)GetProc<glGetPointeri_vEXT>();
      del(pname, index, parameters);
    }

    public static void GetPointerIndexedvEXT(uint target, uint index, IntPtr data)
    {
      glGetPointerIndexedvEXT del = (glGetPointerIndexedvEXT)GetProc<glGetPointerIndexedvEXT>();
      del(target, index, data);
    }

    public static void GetPointervEXT(uint pname, IntPtr parameters)
    {
      glGetPointervEXT del = (glGetPointervEXT)GetProc<glGetPointervEXT>();
      del(pname, parameters);
    }

    public static void GetProgramBinary(uint program, int bufSize, ref int[] length, ref uint[] binaryFormat, IntPtr binary)
    {
      glGetProgramBinary del = (glGetProgramBinary)GetProc<glGetProgramBinary>();
      del(program, bufSize, ref length, ref binaryFormat, binary);
    }

    public static void GetProgramEnvParameterdvARB(uint target, uint index, ref double[] parameters)
    {
      glGetProgramEnvParameterdvARB del = (glGetProgramEnvParameterdvARB)GetProc<glGetProgramEnvParameterdvARB>();
      del(target, index, ref parameters);
    }

    public static void GetProgramEnvParameterfvARB(uint target, uint index, ref float[] parameters)
    {
      glGetProgramEnvParameterfvARB del = (glGetProgramEnvParameterfvARB)GetProc<glGetProgramEnvParameterfvARB>();
      del(target, index, ref parameters);
    }

    public static void GetProgramEnvParameterIivNV(uint target, uint index, ref int[] parameters)
    {
      glGetProgramEnvParameterIivNV del = (glGetProgramEnvParameterIivNV)GetProc<glGetProgramEnvParameterIivNV>();
      del(target, index, ref parameters);
    }

    public static void GetProgramEnvParameterIuivNV(uint target, uint index, ref uint[] parameters)
    {
      glGetProgramEnvParameterIuivNV del = (glGetProgramEnvParameterIuivNV)GetProc<glGetProgramEnvParameterIuivNV>();
      del(target, index, ref parameters);
    }

    public static void GetProgramInfoLog(uint program, int bufSize, ref int[] length, ref sbyte[] infoLog)
    {
      glGetProgramInfoLog del = (glGetProgramInfoLog)GetProc<glGetProgramInfoLog>();
      del(program, bufSize, ref length, ref infoLog);
    }

    public static void GetProgramInterfaceiv(uint program, uint programInterface, uint pname, ref int[] parameters)
    {
      glGetProgramInterfaceiv del = (glGetProgramInterfaceiv)GetProc<glGetProgramInterfaceiv>();
      del(program, programInterface, pname, ref parameters);
    }

    public static void GetProgramiv(uint program, uint pname, ref int[] parameters)
    {
      glGetProgramiv del = (glGetProgramiv)GetProc<glGetProgramiv>();
      del(program, pname, ref parameters);
    }

    public static void GetProgramivARB(uint target, uint pname, ref int[] parameters)
    {
      glGetProgramivARB del = (glGetProgramivARB)GetProc<glGetProgramivARB>();
      del(target, pname, ref parameters);
    }

    public static void GetProgramivNV(uint id, uint pname, ref int[] parameters)
    {
      glGetProgramivNV del = (glGetProgramivNV)GetProc<glGetProgramivNV>();
      del(id, pname, ref parameters);
    }

    public static void GetProgramLocalParameterdvARB(uint target, uint index, ref double[] parameters)
    {
      glGetProgramLocalParameterdvARB del = (glGetProgramLocalParameterdvARB)GetProc<glGetProgramLocalParameterdvARB>();
      del(target, index, ref parameters);
    }

    public static void GetProgramLocalParameterfvARB(uint target, uint index, ref float[] parameters)
    {
      glGetProgramLocalParameterfvARB del = (glGetProgramLocalParameterfvARB)GetProc<glGetProgramLocalParameterfvARB>();
      del(target, index, ref parameters);
    }

    public static void GetProgramLocalParameterIivNV(uint target, uint index, ref int[] parameters)
    {
      glGetProgramLocalParameterIivNV del = (glGetProgramLocalParameterIivNV)GetProc<glGetProgramLocalParameterIivNV>();
      del(target, index, ref parameters);
    }

    public static void GetProgramLocalParameterIuivNV(uint target, uint index, ref uint[] parameters)
    {
      glGetProgramLocalParameterIuivNV del = (glGetProgramLocalParameterIuivNV)GetProc<glGetProgramLocalParameterIuivNV>();
      del(target, index, ref parameters);
    }

    public static void GetProgramNamedParameterdvNV(uint id, int len, ref byte[] name, ref double[] parameters)
    {
      glGetProgramNamedParameterdvNV del = (glGetProgramNamedParameterdvNV)GetProc<glGetProgramNamedParameterdvNV>();
      del(id, len, ref name, ref parameters);
    }

    public static void GetProgramNamedParameterfvNV(uint id, int len, ref byte[] name, ref float[] parameters)
    {
      glGetProgramNamedParameterfvNV del = (glGetProgramNamedParameterfvNV)GetProc<glGetProgramNamedParameterfvNV>();
      del(id, len, ref name, ref parameters);
    }

    public static void GetProgramParameterdvNV(uint target, uint index, uint pname, ref double[] parameters)
    {
      glGetProgramParameterdvNV del = (glGetProgramParameterdvNV)GetProc<glGetProgramParameterdvNV>();
      del(target, index, pname, ref parameters);
    }

    public static void GetProgramParameterfvNV(uint target, uint index, uint pname, ref float[] parameters)
    {
      glGetProgramParameterfvNV del = (glGetProgramParameterfvNV)GetProc<glGetProgramParameterfvNV>();
      del(target, index, pname, ref parameters);
    }

    public static void GetProgramPipelineInfoLog(uint pipeline, int bufSize, ref int[] length, ref sbyte[] infoLog)
    {
      glGetProgramPipelineInfoLog del = (glGetProgramPipelineInfoLog)GetProc<glGetProgramPipelineInfoLog>();
      del(pipeline, bufSize, ref length, ref infoLog);
    }

    public static void GetProgramPipelineiv(uint pipeline, uint pname, ref int[] parameters)
    {
      glGetProgramPipelineiv del = (glGetProgramPipelineiv)GetProc<glGetProgramPipelineiv>();
      del(pipeline, pname, ref parameters);
    }

    public static void GetProgramResourceiv(uint program, uint programInterface, uint index, int propCount, ref uint[] props, int bufSize, ref int[] length, ref int[] parameters)
    {
      glGetProgramResourceiv del = (glGetProgramResourceiv)GetProc<glGetProgramResourceiv>();
      del(program, programInterface, index, propCount, ref props, bufSize, ref length, ref parameters);
    }

    public static void GetProgramResourceName(uint program, uint programInterface, uint index, int bufSize, ref int[] length, ref sbyte[] name)
    {
      glGetProgramResourceName del = (glGetProgramResourceName)GetProc<glGetProgramResourceName>();
      del(program, programInterface, index, bufSize, ref length, ref name);
    }

    public static void GetProgramStageiv(uint program, uint shadertype, uint pname, ref int[] values)
    {
      glGetProgramStageiv del = (glGetProgramStageiv)GetProc<glGetProgramStageiv>();
      del(program, shadertype, pname, ref values);
    }

    public static void GetProgramStringARB(uint target, uint pname, IntPtr str)
    {
      glGetProgramStringARB del = (glGetProgramStringARB)GetProc<glGetProgramStringARB>();
      del(target, pname, str);
    }

    public static void GetProgramStringNV(uint id, uint pname, ref byte[] program)
    {
      glGetProgramStringNV del = (glGetProgramStringNV)GetProc<glGetProgramStringNV>();
      del(id, pname, ref program);
    }

    public static void GetProgramSubroutineParameteruivNV(uint target, uint index, ref uint[] param)
    {
      glGetProgramSubroutineParameteruivNV del = (glGetProgramSubroutineParameteruivNV)GetProc<glGetProgramSubroutineParameteruivNV>();
      del(target, index, ref param);
    }

    public static void GetQueryIndexediv(uint target, uint index, uint pname, ref int[] parameters)
    {
      glGetQueryIndexediv del = (glGetQueryIndexediv)GetProc<glGetQueryIndexediv>();
      del(target, index, pname, ref parameters);
    }

    public static void GetQueryiv(uint target, uint pname, ref int[] parameters)
    {
      glGetQueryiv del = (glGetQueryiv)GetProc<glGetQueryiv>();
      del(target, pname, ref parameters);
    }

    public static void GetQueryivARB(uint target, uint pname, ref int[] parameters)
    {
      glGetQueryivARB del = (glGetQueryivARB)GetProc<glGetQueryivARB>();
      del(target, pname, ref parameters);
    }

    public static void GetQueryObjecti64v(uint id, uint pname, ref long[] parameters)
    {
      glGetQueryObjecti64v del = (glGetQueryObjecti64v)GetProc<glGetQueryObjecti64v>();
      del(id, pname, ref parameters);
    }

    public static void GetQueryObjecti64vEXT(uint id, uint pname, ref long[] parameters)
    {
      glGetQueryObjecti64vEXT del = (glGetQueryObjecti64vEXT)GetProc<glGetQueryObjecti64vEXT>();
      del(id, pname, ref parameters);
    }

    public static void GetQueryObjectiv(uint id, uint pname, ref int[] parameters)
    {
      glGetQueryObjectiv del = (glGetQueryObjectiv)GetProc<glGetQueryObjectiv>();
      del(id, pname, ref parameters);
    }

    public static void GetQueryObjectivARB(uint id, uint pname, ref int[] parameters)
    {
      glGetQueryObjectivARB del = (glGetQueryObjectivARB)GetProc<glGetQueryObjectivARB>();
      del(id, pname, ref parameters);
    }

    public static void GetQueryObjectui64v(uint id, uint pname, ref ulong[] parameters)
    {
      glGetQueryObjectui64v del = (glGetQueryObjectui64v)GetProc<glGetQueryObjectui64v>();
      del(id, pname, ref parameters);
    }

    public static void GetQueryObjectui64vEXT(uint id, uint pname, ref ulong[] parameters)
    {
      glGetQueryObjectui64vEXT del = (glGetQueryObjectui64vEXT)GetProc<glGetQueryObjectui64vEXT>();
      del(id, pname, ref parameters);
    }

    public static void GetQueryObjectuiv(uint id, uint pname, ref uint[] parameters)
    {
      glGetQueryObjectuiv del = (glGetQueryObjectuiv)GetProc<glGetQueryObjectuiv>();
      del(id, pname, ref parameters);
    }

    public static void GetQueryObjectuivARB(uint id, uint pname, ref uint[] parameters)
    {
      glGetQueryObjectuivARB del = (glGetQueryObjectuivARB)GetProc<glGetQueryObjectuivARB>();
      del(id, pname, ref parameters);
    }

    public static void GetRenderbufferParameteriv(uint target, uint pname, ref int[] parameters)
    {
      glGetRenderbufferParameteriv del = (glGetRenderbufferParameteriv)GetProc<glGetRenderbufferParameteriv>();
      del(target, pname, ref parameters);
    }

    public static void GetRenderbufferParameterivEXT(uint target, uint pname, ref int[] parameters)
    {
      glGetRenderbufferParameterivEXT del = (glGetRenderbufferParameterivEXT)GetProc<glGetRenderbufferParameterivEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetSamplerParameterfv(uint sampler, uint pname, ref float[] parameters)
    {
      glGetSamplerParameterfv del = (glGetSamplerParameterfv)GetProc<glGetSamplerParameterfv>();
      del(sampler, pname, ref parameters);
    }

    public static void GetSamplerParameterIiv(uint sampler, uint pname, ref int[] parameters)
    {
      glGetSamplerParameterIiv del = (glGetSamplerParameterIiv)GetProc<glGetSamplerParameterIiv>();
      del(sampler, pname, ref parameters);
    }

    public static void GetSamplerParameterIuiv(uint sampler, uint pname, ref uint[] parameters)
    {
      glGetSamplerParameterIuiv del = (glGetSamplerParameterIuiv)GetProc<glGetSamplerParameterIuiv>();
      del(sampler, pname, ref parameters);
    }

    public static void GetSamplerParameteriv(uint sampler, uint pname, ref int[] parameters)
    {
      glGetSamplerParameteriv del = (glGetSamplerParameteriv)GetProc<glGetSamplerParameteriv>();
      del(sampler, pname, ref parameters);
    }

    public static void GetSeparableFilter(uint target, uint format, uint type, IntPtr row, IntPtr column, IntPtr span)
    {
      glGetSeparableFilter del = (glGetSeparableFilter)GetProc<glGetSeparableFilter>();
      del(target, format, type, row, column, span);
    }

    public static void GetSeparableFilterEXT(uint target, uint format, uint type, IntPtr row, IntPtr column, IntPtr span)
    {
      glGetSeparableFilterEXT del = (glGetSeparableFilterEXT)GetProc<glGetSeparableFilterEXT>();
      del(target, format, type, row, column, span);
    }

    public static void GetShaderInfoLog(uint shader, int bufSize, ref int[] length, ref sbyte[] infoLog)
    {
      glGetShaderInfoLog del = (glGetShaderInfoLog)GetProc<glGetShaderInfoLog>();
      del(shader, bufSize, ref length, ref infoLog);
    }

    public static void GetShaderiv(uint shader, uint pname, ref int[] parameters)
    {
      glGetShaderiv del = (glGetShaderiv)GetProc<glGetShaderiv>();
      del(shader, pname, ref parameters);
    }

    public static void GetShaderPrecisionFormat(uint shadertype, uint precisiontype, ref int[] range, ref int[] precision)
    {
      glGetShaderPrecisionFormat del = (glGetShaderPrecisionFormat)GetProc<glGetShaderPrecisionFormat>();
      del(shadertype, precisiontype, ref range, ref precision);
    }

    public static void GetShaderSource(uint shader, int bufSize, ref int[] length, ref sbyte[] source)
    {
      glGetShaderSource del = (glGetShaderSource)GetProc<glGetShaderSource>();
      del(shader, bufSize, ref length, ref source);
    }

    public static void GetShaderSourceARB(uint obj, int maxLength, ref int[] length, ref sbyte[] source)
    {
      glGetShaderSourceARB del = (glGetShaderSourceARB)GetProc<glGetShaderSourceARB>();
      del(obj, maxLength, ref length, ref source);
    }

    public static void GetSharpenTexFuncSGIS(uint target, ref float[] points)
    {
      glGetSharpenTexFuncSGIS del = (glGetSharpenTexFuncSGIS)GetProc<glGetSharpenTexFuncSGIS>();
      del(target, ref points);
    }

    public static void GetSynciv(GLsync sync, uint pname, int bufSize, ref int[] length, ref int[] values)
    {
      glGetSynciv del = (glGetSynciv)GetProc<glGetSynciv>();
      del(sync, pname, bufSize, ref length, ref values);
    }

    public static void GetTexBumpParameterfvATI(uint pname, ref float[] param)
    {
      glGetTexBumpParameterfvATI del = (glGetTexBumpParameterfvATI)GetProc<glGetTexBumpParameterfvATI>();
      del(pname, ref param);
    }

    public static void GetTexBumpParameterivATI(uint pname, ref int[] param)
    {
      glGetTexBumpParameterivATI del = (glGetTexBumpParameterivATI)GetProc<glGetTexBumpParameterivATI>();
      del(pname, ref param);
    }

    public static void GetTexEnvxvOES(uint target, uint pname, ref int[] parameters)
    {
      glGetTexEnvxvOES del = (glGetTexEnvxvOES)GetProc<glGetTexEnvxvOES>();
      del(target, pname, ref parameters);
    }

    public static void GetTexFilterFuncSGIS(uint target, uint filter, ref float[] weights)
    {
      glGetTexFilterFuncSGIS del = (glGetTexFilterFuncSGIS)GetProc<glGetTexFilterFuncSGIS>();
      del(target, filter, ref weights);
    }

    public static void GetTexGenxvOES(uint coord, uint pname, ref int[] parameters)
    {
      glGetTexGenxvOES del = (glGetTexGenxvOES)GetProc<glGetTexGenxvOES>();
      del(coord, pname, ref parameters);
    }

    public static void GetTexLevelParameterxvOES(uint target, int level, uint pname, ref int[] parameters)
    {
      glGetTexLevelParameterxvOES del = (glGetTexLevelParameterxvOES)GetProc<glGetTexLevelParameterxvOES>();
      del(target, level, pname, ref parameters);
    }

    public static void GetTexParameterIiv(uint target, uint pname, ref int[] parameters)
    {
      glGetTexParameterIiv del = (glGetTexParameterIiv)GetProc<glGetTexParameterIiv>();
      del(target, pname, ref parameters);
    }

    public static void GetTexParameterIivEXT(uint target, uint pname, ref int[] parameters)
    {
      glGetTexParameterIivEXT del = (glGetTexParameterIivEXT)GetProc<glGetTexParameterIivEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetTexParameterIuiv(uint target, uint pname, ref uint[] parameters)
    {
      glGetTexParameterIuiv del = (glGetTexParameterIuiv)GetProc<glGetTexParameterIuiv>();
      del(target, pname, ref parameters);
    }

    public static void GetTexParameterIuivEXT(uint target, uint pname, ref uint[] parameters)
    {
      glGetTexParameterIuivEXT del = (glGetTexParameterIuivEXT)GetProc<glGetTexParameterIuivEXT>();
      del(target, pname, ref parameters);
    }

    public static void GetTexParameterPointervAPPLE(uint target, uint pname, IntPtr parameters)
    {
      glGetTexParameterPointervAPPLE del = (glGetTexParameterPointervAPPLE)GetProc<glGetTexParameterPointervAPPLE>();
      del(target, pname, parameters);
    }

    public static void GetTexParameterxvOES(uint target, uint pname, ref int[] parameters)
    {
      glGetTexParameterxvOES del = (glGetTexParameterxvOES)GetProc<glGetTexParameterxvOES>();
      del(target, pname, ref parameters);
    }

    public static void GetTextureImageEXT(uint texture, uint target, int level, uint format, uint type, IntPtr pixels)
    {
      glGetTextureImageEXT del = (glGetTextureImageEXT)GetProc<glGetTextureImageEXT>();
      del(texture, target, level, format, type, pixels);
    }

    public static void GetTextureLevelParameterfvEXT(uint texture, uint target, int level, uint pname, ref float[] parameters)
    {
      glGetTextureLevelParameterfvEXT del = (glGetTextureLevelParameterfvEXT)GetProc<glGetTextureLevelParameterfvEXT>();
      del(texture, target, level, pname, ref parameters);
    }

    public static void GetTextureLevelParameterivEXT(uint texture, uint target, int level, uint pname, ref int[] parameters)
    {
      glGetTextureLevelParameterivEXT del = (glGetTextureLevelParameterivEXT)GetProc<glGetTextureLevelParameterivEXT>();
      del(texture, target, level, pname, ref parameters);
    }

    public static void GetTextureParameterfvEXT(uint texture, uint target, uint pname, ref float[] parameters)
    {
      glGetTextureParameterfvEXT del = (glGetTextureParameterfvEXT)GetProc<glGetTextureParameterfvEXT>();
      del(texture, target, pname, ref parameters);
    }

    public static void GetTextureParameterIivEXT(uint texture, uint target, uint pname, ref int[] parameters)
    {
      glGetTextureParameterIivEXT del = (glGetTextureParameterIivEXT)GetProc<glGetTextureParameterIivEXT>();
      del(texture, target, pname, ref parameters);
    }

    public static void GetTextureParameterIuivEXT(uint texture, uint target, uint pname, ref uint[] parameters)
    {
      glGetTextureParameterIuivEXT del = (glGetTextureParameterIuivEXT)GetProc<glGetTextureParameterIuivEXT>();
      del(texture, target, pname, ref parameters);
    }

    public static void GetTextureParameterivEXT(uint texture, uint target, uint pname, ref int[] parameters)
    {
      glGetTextureParameterivEXT del = (glGetTextureParameterivEXT)GetProc<glGetTextureParameterivEXT>();
      del(texture, target, pname, ref parameters);
    }

    public static void GetTrackMatrixivNV(uint target, uint address, uint pname, ref int[] parameters)
    {
      glGetTrackMatrixivNV del = (glGetTrackMatrixivNV)GetProc<glGetTrackMatrixivNV>();
      del(target, address, pname, ref parameters);
    }

    public static void GetTransformFeedbackVarying(uint program, uint index, int bufSize, ref int[] length, ref int[] size, ref uint[] type, ref sbyte[] name)
    {
      glGetTransformFeedbackVarying del = (glGetTransformFeedbackVarying)GetProc<glGetTransformFeedbackVarying>();
      del(program, index, bufSize, ref length, ref size, ref type, ref name);
    }

    public static void GetTransformFeedbackVaryingEXT(uint program, uint index, int bufSize, ref int[] length, ref int[] size, ref uint[] type, ref sbyte[] name)
    {
      glGetTransformFeedbackVaryingEXT del = (glGetTransformFeedbackVaryingEXT)GetProc<glGetTransformFeedbackVaryingEXT>();
      del(program, index, bufSize, ref length, ref size, ref type, ref name);
    }

    public static void GetTransformFeedbackVaryingNV(uint program, uint index, ref int[] location)
    {
      glGetTransformFeedbackVaryingNV del = (glGetTransformFeedbackVaryingNV)GetProc<glGetTransformFeedbackVaryingNV>();
      del(program, index, ref location);
    }

    public static void GetUniformdv(uint program, int location, ref double[] parameters)
    {
      glGetUniformdv del = (glGetUniformdv)GetProc<glGetUniformdv>();
      del(program, location, ref parameters);
    }

    public static void GetUniformfv(uint program, int location, ref float[] parameters)
    {
      glGetUniformfv del = (glGetUniformfv)GetProc<glGetUniformfv>();
      del(program, location, ref parameters);
    }

    public static void GetUniformfvARB(uint programObj, int location, ref float[] parameters)
    {
      glGetUniformfvARB del = (glGetUniformfvARB)GetProc<glGetUniformfvARB>();
      del(programObj, location, ref parameters);
    }

    public static void GetUniformi64vNV(uint program, int location, ref long[] parameters)
    {
      glGetUniformi64vNV del = (glGetUniformi64vNV)GetProc<glGetUniformi64vNV>();
      del(program, location, ref parameters);
    }

    public static void GetUniformIndices(uint program, int uniformCount, ref sbyte[] uniformNames, ref uint[] uniformIndices)
    {
      glGetUniformIndices del = (glGetUniformIndices)GetProc<glGetUniformIndices>();
      del(program, uniformCount, ref uniformNames, ref uniformIndices);
    }

    public static void GetUniformiv(uint program, int location, ref int[] parameters)
    {
      glGetUniformiv del = (glGetUniformiv)GetProc<glGetUniformiv>();
      del(program, location, ref parameters);
    }

    public static void GetUniformivARB(uint programObj, int location, ref int[] parameters)
    {
      glGetUniformivARB del = (glGetUniformivARB)GetProc<glGetUniformivARB>();
      del(programObj, location, ref parameters);
    }

    public static void GetUniformSubroutineuiv(uint shadertype, int location, ref uint[] parameters)
    {
      glGetUniformSubroutineuiv del = (glGetUniformSubroutineuiv)GetProc<glGetUniformSubroutineuiv>();
      del(shadertype, location, ref parameters);
    }

    public static void GetUniformui64vNV(uint program, int location, ref ulong[] parameters)
    {
      glGetUniformui64vNV del = (glGetUniformui64vNV)GetProc<glGetUniformui64vNV>();
      del(program, location, ref parameters);
    }

    public static void GetUniformuiv(uint program, int location, ref uint[] parameters)
    {
      glGetUniformuiv del = (glGetUniformuiv)GetProc<glGetUniformuiv>();
      del(program, location, ref parameters);
    }

    public static void GetUniformuivEXT(uint program, int location, ref uint[] parameters)
    {
      glGetUniformuivEXT del = (glGetUniformuivEXT)GetProc<glGetUniformuivEXT>();
      del(program, location, ref parameters);
    }

    public static void GetVariantArrayObjectfvATI(uint id, uint pname, ref float[] parameters)
    {
      glGetVariantArrayObjectfvATI del = (glGetVariantArrayObjectfvATI)GetProc<glGetVariantArrayObjectfvATI>();
      del(id, pname, ref parameters);
    }

    public static void GetVariantArrayObjectivATI(uint id, uint pname, ref int[] parameters)
    {
      glGetVariantArrayObjectivATI del = (glGetVariantArrayObjectivATI)GetProc<glGetVariantArrayObjectivATI>();
      del(id, pname, ref parameters);
    }

    public static void GetVariantBooleanvEXT(uint id, uint value, ref byte[] data)
    {
      glGetVariantBooleanvEXT del = (glGetVariantBooleanvEXT)GetProc<glGetVariantBooleanvEXT>();
      del(id, value, ref data);
    }

    public static void GetVariantFloatvEXT(uint id, uint value, ref float[] data)
    {
      glGetVariantFloatvEXT del = (glGetVariantFloatvEXT)GetProc<glGetVariantFloatvEXT>();
      del(id, value, ref data);
    }

    public static void GetVariantIntegervEXT(uint id, uint value, ref int[] data)
    {
      glGetVariantIntegervEXT del = (glGetVariantIntegervEXT)GetProc<glGetVariantIntegervEXT>();
      del(id, value, ref data);
    }

    public static void GetVariantPointervEXT(uint id, uint value, IntPtr data)
    {
      glGetVariantPointervEXT del = (glGetVariantPointervEXT)GetProc<glGetVariantPointervEXT>();
      del(id, value, data);
    }

    public static void GetVertexArrayIntegeri_vEXT(uint vaobj, uint index, uint pname, ref int[] param)
    {
      glGetVertexArrayIntegeri_vEXT del = (glGetVertexArrayIntegeri_vEXT)GetProc<glGetVertexArrayIntegeri_vEXT>();
      del(vaobj, index, pname, ref param);
    }

    public static void GetVertexArrayIntegervEXT(uint vaobj, uint pname, ref int[] param)
    {
      glGetVertexArrayIntegervEXT del = (glGetVertexArrayIntegervEXT)GetProc<glGetVertexArrayIntegervEXT>();
      del(vaobj, pname, ref param);
    }

    public static void GetVertexArrayPointeri_vEXT(uint vaobj, uint index, uint pname, IntPtr param)
    {
      glGetVertexArrayPointeri_vEXT del = (glGetVertexArrayPointeri_vEXT)GetProc<glGetVertexArrayPointeri_vEXT>();
      del(vaobj, index, pname, param);
    }

    public static void GetVertexArrayPointervEXT(uint vaobj, uint pname, IntPtr param)
    {
      glGetVertexArrayPointervEXT del = (glGetVertexArrayPointervEXT)GetProc<glGetVertexArrayPointervEXT>();
      del(vaobj, pname, param);
    }

    public static void GetVertexAttribArrayObjectfvATI(uint index, uint pname, ref float[] parameters)
    {
      glGetVertexAttribArrayObjectfvATI del = (glGetVertexAttribArrayObjectfvATI)GetProc<glGetVertexAttribArrayObjectfvATI>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribArrayObjectivATI(uint index, uint pname, ref int[] parameters)
    {
      glGetVertexAttribArrayObjectivATI del = (glGetVertexAttribArrayObjectivATI)GetProc<glGetVertexAttribArrayObjectivATI>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribdv(uint index, uint pname, ref double[] parameters)
    {
      glGetVertexAttribdv del = (glGetVertexAttribdv)GetProc<glGetVertexAttribdv>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribdvARB(uint index, uint pname, ref double[] parameters)
    {
      glGetVertexAttribdvARB del = (glGetVertexAttribdvARB)GetProc<glGetVertexAttribdvARB>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribdvNV(uint index, uint pname, ref double[] parameters)
    {
      glGetVertexAttribdvNV del = (glGetVertexAttribdvNV)GetProc<glGetVertexAttribdvNV>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribfv(uint index, uint pname, ref float[] parameters)
    {
      glGetVertexAttribfv del = (glGetVertexAttribfv)GetProc<glGetVertexAttribfv>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribfvARB(uint index, uint pname, ref float[] parameters)
    {
      glGetVertexAttribfvARB del = (glGetVertexAttribfvARB)GetProc<glGetVertexAttribfvARB>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribfvNV(uint index, uint pname, ref float[] parameters)
    {
      glGetVertexAttribfvNV del = (glGetVertexAttribfvNV)GetProc<glGetVertexAttribfvNV>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribIiv(uint index, uint pname, ref int[] parameters)
    {
      glGetVertexAttribIiv del = (glGetVertexAttribIiv)GetProc<glGetVertexAttribIiv>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribIivEXT(uint index, uint pname, ref int[] parameters)
    {
      glGetVertexAttribIivEXT del = (glGetVertexAttribIivEXT)GetProc<glGetVertexAttribIivEXT>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribIuiv(uint index, uint pname, ref uint[] parameters)
    {
      glGetVertexAttribIuiv del = (glGetVertexAttribIuiv)GetProc<glGetVertexAttribIuiv>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribIuivEXT(uint index, uint pname, ref uint[] parameters)
    {
      glGetVertexAttribIuivEXT del = (glGetVertexAttribIuivEXT)GetProc<glGetVertexAttribIuivEXT>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribiv(uint index, uint pname, ref int[] parameters)
    {
      glGetVertexAttribiv del = (glGetVertexAttribiv)GetProc<glGetVertexAttribiv>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribivARB(uint index, uint pname, ref int[] parameters)
    {
      glGetVertexAttribivARB del = (glGetVertexAttribivARB)GetProc<glGetVertexAttribivARB>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribivNV(uint index, uint pname, ref int[] parameters)
    {
      glGetVertexAttribivNV del = (glGetVertexAttribivNV)GetProc<glGetVertexAttribivNV>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribLdv(uint index, uint pname, ref double[] parameters)
    {
      glGetVertexAttribLdv del = (glGetVertexAttribLdv)GetProc<glGetVertexAttribLdv>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribLdvEXT(uint index, uint pname, ref double[] parameters)
    {
      glGetVertexAttribLdvEXT del = (glGetVertexAttribLdvEXT)GetProc<glGetVertexAttribLdvEXT>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribLi64vNV(uint index, uint pname, ref long[] parameters)
    {
      glGetVertexAttribLi64vNV del = (glGetVertexAttribLi64vNV)GetProc<glGetVertexAttribLi64vNV>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribLui64vARB(uint index, uint pname, ref ulong[] parameters)
    {
      glGetVertexAttribLui64vARB del = (glGetVertexAttribLui64vARB)GetProc<glGetVertexAttribLui64vARB>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribLui64vNV(uint index, uint pname, ref ulong[] parameters)
    {
      glGetVertexAttribLui64vNV del = (glGetVertexAttribLui64vNV)GetProc<glGetVertexAttribLui64vNV>();
      del(index, pname, ref parameters);
    }

    public static void GetVertexAttribPointerv(uint index, uint pname, IntPtr pointer)
    {
      glGetVertexAttribPointerv del = (glGetVertexAttribPointerv)GetProc<glGetVertexAttribPointerv>();
      del(index, pname, pointer);
    }

    public static void GetVertexAttribPointervARB(uint index, uint pname, IntPtr pointer)
    {
      glGetVertexAttribPointervARB del = (glGetVertexAttribPointervARB)GetProc<glGetVertexAttribPointervARB>();
      del(index, pname, pointer);
    }

    public static void GetVertexAttribPointervNV(uint index, uint pname, IntPtr pointer)
    {
      glGetVertexAttribPointervNV del = (glGetVertexAttribPointervNV)GetProc<glGetVertexAttribPointervNV>();
      del(index, pname, pointer);
    }

    public static void GetVideoCaptureivNV(uint video_capture_slot, uint pname, ref int[] parameters)
    {
      glGetVideoCaptureivNV del = (glGetVideoCaptureivNV)GetProc<glGetVideoCaptureivNV>();
      del(video_capture_slot, pname, ref parameters);
    }

    public static void GetVideoCaptureStreamdvNV(uint video_capture_slot, uint stream, uint pname, ref double[] parameters)
    {
      glGetVideoCaptureStreamdvNV del = (glGetVideoCaptureStreamdvNV)GetProc<glGetVideoCaptureStreamdvNV>();
      del(video_capture_slot, stream, pname, ref parameters);
    }

    public static void GetVideoCaptureStreamfvNV(uint video_capture_slot, uint stream, uint pname, ref float[] parameters)
    {
      glGetVideoCaptureStreamfvNV del = (glGetVideoCaptureStreamfvNV)GetProc<glGetVideoCaptureStreamfvNV>();
      del(video_capture_slot, stream, pname, ref parameters);
    }

    public static void GetVideoCaptureStreamivNV(uint video_capture_slot, uint stream, uint pname, ref int[] parameters)
    {
      glGetVideoCaptureStreamivNV del = (glGetVideoCaptureStreamivNV)GetProc<glGetVideoCaptureStreamivNV>();
      del(video_capture_slot, stream, pname, ref parameters);
    }

    public static void GetVideoi64vNV(uint video_slot, uint pname, ref long[] parameters)
    {
      glGetVideoi64vNV del = (glGetVideoi64vNV)GetProc<glGetVideoi64vNV>();
      del(video_slot, pname, ref parameters);
    }

    public static void GetVideoivNV(uint video_slot, uint pname, ref int[] parameters)
    {
      glGetVideoivNV del = (glGetVideoivNV)GetProc<glGetVideoivNV>();
      del(video_slot, pname, ref parameters);
    }

    public static void GetVideoui64vNV(uint video_slot, uint pname, ref ulong[] parameters)
    {
      glGetVideoui64vNV del = (glGetVideoui64vNV)GetProc<glGetVideoui64vNV>();
      del(video_slot, pname, ref parameters);
    }

    public static void GetVideouivNV(uint video_slot, uint pname, ref uint[] parameters)
    {
      glGetVideouivNV del = (glGetVideouivNV)GetProc<glGetVideouivNV>();
      del(video_slot, pname, ref parameters);
    }

    public static void GlobalAlphaFactorbSUN(sbyte factor)
    {
      glGlobalAlphaFactorbSUN del = (glGlobalAlphaFactorbSUN)GetProc<glGlobalAlphaFactorbSUN>();
      del(factor);
    }

    public static void GlobalAlphaFactordSUN(double factor)
    {
      glGlobalAlphaFactordSUN del = (glGlobalAlphaFactordSUN)GetProc<glGlobalAlphaFactordSUN>();
      del(factor);
    }

    public static void GlobalAlphaFactorfSUN(float factor)
    {
      glGlobalAlphaFactorfSUN del = (glGlobalAlphaFactorfSUN)GetProc<glGlobalAlphaFactorfSUN>();
      del(factor);
    }

    public static void GlobalAlphaFactoriSUN(int factor)
    {
      glGlobalAlphaFactoriSUN del = (glGlobalAlphaFactoriSUN)GetProc<glGlobalAlphaFactoriSUN>();
      del(factor);
    }

    public static void GlobalAlphaFactorsSUN(short factor)
    {
      glGlobalAlphaFactorsSUN del = (glGlobalAlphaFactorsSUN)GetProc<glGlobalAlphaFactorsSUN>();
      del(factor);
    }

    public static void GlobalAlphaFactorubSUN(byte factor)
    {
      glGlobalAlphaFactorubSUN del = (glGlobalAlphaFactorubSUN)GetProc<glGlobalAlphaFactorubSUN>();
      del(factor);
    }

    public static void GlobalAlphaFactoruiSUN(uint factor)
    {
      glGlobalAlphaFactoruiSUN del = (glGlobalAlphaFactoruiSUN)GetProc<glGlobalAlphaFactoruiSUN>();
      del(factor);
    }

    public static void GlobalAlphaFactorusSUN(ushort factor)
    {
      glGlobalAlphaFactorusSUN del = (glGlobalAlphaFactorusSUN)GetProc<glGlobalAlphaFactorusSUN>();
      del(factor);
    }

    public static void HintPGI(uint target, int mode)
    {
      glHintPGI del = (glHintPGI)GetProc<glHintPGI>();
      del(target, mode);
    }

    public static void Histogram(uint target, int width, uint internalformat, bool sink)
    {
      glHistogram del = (glHistogram)GetProc<glHistogram>();
      del(target, width, internalformat, sink);
    }

    public static void HistogramEXT(uint target, int width, uint internalformat, bool sink)
    {
      glHistogramEXT del = (glHistogramEXT)GetProc<glHistogramEXT>();
      del(target, width, internalformat, sink);
    }

    public static void IglooInterfaceSGIX(uint pname, IntPtr parameters)
    {
      glIglooInterfaceSGIX del = (glIglooInterfaceSGIX)GetProc<glIglooInterfaceSGIX>();
      del(pname, parameters);
    }

    public static void ImageTransformParameterfHP(uint target, uint pname, float param)
    {
      glImageTransformParameterfHP del = (glImageTransformParameterfHP)GetProc<glImageTransformParameterfHP>();
      del(target, pname, param);
    }

    public static void ImageTransformParameterfvHP(uint target, uint pname, ref float[] parameters)
    {
      glImageTransformParameterfvHP del = (glImageTransformParameterfvHP)GetProc<glImageTransformParameterfvHP>();
      del(target, pname, ref parameters);
    }

    public static void ImageTransformParameteriHP(uint target, uint pname, int param)
    {
      glImageTransformParameteriHP del = (glImageTransformParameteriHP)GetProc<glImageTransformParameteriHP>();
      del(target, pname, param);
    }

    public static void ImageTransformParameterivHP(uint target, uint pname, ref int[] parameters)
    {
      glImageTransformParameterivHP del = (glImageTransformParameterivHP)GetProc<glImageTransformParameterivHP>();
      del(target, pname, ref parameters);
    }

    public static void IndexFormatNV(uint type, int stride)
    {
      glIndexFormatNV del = (glIndexFormatNV)GetProc<glIndexFormatNV>();
      del(type, stride);
    }

    public static void IndexFuncEXT(uint func, float reference)
    {
      glIndexFuncEXT del = (glIndexFuncEXT)GetProc<glIndexFuncEXT>();
      del(func, reference);
    }

    public static void IndexMaterialEXT(uint face, uint mode)
    {
      glIndexMaterialEXT del = (glIndexMaterialEXT)GetProc<glIndexMaterialEXT>();
      del(face, mode);
    }

    public static void IndexPointerEXT(uint type, int stride, int count, IntPtr pointer)
    {
      glIndexPointerEXT del = (glIndexPointerEXT)GetProc<glIndexPointerEXT>();
      del(type, stride, count, pointer);
    }

    public static void IndexPointerListIBM(uint type, int stride, IntPtr pointer, int ptrstride)
    {
      glIndexPointerListIBM del = (glIndexPointerListIBM)GetProc<glIndexPointerListIBM>();
      del(type, stride, pointer, ptrstride);
    }

    public static void IndexxOES(int component)
    {
      glIndexxOES del = (glIndexxOES)GetProc<glIndexxOES>();
      del(component);
    }

    public static void IndexxvOES(ref int[] component)
    {
      glIndexxvOES del = (glIndexxvOES)GetProc<glIndexxvOES>();
      del(ref component);
    }

    public static void InsertComponentEXT(uint res, uint src, uint num)
    {
      glInsertComponentEXT del = (glInsertComponentEXT)GetProc<glInsertComponentEXT>();
      del(res, src, num);
    }

    public static void InstrumentsBufferSGIX(int size, ref int[] buffer)
    {
      glInstrumentsBufferSGIX del = (glInstrumentsBufferSGIX)GetProc<glInstrumentsBufferSGIX>();
      del(size, ref buffer);
    }

    public static void InterpolatePathsNV(uint resultPath, uint pathA, uint pathB, float weight)
    {
      glInterpolatePathsNV del = (glInterpolatePathsNV)GetProc<glInterpolatePathsNV>();
      del(resultPath, pathA, pathB, weight);
    }

    public static void InvalidateBufferData(uint buffer)
    {
      glInvalidateBufferData del = (glInvalidateBufferData)GetProc<glInvalidateBufferData>();
      del(buffer);
    }

    public static void InvalidateBufferSubData(uint buffer, IntPtr offset, IntPtr length)
    {
      glInvalidateBufferSubData del = (glInvalidateBufferSubData)GetProc<glInvalidateBufferSubData>();
      del(buffer, offset, length);
    }

    public static void InvalidateFramebuffer(uint target, int numAttachments, ref uint[] attachments)
    {
      glInvalidateFramebuffer del = (glInvalidateFramebuffer)GetProc<glInvalidateFramebuffer>();
      del(target, numAttachments, ref attachments);
    }

    public static void InvalidateSubFramebuffer(uint target, int numAttachments, ref uint[] attachments, int x, int y, int width, int height)
    {
      glInvalidateSubFramebuffer del = (glInvalidateSubFramebuffer)GetProc<glInvalidateSubFramebuffer>();
      del(target, numAttachments, ref attachments, x, y, width, height);
    }

    public static void InvalidateTexImage(uint texture, int level)
    {
      glInvalidateTexImage del = (glInvalidateTexImage)GetProc<glInvalidateTexImage>();
      del(texture, level);
    }

    public static void InvalidateTexSubImage(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth)
    {
      glInvalidateTexSubImage del = (glInvalidateTexSubImage)GetProc<glInvalidateTexSubImage>();
      del(texture, level, xoffset, yoffset, zoffset, width, height, depth);
    }

    public static void LightEnviSGIX(uint pname, int param)
    {
      glLightEnviSGIX del = (glLightEnviSGIX)GetProc<glLightEnviSGIX>();
      del(pname, param);
    }

    public static void LightModelxOES(uint pname, int param)
    {
      glLightModelxOES del = (glLightModelxOES)GetProc<glLightModelxOES>();
      del(pname, param);
    }

    public static void LightModelxvOES(uint pname, ref int[] param)
    {
      glLightModelxvOES del = (glLightModelxvOES)GetProc<glLightModelxvOES>();
      del(pname, ref param);
    }

    public static void LightxOES(uint light, uint pname, int param)
    {
      glLightxOES del = (glLightxOES)GetProc<glLightxOES>();
      del(light, pname, param);
    }

    public static void LightxvOES(uint light, uint pname, ref int[] parameters)
    {
      glLightxvOES del = (glLightxvOES)GetProc<glLightxvOES>();
      del(light, pname, ref parameters);
    }

    public static void LineWidthxOES(int width)
    {
      glLineWidthxOES del = (glLineWidthxOES)GetProc<glLineWidthxOES>();
      del(width);
    }

    public static void LinkProgram(uint program)
    {
      glLinkProgram del = (glLinkProgram)GetProc<glLinkProgram>();
      del(program);
    }

    public static void LinkProgramARB(uint programObj)
    {
      glLinkProgramARB del = (glLinkProgramARB)GetProc<glLinkProgramARB>();
      del(programObj);
    }

    public static void ListParameterfSGIX(uint list, uint pname, float param)
    {
      glListParameterfSGIX del = (glListParameterfSGIX)GetProc<glListParameterfSGIX>();
      del(list, pname, param);
    }

    public static void ListParameterfvSGIX(uint list, uint pname, ref float[] parameters)
    {
      glListParameterfvSGIX del = (glListParameterfvSGIX)GetProc<glListParameterfvSGIX>();
      del(list, pname, ref parameters);
    }

    public static void ListParameteriSGIX(uint list, uint pname, int param)
    {
      glListParameteriSGIX del = (glListParameteriSGIX)GetProc<glListParameteriSGIX>();
      del(list, pname, param);
    }

    public static void ListParameterivSGIX(uint list, uint pname, ref int[] parameters)
    {
      glListParameterivSGIX del = (glListParameterivSGIX)GetProc<glListParameterivSGIX>();
      del(list, pname, ref parameters);
    }

    public static void LoadIdentityDeformationMapSGIX(uint mask)
    {
      glLoadIdentityDeformationMapSGIX del = (glLoadIdentityDeformationMapSGIX)GetProc<glLoadIdentityDeformationMapSGIX>();
      del(mask);
    }

    public static void LoadMatrixxOES(ref int[] m)
    {
      glLoadMatrixxOES del = (glLoadMatrixxOES)GetProc<glLoadMatrixxOES>();
      del(ref m);
    }

    public static void LoadProgramNV(uint target, uint id, int len, ref byte[] program)
    {
      glLoadProgramNV del = (glLoadProgramNV)GetProc<glLoadProgramNV>();
      del(target, id, len, ref program);
    }

    public static void LoadTransposeMatrixd(ref double[] m)
    {
      glLoadTransposeMatrixd del = (glLoadTransposeMatrixd)GetProc<glLoadTransposeMatrixd>();
      del(ref m);
    }

    public static void LoadTransposeMatrixdARB(ref double[] m)
    {
      glLoadTransposeMatrixdARB del = (glLoadTransposeMatrixdARB)GetProc<glLoadTransposeMatrixdARB>();
      del(ref m);
    }

    public static void LoadTransposeMatrixf(ref float[] m)
    {
      glLoadTransposeMatrixf del = (glLoadTransposeMatrixf)GetProc<glLoadTransposeMatrixf>();
      del(ref m);
    }

    public static void LoadTransposeMatrixfARB(ref float[] m)
    {
      glLoadTransposeMatrixfARB del = (glLoadTransposeMatrixfARB)GetProc<glLoadTransposeMatrixfARB>();
      del(ref m);
    }

    public static void LoadTransposeMatrixxOES(ref int[] m)
    {
      glLoadTransposeMatrixxOES del = (glLoadTransposeMatrixxOES)GetProc<glLoadTransposeMatrixxOES>();
      del(ref m);
    }

    public static void LockArraysEXT(int first, int count)
    {
      glLockArraysEXT del = (glLockArraysEXT)GetProc<glLockArraysEXT>();
      del(first, count);
    }

    public static void MakeBufferNonResidentNV(uint target)
    {
      glMakeBufferNonResidentNV del = (glMakeBufferNonResidentNV)GetProc<glMakeBufferNonResidentNV>();
      del(target);
    }

    public static void MakeBufferResidentNV(uint target, uint access)
    {
      glMakeBufferResidentNV del = (glMakeBufferResidentNV)GetProc<glMakeBufferResidentNV>();
      del(target, access);
    }

    public static void MakeImageHandleNonResidentARB(ulong handle)
    {
      glMakeImageHandleNonResidentARB del = (glMakeImageHandleNonResidentARB)GetProc<glMakeImageHandleNonResidentARB>();
      del(handle);
    }

    public static void MakeImageHandleNonResidentNV(ulong handle)
    {
      glMakeImageHandleNonResidentNV del = (glMakeImageHandleNonResidentNV)GetProc<glMakeImageHandleNonResidentNV>();
      del(handle);
    }

    public static void MakeImageHandleResidentARB(ulong handle, uint access)
    {
      glMakeImageHandleResidentARB del = (glMakeImageHandleResidentARB)GetProc<glMakeImageHandleResidentARB>();
      del(handle, access);
    }

    public static void MakeImageHandleResidentNV(ulong handle, uint access)
    {
      glMakeImageHandleResidentNV del = (glMakeImageHandleResidentNV)GetProc<glMakeImageHandleResidentNV>();
      del(handle, access);
    }

    public static void MakeNamedBufferNonResidentNV(uint buffer)
    {
      glMakeNamedBufferNonResidentNV del = (glMakeNamedBufferNonResidentNV)GetProc<glMakeNamedBufferNonResidentNV>();
      del(buffer);
    }

    public static void MakeNamedBufferResidentNV(uint buffer, uint access)
    {
      glMakeNamedBufferResidentNV del = (glMakeNamedBufferResidentNV)GetProc<glMakeNamedBufferResidentNV>();
      del(buffer, access);
    }

    public static void MakeTextureHandleNonResidentARB(ulong handle)
    {
      glMakeTextureHandleNonResidentARB del = (glMakeTextureHandleNonResidentARB)GetProc<glMakeTextureHandleNonResidentARB>();
      del(handle);
    }

    public static void MakeTextureHandleNonResidentNV(ulong handle)
    {
      glMakeTextureHandleNonResidentNV del = (glMakeTextureHandleNonResidentNV)GetProc<glMakeTextureHandleNonResidentNV>();
      del(handle);
    }

    public static void MakeTextureHandleResidentARB(ulong handle)
    {
      glMakeTextureHandleResidentARB del = (glMakeTextureHandleResidentARB)GetProc<glMakeTextureHandleResidentARB>();
      del(handle);
    }

    public static void MakeTextureHandleResidentNV(ulong handle)
    {
      glMakeTextureHandleResidentNV del = (glMakeTextureHandleResidentNV)GetProc<glMakeTextureHandleResidentNV>();
      del(handle);
    }

    public static void Map1xOES(uint target, int u1, int u2, int stride, int order, int points)
    {
      glMap1xOES del = (glMap1xOES)GetProc<glMap1xOES>();
      del(target, u1, u2, stride, order, points);
    }

    public static void Map2xOES(uint target, int u1, int u2, int ustride, int uorder, int v1, int v2, int vstride, int vorder, int points)
    {
      glMap2xOES del = (glMap2xOES)GetProc<glMap2xOES>();
      del(target, u1, u2, ustride, uorder, v1, v2, vstride, vorder, points);
    }

    public static void MapControlPointsNV(uint target, uint index, uint type, int ustride, int vstride, int uorder, int vorder, bool packed, IntPtr points)
    {
      glMapControlPointsNV del = (glMapControlPointsNV)GetProc<glMapControlPointsNV>();
      del(target, index, type, ustride, vstride, uorder, vorder, packed, points);
    }

    public static void MapGrid1xOES(int n, int u1, int u2)
    {
      glMapGrid1xOES del = (glMapGrid1xOES)GetProc<glMapGrid1xOES>();
      del(n, u1, u2);
    }

    public static void MapGrid2xOES(int n, int u1, int u2, int v1, int v2)
    {
      glMapGrid2xOES del = (glMapGrid2xOES)GetProc<glMapGrid2xOES>();
      del(n, u1, u2, v1, v2);
    }

    public static void MapParameterfvNV(uint target, uint pname, ref float[] parameters)
    {
      glMapParameterfvNV del = (glMapParameterfvNV)GetProc<glMapParameterfvNV>();
      del(target, pname, ref parameters);
    }

    public static void MapParameterivNV(uint target, uint pname, ref int[] parameters)
    {
      glMapParameterivNV del = (glMapParameterivNV)GetProc<glMapParameterivNV>();
      del(target, pname, ref parameters);
    }

    public static void MapVertexAttrib1dAPPLE(uint index, uint size, double u1, double u2, int stride, int order, ref double[] points)
    {
      glMapVertexAttrib1dAPPLE del = (glMapVertexAttrib1dAPPLE)GetProc<glMapVertexAttrib1dAPPLE>();
      del(index, size, u1, u2, stride, order, ref points);
    }

    public static void MapVertexAttrib1fAPPLE(uint index, uint size, float u1, float u2, int stride, int order, ref float[] points)
    {
      glMapVertexAttrib1fAPPLE del = (glMapVertexAttrib1fAPPLE)GetProc<glMapVertexAttrib1fAPPLE>();
      del(index, size, u1, u2, stride, order, ref points);
    }

    public static void MapVertexAttrib2dAPPLE(uint index, uint size, double u1, double u2, int ustride, int uorder, double v1, double v2, int vstride, int vorder, ref double[] points)
    {
      glMapVertexAttrib2dAPPLE del = (glMapVertexAttrib2dAPPLE)GetProc<glMapVertexAttrib2dAPPLE>();
      del(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, ref points);
    }

    public static void MapVertexAttrib2fAPPLE(uint index, uint size, float u1, float u2, int ustride, int uorder, float v1, float v2, int vstride, int vorder, ref float[] points)
    {
      glMapVertexAttrib2fAPPLE del = (glMapVertexAttrib2fAPPLE)GetProc<glMapVertexAttrib2fAPPLE>();
      del(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, ref points);
    }

    public static void MaterialxOES(uint face, uint pname, int param)
    {
      glMaterialxOES del = (glMaterialxOES)GetProc<glMaterialxOES>();
      del(face, pname, param);
    }

    public static void MaterialxvOES(uint face, uint pname, ref int[] param)
    {
      glMaterialxvOES del = (glMaterialxvOES)GetProc<glMaterialxvOES>();
      del(face, pname, ref param);
    }

    public static void MatrixFrustumEXT(uint mode, double left, double right, double bottom, double top, double zNear, double zFar)
    {
      glMatrixFrustumEXT del = (glMatrixFrustumEXT)GetProc<glMatrixFrustumEXT>();
      del(mode, left, right, bottom, top, zNear, zFar);
    }

    public static void MatrixIndexPointerARB(int size, uint type, int stride, IntPtr pointer)
    {
      glMatrixIndexPointerARB del = (glMatrixIndexPointerARB)GetProc<glMatrixIndexPointerARB>();
      del(size, type, stride, pointer);
    }

    public static void MatrixIndexubvARB(int size, ref byte[] indices)
    {
      glMatrixIndexubvARB del = (glMatrixIndexubvARB)GetProc<glMatrixIndexubvARB>();
      del(size, ref indices);
    }

    public static void MatrixIndexuivARB(int size, ref uint[] indices)
    {
      glMatrixIndexuivARB del = (glMatrixIndexuivARB)GetProc<glMatrixIndexuivARB>();
      del(size, ref indices);
    }

    public static void MatrixIndexusvARB(int size, ref ushort[] indices)
    {
      glMatrixIndexusvARB del = (glMatrixIndexusvARB)GetProc<glMatrixIndexusvARB>();
      del(size, ref indices);
    }

    public static void MatrixLoaddEXT(uint mode, ref double[] m)
    {
      glMatrixLoaddEXT del = (glMatrixLoaddEXT)GetProc<glMatrixLoaddEXT>();
      del(mode, ref m);
    }

    public static void MatrixLoadfEXT(uint mode, ref float[] m)
    {
      glMatrixLoadfEXT del = (glMatrixLoadfEXT)GetProc<glMatrixLoadfEXT>();
      del(mode, ref m);
    }

    public static void MatrixLoadIdentityEXT(uint mode)
    {
      glMatrixLoadIdentityEXT del = (glMatrixLoadIdentityEXT)GetProc<glMatrixLoadIdentityEXT>();
      del(mode);
    }

    public static void MatrixLoadTransposedEXT(uint mode, ref double[] m)
    {
      glMatrixLoadTransposedEXT del = (glMatrixLoadTransposedEXT)GetProc<glMatrixLoadTransposedEXT>();
      del(mode, ref m);
    }

    public static void MatrixLoadTransposefEXT(uint mode, ref float[] m)
    {
      glMatrixLoadTransposefEXT del = (glMatrixLoadTransposefEXT)GetProc<glMatrixLoadTransposefEXT>();
      del(mode, ref m);
    }

    public static void MatrixMultdEXT(uint mode, ref double[] m)
    {
      glMatrixMultdEXT del = (glMatrixMultdEXT)GetProc<glMatrixMultdEXT>();
      del(mode, ref m);
    }

    public static void MatrixMultfEXT(uint mode, ref float[] m)
    {
      glMatrixMultfEXT del = (glMatrixMultfEXT)GetProc<glMatrixMultfEXT>();
      del(mode, ref m);
    }

    public static void MatrixMultTransposedEXT(uint mode, ref double[] m)
    {
      glMatrixMultTransposedEXT del = (glMatrixMultTransposedEXT)GetProc<glMatrixMultTransposedEXT>();
      del(mode, ref m);
    }

    public static void MatrixMultTransposefEXT(uint mode, ref float[] m)
    {
      glMatrixMultTransposefEXT del = (glMatrixMultTransposefEXT)GetProc<glMatrixMultTransposefEXT>();
      del(mode, ref m);
    }

    public static void MatrixOrthoEXT(uint mode, double left, double right, double bottom, double top, double zNear, double zFar)
    {
      glMatrixOrthoEXT del = (glMatrixOrthoEXT)GetProc<glMatrixOrthoEXT>();
      del(mode, left, right, bottom, top, zNear, zFar);
    }

    public static void MatrixPopEXT(uint mode)
    {
      glMatrixPopEXT del = (glMatrixPopEXT)GetProc<glMatrixPopEXT>();
      del(mode);
    }

    public static void MatrixPushEXT(uint mode)
    {
      glMatrixPushEXT del = (glMatrixPushEXT)GetProc<glMatrixPushEXT>();
      del(mode);
    }

    public static void MatrixRotatedEXT(uint mode, double angle, double x, double y, double z)
    {
      glMatrixRotatedEXT del = (glMatrixRotatedEXT)GetProc<glMatrixRotatedEXT>();
      del(mode, angle, x, y, z);
    }

    public static void MatrixRotatefEXT(uint mode, float angle, float x, float y, float z)
    {
      glMatrixRotatefEXT del = (glMatrixRotatefEXT)GetProc<glMatrixRotatefEXT>();
      del(mode, angle, x, y, z);
    }

    public static void MatrixScaledEXT(uint mode, double x, double y, double z)
    {
      glMatrixScaledEXT del = (glMatrixScaledEXT)GetProc<glMatrixScaledEXT>();
      del(mode, x, y, z);
    }

    public static void MatrixScalefEXT(uint mode, float x, float y, float z)
    {
      glMatrixScalefEXT del = (glMatrixScalefEXT)GetProc<glMatrixScalefEXT>();
      del(mode, x, y, z);
    }

    public static void MatrixTranslatedEXT(uint mode, double x, double y, double z)
    {
      glMatrixTranslatedEXT del = (glMatrixTranslatedEXT)GetProc<glMatrixTranslatedEXT>();
      del(mode, x, y, z);
    }

    public static void MatrixTranslatefEXT(uint mode, float x, float y, float z)
    {
      glMatrixTranslatefEXT del = (glMatrixTranslatefEXT)GetProc<glMatrixTranslatefEXT>();
      del(mode, x, y, z);
    }

    public static void MemoryBarrier(uint barriers)
    {
      glMemoryBarrier del = (glMemoryBarrier)GetProc<glMemoryBarrier>();
      del(barriers);
    }

    public static void MemoryBarrierEXT(uint barriers)
    {
      glMemoryBarrierEXT del = (glMemoryBarrierEXT)GetProc<glMemoryBarrierEXT>();
      del(barriers);
    }

    public static void Minmax(uint target, uint internalformat, bool sink)
    {
      glMinmax del = (glMinmax)GetProc<glMinmax>();
      del(target, internalformat, sink);
    }

    public static void MinmaxEXT(uint target, uint internalformat, bool sink)
    {
      glMinmaxEXT del = (glMinmaxEXT)GetProc<glMinmaxEXT>();
      del(target, internalformat, sink);
    }

    public static void MinSampleShading(float value)
    {
      glMinSampleShading del = (glMinSampleShading)GetProc<glMinSampleShading>();
      del(value);
    }

    public static void MinSampleShadingARB(float value)
    {
      glMinSampleShadingARB del = (glMinSampleShadingARB)GetProc<glMinSampleShadingARB>();
      del(value);
    }

    public static void MultiDrawArrays(uint mode, ref int[] first, ref int[] count, int drawcount)
    {
      glMultiDrawArrays del = (glMultiDrawArrays)GetProc<glMultiDrawArrays>();
      del(mode, ref first, ref count, drawcount);
    }

    public static void MultiDrawArraysEXT(uint mode, ref int[] first, ref int[] count, int primcount)
    {
      glMultiDrawArraysEXT del = (glMultiDrawArraysEXT)GetProc<glMultiDrawArraysEXT>();
      del(mode, ref first, ref count, primcount);
    }

    public static void MultiDrawArraysIndirect(uint mode, IntPtr indirect, int drawcount, int stride)
    {
      glMultiDrawArraysIndirect del = (glMultiDrawArraysIndirect)GetProc<glMultiDrawArraysIndirect>();
      del(mode, indirect, drawcount, stride);
    }

    public static void MultiDrawArraysIndirectAMD(uint mode, IntPtr indirect, int primcount, int stride)
    {
      glMultiDrawArraysIndirectAMD del = (glMultiDrawArraysIndirectAMD)GetProc<glMultiDrawArraysIndirectAMD>();
      del(mode, indirect, primcount, stride);
    }

    public static void MultiDrawArraysIndirectBindlessNV(uint mode, IntPtr indirect, int drawCount, int stride, int vertexBufferCount)
    {
      glMultiDrawArraysIndirectBindlessNV del = (glMultiDrawArraysIndirectBindlessNV)GetProc<glMultiDrawArraysIndirectBindlessNV>();
      del(mode, indirect, drawCount, stride, vertexBufferCount);
    }

    public static void MultiDrawArraysIndirectCountARB(uint mode, IntPtr indirect, IntPtr drawcount, int maxdrawcount, int stride)
    {
      glMultiDrawArraysIndirectCountARB del = (glMultiDrawArraysIndirectCountARB)GetProc<glMultiDrawArraysIndirectCountARB>();
      del(mode, indirect, drawcount, maxdrawcount, stride);
    }

    public static void MultiDrawElementArrayAPPLE(uint mode, ref int[] first, ref int[] count, int primcount)
    {
      glMultiDrawElementArrayAPPLE del = (glMultiDrawElementArrayAPPLE)GetProc<glMultiDrawElementArrayAPPLE>();
      del(mode, ref first, ref count, primcount);
    }

    public static void MultiDrawElements(uint mode, ref int[] count, uint type, IntPtr indices, int drawcount)
    {
      glMultiDrawElements del = (glMultiDrawElements)GetProc<glMultiDrawElements>();
      del(mode, ref count, type, indices, drawcount);
    }

    public static void MultiDrawElementsBaseVertex(uint mode, ref int[] count, uint type, IntPtr indices, int drawcount, ref int[] basevertex)
    {
      glMultiDrawElementsBaseVertex del = (glMultiDrawElementsBaseVertex)GetProc<glMultiDrawElementsBaseVertex>();
      del(mode, ref count, type, indices, drawcount, ref basevertex);
    }

    public static void MultiDrawElementsEXT(uint mode, ref int[] count, uint type, IntPtr indices, int primcount)
    {
      glMultiDrawElementsEXT del = (glMultiDrawElementsEXT)GetProc<glMultiDrawElementsEXT>();
      del(mode, ref count, type, indices, primcount);
    }

    public static void MultiDrawElementsIndirect(uint mode, uint type, IntPtr indirect, int drawcount, int stride)
    {
      glMultiDrawElementsIndirect del = (glMultiDrawElementsIndirect)GetProc<glMultiDrawElementsIndirect>();
      del(mode, type, indirect, drawcount, stride);
    }

    public static void MultiDrawElementsIndirectAMD(uint mode, uint type, IntPtr indirect, int primcount, int stride)
    {
      glMultiDrawElementsIndirectAMD del = (glMultiDrawElementsIndirectAMD)GetProc<glMultiDrawElementsIndirectAMD>();
      del(mode, type, indirect, primcount, stride);
    }

    public static void MultiDrawElementsIndirectBindlessNV(uint mode, uint type, IntPtr indirect, int drawCount, int stride, int vertexBufferCount)
    {
      glMultiDrawElementsIndirectBindlessNV del = (glMultiDrawElementsIndirectBindlessNV)GetProc<glMultiDrawElementsIndirectBindlessNV>();
      del(mode, type, indirect, drawCount, stride, vertexBufferCount);
    }

    public static ulong GetTextureHandleNV(uint texture)
    {
      glGetTextureHandleNV del = (glGetTextureHandleNV)GetProc<glGetTextureHandleNV>();
      return del(texture);
    }

    public static void MultiDrawElementsIndirectCountARB(uint mode, uint type, IntPtr indirect, IntPtr drawcount, int maxdrawcount, int stride)
    {
      glMultiDrawElementsIndirectCountARB del = (glMultiDrawElementsIndirectCountARB)GetProc<glMultiDrawElementsIndirectCountARB>();
      del(mode, type, indirect, drawcount, maxdrawcount, stride);
    }

    public static void MultiDrawRangeElementArrayAPPLE(uint mode, uint start, uint end, ref int[] first, ref int[] count, int primcount)
    {
      glMultiDrawRangeElementArrayAPPLE del = (glMultiDrawRangeElementArrayAPPLE)GetProc<glMultiDrawRangeElementArrayAPPLE>();
      del(mode, start, end, ref first, ref count, primcount);
    }

    public static void MultiModeDrawArraysIBM(ref uint[] mode, ref int[] first, ref int[] count, int primcount, int modestride)
    {
      glMultiModeDrawArraysIBM del = (glMultiModeDrawArraysIBM)GetProc<glMultiModeDrawArraysIBM>();
      del(ref mode, ref first, ref count, primcount, modestride);
    }

    public static void MultiModeDrawElementsIBM(ref uint[] mode, ref int[] count, uint type, IntPtr indices, int primcount, int modestride)
    {
      glMultiModeDrawElementsIBM del = (glMultiModeDrawElementsIBM)GetProc<glMultiModeDrawElementsIBM>();
      del(ref mode, ref count, type, indices, primcount, modestride);
    }

    public static void MultiTexBufferEXT(uint texunit, uint target, uint internalformat, uint buffer)
    {
      glMultiTexBufferEXT del = (glMultiTexBufferEXT)GetProc<glMultiTexBufferEXT>();
      del(texunit, target, internalformat, buffer);
    }

    public static void MultiTexCoord1bOES(uint texture, sbyte s)
    {
      glMultiTexCoord1bOES del = (glMultiTexCoord1bOES)GetProc<glMultiTexCoord1bOES>();
      del(texture, s);
    }

    public static void MultiTexCoord1bvOES(uint texture, ref sbyte[] coords)
    {
      glMultiTexCoord1bvOES del = (glMultiTexCoord1bvOES)GetProc<glMultiTexCoord1bvOES>();
      del(texture, ref coords);
    }

    public static void MultiTexCoord1d(uint target, double s)
    {
      glMultiTexCoord1d del = (glMultiTexCoord1d)GetProc<glMultiTexCoord1d>();
      del(target, s);
    }

    public static void MultiTexCoord1dARB(uint target, double s)
    {
      glMultiTexCoord1dARB del = (glMultiTexCoord1dARB)GetProc<glMultiTexCoord1dARB>();
      del(target, s);
    }

    public static void MultiTexCoord1dv(uint target, ref double[] v)
    {
      glMultiTexCoord1dv del = (glMultiTexCoord1dv)GetProc<glMultiTexCoord1dv>();
      del(target, ref v);
    }

    public static void MultiTexCoord1dvARB(uint target, ref double[] v)
    {
      glMultiTexCoord1dvARB del = (glMultiTexCoord1dvARB)GetProc<glMultiTexCoord1dvARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord1f(uint target, float s)
    {
      glMultiTexCoord1f del = (glMultiTexCoord1f)GetProc<glMultiTexCoord1f>();
      del(target, s);
    }

    public static void MultiTexCoord1fARB(uint target, float s)
    {
      glMultiTexCoord1fARB del = (glMultiTexCoord1fARB)GetProc<glMultiTexCoord1fARB>();
      del(target, s);
    }

    public static void MultiTexCoord1fv(uint target, ref float[] v)
    {
      glMultiTexCoord1fv del = (glMultiTexCoord1fv)GetProc<glMultiTexCoord1fv>();
      del(target, ref v);
    }

    public static void MultiTexCoord1fvARB(uint target, ref float[] v)
    {
      glMultiTexCoord1fvARB del = (glMultiTexCoord1fvARB)GetProc<glMultiTexCoord1fvARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord1hNV(uint target, ushort s)
    {
      glMultiTexCoord1hNV del = (glMultiTexCoord1hNV)GetProc<glMultiTexCoord1hNV>();
      del(target, s);
    }

    public static void MultiTexCoord1hvNV(uint target, ref ushort[] v)
    {
      glMultiTexCoord1hvNV del = (glMultiTexCoord1hvNV)GetProc<glMultiTexCoord1hvNV>();
      del(target, ref v);
    }

    public static void MultiTexCoord1i(uint target, int s)
    {
      glMultiTexCoord1i del = (glMultiTexCoord1i)GetProc<glMultiTexCoord1i>();
      del(target, s);
    }

    public static void MultiTexCoord1iARB(uint target, int s)
    {
      glMultiTexCoord1iARB del = (glMultiTexCoord1iARB)GetProc<glMultiTexCoord1iARB>();
      del(target, s);
    }

    public static void MultiTexCoord1iv(uint target, ref int[] v)
    {
      glMultiTexCoord1iv del = (glMultiTexCoord1iv)GetProc<glMultiTexCoord1iv>();
      del(target, ref v);
    }

    public static void MultiTexCoord1ivARB(uint target, ref int[] v)
    {
      glMultiTexCoord1ivARB del = (glMultiTexCoord1ivARB)GetProc<glMultiTexCoord1ivARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord1s(uint target, short s)
    {
      glMultiTexCoord1s del = (glMultiTexCoord1s)GetProc<glMultiTexCoord1s>();
      del(target, s);
    }

    public static void MultiTexCoord1sARB(uint target, short s)
    {
      glMultiTexCoord1sARB del = (glMultiTexCoord1sARB)GetProc<glMultiTexCoord1sARB>();
      del(target, s);
    }

    public static void MultiTexCoord1sv(uint target, ref short[] v)
    {
      glMultiTexCoord1sv del = (glMultiTexCoord1sv)GetProc<glMultiTexCoord1sv>();
      del(target, ref v);
    }

    public static void MultiTexCoord1svARB(uint target, ref short[] v)
    {
      glMultiTexCoord1svARB del = (glMultiTexCoord1svARB)GetProc<glMultiTexCoord1svARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord1xOES(uint texture, int s)
    {
      glMultiTexCoord1xOES del = (glMultiTexCoord1xOES)GetProc<glMultiTexCoord1xOES>();
      del(texture, s);
    }

    public static void MultiTexCoord1xvOES(uint texture, ref int[] coords)
    {
      glMultiTexCoord1xvOES del = (glMultiTexCoord1xvOES)GetProc<glMultiTexCoord1xvOES>();
      del(texture, ref coords);
    }

    public static void MultiTexCoord2bOES(uint texture, sbyte s, sbyte t)
    {
      glMultiTexCoord2bOES del = (glMultiTexCoord2bOES)GetProc<glMultiTexCoord2bOES>();
      del(texture, s, t);
    }

    public static void MultiTexCoord2bvOES(uint texture, ref sbyte[] coords)
    {
      glMultiTexCoord2bvOES del = (glMultiTexCoord2bvOES)GetProc<glMultiTexCoord2bvOES>();
      del(texture, ref coords);
    }

    public static void MultiTexCoord2d(uint target, double s, double t)
    {
      glMultiTexCoord2d del = (glMultiTexCoord2d)GetProc<glMultiTexCoord2d>();
      del(target, s, t);
    }

    public static void MultiTexCoord2dARB(uint target, double s, double t)
    {
      glMultiTexCoord2dARB del = (glMultiTexCoord2dARB)GetProc<glMultiTexCoord2dARB>();
      del(target, s, t);
    }

    public static void MultiTexCoord2dv(uint target, ref double[] v)
    {
      glMultiTexCoord2dv del = (glMultiTexCoord2dv)GetProc<glMultiTexCoord2dv>();
      del(target, ref v);
    }

    public static void MultiTexCoord2dvARB(uint target, ref double[] v)
    {
      glMultiTexCoord2dvARB del = (glMultiTexCoord2dvARB)GetProc<glMultiTexCoord2dvARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord2f(uint target, float s, float t)
    {
      glMultiTexCoord2f del = (glMultiTexCoord2f)GetProc<glMultiTexCoord2f>();
      del(target, s, t);
    }

    public static void MultiTexCoord2fARB(uint target, float s, float t)
    {
      glMultiTexCoord2fARB del = (glMultiTexCoord2fARB)GetProc<glMultiTexCoord2fARB>();
      del(target, s, t);
    }

    public static void MultiTexCoord2fv(uint target, ref float[] v)
    {
      glMultiTexCoord2fv del = (glMultiTexCoord2fv)GetProc<glMultiTexCoord2fv>();
      del(target, ref v);
    }

    public static void MultiTexCoord2fvARB(uint target, ref float[] v)
    {
      glMultiTexCoord2fvARB del = (glMultiTexCoord2fvARB)GetProc<glMultiTexCoord2fvARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord2hNV(uint target, ushort s, ushort t)
    {
      glMultiTexCoord2hNV del = (glMultiTexCoord2hNV)GetProc<glMultiTexCoord2hNV>();
      del(target, s, t);
    }

    public static void MultiTexCoord2hvNV(uint target, ref ushort[] v)
    {
      glMultiTexCoord2hvNV del = (glMultiTexCoord2hvNV)GetProc<glMultiTexCoord2hvNV>();
      del(target, ref v);
    }

    public static void MultiTexCoord2i(uint target, int s, int t)
    {
      glMultiTexCoord2i del = (glMultiTexCoord2i)GetProc<glMultiTexCoord2i>();
      del(target, s, t);
    }

    public static void MultiTexCoord2iARB(uint target, int s, int t)
    {
      glMultiTexCoord2iARB del = (glMultiTexCoord2iARB)GetProc<glMultiTexCoord2iARB>();
      del(target, s, t);
    }

    public static void MultiTexCoord2iv(uint target, ref int[] v)
    {
      glMultiTexCoord2iv del = (glMultiTexCoord2iv)GetProc<glMultiTexCoord2iv>();
      del(target, ref v);
    }

    public static void MultiTexCoord2ivARB(uint target, ref int[] v)
    {
      glMultiTexCoord2ivARB del = (glMultiTexCoord2ivARB)GetProc<glMultiTexCoord2ivARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord2s(uint target, short s, short t)
    {
      glMultiTexCoord2s del = (glMultiTexCoord2s)GetProc<glMultiTexCoord2s>();
      del(target, s, t);
    }

    public static void MultiTexCoord2sARB(uint target, short s, short t)
    {
      glMultiTexCoord2sARB del = (glMultiTexCoord2sARB)GetProc<glMultiTexCoord2sARB>();
      del(target, s, t);
    }

    public static void MultiTexCoord2sv(uint target, ref short[] v)
    {
      glMultiTexCoord2sv del = (glMultiTexCoord2sv)GetProc<glMultiTexCoord2sv>();
      del(target, ref v);
    }

    public static void MultiTexCoord2svARB(uint target, ref short[] v)
    {
      glMultiTexCoord2svARB del = (glMultiTexCoord2svARB)GetProc<glMultiTexCoord2svARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord2xOES(uint texture, int s, int t)
    {
      glMultiTexCoord2xOES del = (glMultiTexCoord2xOES)GetProc<glMultiTexCoord2xOES>();
      del(texture, s, t);
    }

    public static void MultiTexCoord2xvOES(uint texture, ref int[] coords)
    {
      glMultiTexCoord2xvOES del = (glMultiTexCoord2xvOES)GetProc<glMultiTexCoord2xvOES>();
      del(texture, ref coords);
    }

    public static void MultiTexCoord3bOES(uint texture, sbyte s, sbyte t, sbyte r)
    {
      glMultiTexCoord3bOES del = (glMultiTexCoord3bOES)GetProc<glMultiTexCoord3bOES>();
      del(texture, s, t, r);
    }

    public static void MultiTexCoord3bvOES(uint texture, ref sbyte[] coords)
    {
      glMultiTexCoord3bvOES del = (glMultiTexCoord3bvOES)GetProc<glMultiTexCoord3bvOES>();
      del(texture, ref coords);
    }

    public static void MultiTexCoord3d(uint target, double s, double t, double r)
    {
      glMultiTexCoord3d del = (glMultiTexCoord3d)GetProc<glMultiTexCoord3d>();
      del(target, s, t, r);
    }

    public static void MultiTexCoord3dARB(uint target, double s, double t, double r)
    {
      glMultiTexCoord3dARB del = (glMultiTexCoord3dARB)GetProc<glMultiTexCoord3dARB>();
      del(target, s, t, r);
    }

    public static void MultiTexCoord3dv(uint target, ref double[] v)
    {
      glMultiTexCoord3dv del = (glMultiTexCoord3dv)GetProc<glMultiTexCoord3dv>();
      del(target, ref v);
    }

    public static void MultiTexCoord3dvARB(uint target, ref double[] v)
    {
      glMultiTexCoord3dvARB del = (glMultiTexCoord3dvARB)GetProc<glMultiTexCoord3dvARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord3f(uint target, float s, float t, float r)
    {
      glMultiTexCoord3f del = (glMultiTexCoord3f)GetProc<glMultiTexCoord3f>();
      del(target, s, t, r);
    }

    public static void MultiTexCoord3fARB(uint target, float s, float t, float r)
    {
      glMultiTexCoord3fARB del = (glMultiTexCoord3fARB)GetProc<glMultiTexCoord3fARB>();
      del(target, s, t, r);
    }

    public static void MultiTexCoord3fv(uint target, ref float[] v)
    {
      glMultiTexCoord3fv del = (glMultiTexCoord3fv)GetProc<glMultiTexCoord3fv>();
      del(target, ref v);
    }

    public static void MultiTexCoord3fvARB(uint target, ref float[] v)
    {
      glMultiTexCoord3fvARB del = (glMultiTexCoord3fvARB)GetProc<glMultiTexCoord3fvARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord3hNV(uint target, ushort s, ushort t, ushort r)
    {
      glMultiTexCoord3hNV del = (glMultiTexCoord3hNV)GetProc<glMultiTexCoord3hNV>();
      del(target, s, t, r);
    }

    public static void MultiTexCoord3hvNV(uint target, ref ushort[] v)
    {
      glMultiTexCoord3hvNV del = (glMultiTexCoord3hvNV)GetProc<glMultiTexCoord3hvNV>();
      del(target, ref v);
    }

    public static void MultiTexCoord3i(uint target, int s, int t, int r)
    {
      glMultiTexCoord3i del = (glMultiTexCoord3i)GetProc<glMultiTexCoord3i>();
      del(target, s, t, r);
    }

    public static void MultiTexCoord3iARB(uint target, int s, int t, int r)
    {
      glMultiTexCoord3iARB del = (glMultiTexCoord3iARB)GetProc<glMultiTexCoord3iARB>();
      del(target, s, t, r);
    }

    public static void MultiTexCoord3iv(uint target, ref int[] v)
    {
      glMultiTexCoord3iv del = (glMultiTexCoord3iv)GetProc<glMultiTexCoord3iv>();
      del(target, ref v);
    }

    public static void MultiTexCoord3ivARB(uint target, ref int[] v)
    {
      glMultiTexCoord3ivARB del = (glMultiTexCoord3ivARB)GetProc<glMultiTexCoord3ivARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord3s(uint target, short s, short t, short r)
    {
      glMultiTexCoord3s del = (glMultiTexCoord3s)GetProc<glMultiTexCoord3s>();
      del(target, s, t, r);
    }

    public static void MultiTexCoord3sARB(uint target, short s, short t, short r)
    {
      glMultiTexCoord3sARB del = (glMultiTexCoord3sARB)GetProc<glMultiTexCoord3sARB>();
      del(target, s, t, r);
    }

    public static void MultiTexCoord3sv(uint target, ref short[] v)
    {
      glMultiTexCoord3sv del = (glMultiTexCoord3sv)GetProc<glMultiTexCoord3sv>();
      del(target, ref v);
    }

    public static void MultiTexCoord3svARB(uint target, ref short[] v)
    {
      glMultiTexCoord3svARB del = (glMultiTexCoord3svARB)GetProc<glMultiTexCoord3svARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord3xOES(uint texture, int s, int t, int r)
    {
      glMultiTexCoord3xOES del = (glMultiTexCoord3xOES)GetProc<glMultiTexCoord3xOES>();
      del(texture, s, t, r);
    }

    public static void MultiTexCoord3xvOES(uint texture, ref int[] coords)
    {
      glMultiTexCoord3xvOES del = (glMultiTexCoord3xvOES)GetProc<glMultiTexCoord3xvOES>();
      del(texture, ref coords);
    }

    public static void MultiTexCoord4bOES(uint texture, sbyte s, sbyte t, sbyte r, sbyte q)
    {
      glMultiTexCoord4bOES del = (glMultiTexCoord4bOES)GetProc<glMultiTexCoord4bOES>();
      del(texture, s, t, r, q);
    }

    public static void MultiTexCoord4bvOES(uint texture, ref sbyte[] coords)
    {
      glMultiTexCoord4bvOES del = (glMultiTexCoord4bvOES)GetProc<glMultiTexCoord4bvOES>();
      del(texture, ref coords);
    }

    public static void MultiTexCoord4d(uint target, double s, double t, double r, double q)
    {
      glMultiTexCoord4d del = (glMultiTexCoord4d)GetProc<glMultiTexCoord4d>();
      del(target, s, t, r, q);
    }

    public static void MultiTexCoord4dARB(uint target, double s, double t, double r, double q)
    {
      glMultiTexCoord4dARB del = (glMultiTexCoord4dARB)GetProc<glMultiTexCoord4dARB>();
      del(target, s, t, r, q);
    }

    public static void MultiTexCoord4dv(uint target, ref double[] v)
    {
      glMultiTexCoord4dv del = (glMultiTexCoord4dv)GetProc<glMultiTexCoord4dv>();
      del(target, ref v);
    }

    public static void MultiTexCoord4dvARB(uint target, ref double[] v)
    {
      glMultiTexCoord4dvARB del = (glMultiTexCoord4dvARB)GetProc<glMultiTexCoord4dvARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord4f(uint target, float s, float t, float r, float q)
    {
      glMultiTexCoord4f del = (glMultiTexCoord4f)GetProc<glMultiTexCoord4f>();
      del(target, s, t, r, q);
    }

    public static void MultiTexCoord4fARB(uint target, float s, float t, float r, float q)
    {
      glMultiTexCoord4fARB del = (glMultiTexCoord4fARB)GetProc<glMultiTexCoord4fARB>();
      del(target, s, t, r, q);
    }

    public static void MultiTexCoord4fv(uint target, ref float[] v)
    {
      glMultiTexCoord4fv del = (glMultiTexCoord4fv)GetProc<glMultiTexCoord4fv>();
      del(target, ref v);
    }

    public static void MultiTexCoord4fvARB(uint target, ref float[] v)
    {
      glMultiTexCoord4fvARB del = (glMultiTexCoord4fvARB)GetProc<glMultiTexCoord4fvARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord4hNV(uint target, ushort s, ushort t, ushort r, ushort q)
    {
      glMultiTexCoord4hNV del = (glMultiTexCoord4hNV)GetProc<glMultiTexCoord4hNV>();
      del(target, s, t, r, q);
    }

    public static void MultiTexCoord4hvNV(uint target, ref ushort[] v)
    {
      glMultiTexCoord4hvNV del = (glMultiTexCoord4hvNV)GetProc<glMultiTexCoord4hvNV>();
      del(target, ref v);
    }

    public static void MultiTexCoord4i(uint target, int s, int t, int r, int q)
    {
      glMultiTexCoord4i del = (glMultiTexCoord4i)GetProc<glMultiTexCoord4i>();
      del(target, s, t, r, q);
    }

    public static void MultiTexCoord4iARB(uint target, int s, int t, int r, int q)
    {
      glMultiTexCoord4iARB del = (glMultiTexCoord4iARB)GetProc<glMultiTexCoord4iARB>();
      del(target, s, t, r, q);
    }

    public static void MultiTexCoord4iv(uint target, ref int[] v)
    {
      glMultiTexCoord4iv del = (glMultiTexCoord4iv)GetProc<glMultiTexCoord4iv>();
      del(target, ref v);
    }

    public static void MultiTexCoord4ivARB(uint target, ref int[] v)
    {
      glMultiTexCoord4ivARB del = (glMultiTexCoord4ivARB)GetProc<glMultiTexCoord4ivARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord4s(uint target, short s, short t, short r, short q)
    {
      glMultiTexCoord4s del = (glMultiTexCoord4s)GetProc<glMultiTexCoord4s>();
      del(target, s, t, r, q);
    }

    public static void MultiTexCoord4sARB(uint target, short s, short t, short r, short q)
    {
      glMultiTexCoord4sARB del = (glMultiTexCoord4sARB)GetProc<glMultiTexCoord4sARB>();
      del(target, s, t, r, q);
    }

    public static void MultiTexCoord4sv(uint target, ref short[] v)
    {
      glMultiTexCoord4sv del = (glMultiTexCoord4sv)GetProc<glMultiTexCoord4sv>();
      del(target, ref v);
    }

    public static void MultiTexCoord4svARB(uint target, ref short[] v)
    {
      glMultiTexCoord4svARB del = (glMultiTexCoord4svARB)GetProc<glMultiTexCoord4svARB>();
      del(target, ref v);
    }

    public static void MultiTexCoord4xOES(uint texture, int s, int t, int r, int q)
    {
      glMultiTexCoord4xOES del = (glMultiTexCoord4xOES)GetProc<glMultiTexCoord4xOES>();
      del(texture, s, t, r, q);
    }

    public static void MultiTexCoord4xvOES(uint texture, ref int[] coords)
    {
      glMultiTexCoord4xvOES del = (glMultiTexCoord4xvOES)GetProc<glMultiTexCoord4xvOES>();
      del(texture, ref coords);
    }

    public static void MultiTexCoordP1ui(uint texture, uint type, uint coords)
    {
      glMultiTexCoordP1ui del = (glMultiTexCoordP1ui)GetProc<glMultiTexCoordP1ui>();
      del(texture, type, coords);
    }

    public static void MultiTexCoordP1uiv(uint texture, uint type, ref uint[] coords)
    {
      glMultiTexCoordP1uiv del = (glMultiTexCoordP1uiv)GetProc<glMultiTexCoordP1uiv>();
      del(texture, type, ref coords);
    }

    public static void MultiTexCoordP2ui(uint texture, uint type, uint coords)
    {
      glMultiTexCoordP2ui del = (glMultiTexCoordP2ui)GetProc<glMultiTexCoordP2ui>();
      del(texture, type, coords);
    }

    public static void MultiTexCoordP2uiv(uint texture, uint type, ref uint[] coords)
    {
      glMultiTexCoordP2uiv del = (glMultiTexCoordP2uiv)GetProc<glMultiTexCoordP2uiv>();
      del(texture, type, ref coords);
    }

    public static void MultiTexCoordP3ui(uint texture, uint type, uint coords)
    {
      glMultiTexCoordP3ui del = (glMultiTexCoordP3ui)GetProc<glMultiTexCoordP3ui>();
      del(texture, type, coords);
    }

    public static void MultiTexCoordP3uiv(uint texture, uint type, ref uint[] coords)
    {
      glMultiTexCoordP3uiv del = (glMultiTexCoordP3uiv)GetProc<glMultiTexCoordP3uiv>();
      del(texture, type, ref coords);
    }

    public static void MultiTexCoordP4ui(uint texture, uint type, uint coords)
    {
      glMultiTexCoordP4ui del = (glMultiTexCoordP4ui)GetProc<glMultiTexCoordP4ui>();
      del(texture, type, coords);
    }

    public static void MultiTexCoordP4uiv(uint texture, uint type, ref uint[] coords)
    {
      glMultiTexCoordP4uiv del = (glMultiTexCoordP4uiv)GetProc<glMultiTexCoordP4uiv>();
      del(texture, type, ref coords);
    }

    public static void MultiTexCoordPointerEXT(uint texunit, int size, uint type, int stride, IntPtr pointer)
    {
      glMultiTexCoordPointerEXT del = (glMultiTexCoordPointerEXT)GetProc<glMultiTexCoordPointerEXT>();
      del(texunit, size, type, stride, pointer);
    }

    public static void MultiTexEnvfEXT(uint texunit, uint target, uint pname, float param)
    {
      glMultiTexEnvfEXT del = (glMultiTexEnvfEXT)GetProc<glMultiTexEnvfEXT>();
      del(texunit, target, pname, param);
    }

    public static void MultiTexEnvfvEXT(uint texunit, uint target, uint pname, ref float[] parameters)
    {
      glMultiTexEnvfvEXT del = (glMultiTexEnvfvEXT)GetProc<glMultiTexEnvfvEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void MultiTexEnviEXT(uint texunit, uint target, uint pname, int param)
    {
      glMultiTexEnviEXT del = (glMultiTexEnviEXT)GetProc<glMultiTexEnviEXT>();
      del(texunit, target, pname, param);
    }

    public static void MultiTexEnvivEXT(uint texunit, uint target, uint pname, ref int[] parameters)
    {
      glMultiTexEnvivEXT del = (glMultiTexEnvivEXT)GetProc<glMultiTexEnvivEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void MultiTexGendEXT(uint texunit, uint coord, uint pname, double param)
    {
      glMultiTexGendEXT del = (glMultiTexGendEXT)GetProc<glMultiTexGendEXT>();
      del(texunit, coord, pname, param);
    }

    public static void MultiTexGendvEXT(uint texunit, uint coord, uint pname, ref double[] parameters)
    {
      glMultiTexGendvEXT del = (glMultiTexGendvEXT)GetProc<glMultiTexGendvEXT>();
      del(texunit, coord, pname, ref parameters);
    }

    public static void MultiTexGenfEXT(uint texunit, uint coord, uint pname, float param)
    {
      glMultiTexGenfEXT del = (glMultiTexGenfEXT)GetProc<glMultiTexGenfEXT>();
      del(texunit, coord, pname, param);
    }

    public static void MultiTexGenfvEXT(uint texunit, uint coord, uint pname, ref float[] parameters)
    {
      glMultiTexGenfvEXT del = (glMultiTexGenfvEXT)GetProc<glMultiTexGenfvEXT>();
      del(texunit, coord, pname, ref parameters);
    }

    public static void MultiTexGeniEXT(uint texunit, uint coord, uint pname, int param)
    {
      glMultiTexGeniEXT del = (glMultiTexGeniEXT)GetProc<glMultiTexGeniEXT>();
      del(texunit, coord, pname, param);
    }

    public static void MultiTexGenivEXT(uint texunit, uint coord, uint pname, ref int[] parameters)
    {
      glMultiTexGenivEXT del = (glMultiTexGenivEXT)GetProc<glMultiTexGenivEXT>();
      del(texunit, coord, pname, ref parameters);
    }

    public static void MultiTexImage1DEXT(uint texunit, uint target, int level, int internalformat, int width, int border, uint format, uint type, IntPtr pixels)
    {
      glMultiTexImage1DEXT del = (glMultiTexImage1DEXT)GetProc<glMultiTexImage1DEXT>();
      del(texunit, target, level, internalformat, width, border, format, type, pixels);
    }

    public static void MultiTexImage2DEXT(uint texunit, uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels)
    {
      glMultiTexImage2DEXT del = (glMultiTexImage2DEXT)GetProc<glMultiTexImage2DEXT>();
      del(texunit, target, level, internalformat, width, height, border, format, type, pixels);
    }

    public static void MultiTexImage3DEXT(uint texunit, uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, IntPtr pixels)
    {
      glMultiTexImage3DEXT del = (glMultiTexImage3DEXT)GetProc<glMultiTexImage3DEXT>();
      del(texunit, target, level, internalformat, width, height, depth, border, format, type, pixels);
    }

    public static void MultiTexParameterfEXT(uint texunit, uint target, uint pname, float param)
    {
      glMultiTexParameterfEXT del = (glMultiTexParameterfEXT)GetProc<glMultiTexParameterfEXT>();
      del(texunit, target, pname, param);
    }

    public static void MultiTexParameterfvEXT(uint texunit, uint target, uint pname, ref float[] parameters)
    {
      glMultiTexParameterfvEXT del = (glMultiTexParameterfvEXT)GetProc<glMultiTexParameterfvEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void MultiTexParameteriEXT(uint texunit, uint target, uint pname, int param)
    {
      glMultiTexParameteriEXT del = (glMultiTexParameteriEXT)GetProc<glMultiTexParameteriEXT>();
      del(texunit, target, pname, param);
    }

    public static void MultiTexParameterIivEXT(uint texunit, uint target, uint pname, ref int[] parameters)
    {
      glMultiTexParameterIivEXT del = (glMultiTexParameterIivEXT)GetProc<glMultiTexParameterIivEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void MultiTexParameterIuivEXT(uint texunit, uint target, uint pname, ref uint[] parameters)
    {
      glMultiTexParameterIuivEXT del = (glMultiTexParameterIuivEXT)GetProc<glMultiTexParameterIuivEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void MultiTexParameterivEXT(uint texunit, uint target, uint pname, ref int[] parameters)
    {
      glMultiTexParameterivEXT del = (glMultiTexParameterivEXT)GetProc<glMultiTexParameterivEXT>();
      del(texunit, target, pname, ref parameters);
    }

    public static void MultiTexRenderbufferEXT(uint texunit, uint target, uint renderbuffer)
    {
      glMultiTexRenderbufferEXT del = (glMultiTexRenderbufferEXT)GetProc<glMultiTexRenderbufferEXT>();
      del(texunit, target, renderbuffer);
    }

    public static void MultiTexSubImage1DEXT(uint texunit, uint target, int level, int xoffset, int width, uint format, uint type, IntPtr pixels)
    {
      glMultiTexSubImage1DEXT del = (glMultiTexSubImage1DEXT)GetProc<glMultiTexSubImage1DEXT>();
      del(texunit, target, level, xoffset, width, format, type, pixels);
    }

    public static void MultiTexSubImage2DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, IntPtr pixels)
    {
      glMultiTexSubImage2DEXT del = (glMultiTexSubImage2DEXT)GetProc<glMultiTexSubImage2DEXT>();
      del(texunit, target, level, xoffset, yoffset, width, height, format, type, pixels);
    }

    public static void MultiTexSubImage3DEXT(uint texunit, uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, IntPtr pixels)
    {
      glMultiTexSubImage3DEXT del = (glMultiTexSubImage3DEXT)GetProc<glMultiTexSubImage3DEXT>();
      del(texunit, target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
    }

    public static void MultMatrixxOES(ref int[] m)
    {
      glMultMatrixxOES del = (glMultMatrixxOES)GetProc<glMultMatrixxOES>();
      del(ref m);
    }

    public static void MultTransposeMatrixd(ref double[] m)
    {
      glMultTransposeMatrixd del = (glMultTransposeMatrixd)GetProc<glMultTransposeMatrixd>();
      del(ref m);
    }

    public static void MultTransposeMatrixdARB(ref double[] m)
    {
      glMultTransposeMatrixdARB del = (glMultTransposeMatrixdARB)GetProc<glMultTransposeMatrixdARB>();
      del(ref m);
    }

    public static void MultTransposeMatrixf(ref float[] m)
    {
      glMultTransposeMatrixf del = (glMultTransposeMatrixf)GetProc<glMultTransposeMatrixf>();
      del(ref m);
    }

    public static void MultTransposeMatrixfARB(ref float[] m)
    {
      glMultTransposeMatrixfARB del = (glMultTransposeMatrixfARB)GetProc<glMultTransposeMatrixfARB>();
      del(ref m);
    }

    public static void MultTransposeMatrixxOES(ref int[] m)
    {
      glMultTransposeMatrixxOES del = (glMultTransposeMatrixxOES)GetProc<glMultTransposeMatrixxOES>();
      del(ref m);
    }

    public static void NamedBufferDataEXT(uint buffer, IntPtr size, IntPtr data, uint usage)
    {
      glNamedBufferDataEXT del = (glNamedBufferDataEXT)GetProc<glNamedBufferDataEXT>();
      del(buffer, size, data, usage);
    }

    public static void NamedBufferStorageEXT(uint buffer, IntPtr size, IntPtr data, uint flags)
    {
      glNamedBufferStorageEXT del = (glNamedBufferStorageEXT)GetProc<glNamedBufferStorageEXT>();
      del(buffer, size, data, flags);
    }

    public static void NamedBufferSubDataEXT(uint buffer, IntPtr offset, IntPtr size, IntPtr data)
    {
      glNamedBufferSubDataEXT del = (glNamedBufferSubDataEXT)GetProc<glNamedBufferSubDataEXT>();
      del(buffer, offset, size, data);
    }

    public static void NamedCopyBufferSubDataEXT(uint readBuffer, uint writeBuffer, IntPtr readOffset, IntPtr writeOffset, IntPtr size)
    {
      glNamedCopyBufferSubDataEXT del = (glNamedCopyBufferSubDataEXT)GetProc<glNamedCopyBufferSubDataEXT>();
      del(readBuffer, writeBuffer, readOffset, writeOffset, size);
    }

    public static void NamedFramebufferParameteriEXT(uint framebuffer, uint pname, int param)
    {
      glNamedFramebufferParameteriEXT del = (glNamedFramebufferParameteriEXT)GetProc<glNamedFramebufferParameteriEXT>();
      del(framebuffer, pname, param);
    }

    public static void NamedFramebufferRenderbufferEXT(uint framebuffer, uint attachment, uint renderbuffertarget, uint renderbuffer)
    {
      glNamedFramebufferRenderbufferEXT del = (glNamedFramebufferRenderbufferEXT)GetProc<glNamedFramebufferRenderbufferEXT>();
      del(framebuffer, attachment, renderbuffertarget, renderbuffer);
    }

    public static void NamedFramebufferTexture1DEXT(uint framebuffer, uint attachment, uint textarget, uint texture, int level)
    {
      glNamedFramebufferTexture1DEXT del = (glNamedFramebufferTexture1DEXT)GetProc<glNamedFramebufferTexture1DEXT>();
      del(framebuffer, attachment, textarget, texture, level);
    }

    public static void NamedFramebufferTexture2DEXT(uint framebuffer, uint attachment, uint textarget, uint texture, int level)
    {
      glNamedFramebufferTexture2DEXT del = (glNamedFramebufferTexture2DEXT)GetProc<glNamedFramebufferTexture2DEXT>();
      del(framebuffer, attachment, textarget, texture, level);
    }

    public static void NamedFramebufferTexture3DEXT(uint framebuffer, uint attachment, uint textarget, uint texture, int level, int zoffset)
    {
      glNamedFramebufferTexture3DEXT del = (glNamedFramebufferTexture3DEXT)GetProc<glNamedFramebufferTexture3DEXT>();
      del(framebuffer, attachment, textarget, texture, level, zoffset);
    }

    public static void NamedFramebufferTextureEXT(uint framebuffer, uint attachment, uint texture, int level)
    {
      glNamedFramebufferTextureEXT del = (glNamedFramebufferTextureEXT)GetProc<glNamedFramebufferTextureEXT>();
      del(framebuffer, attachment, texture, level);
    }

    public static void NamedFramebufferTextureFaceEXT(uint framebuffer, uint attachment, uint texture, int level, uint face)
    {
      glNamedFramebufferTextureFaceEXT del = (glNamedFramebufferTextureFaceEXT)GetProc<glNamedFramebufferTextureFaceEXT>();
      del(framebuffer, attachment, texture, level, face);
    }

    public static void NamedFramebufferTextureLayerEXT(uint framebuffer, uint attachment, uint texture, int level, int layer)
    {
      glNamedFramebufferTextureLayerEXT del = (glNamedFramebufferTextureLayerEXT)GetProc<glNamedFramebufferTextureLayerEXT>();
      del(framebuffer, attachment, texture, level, layer);
    }

    public static void NamedProgramLocalParameter4dEXT(uint program, uint target, uint index, double x, double y, double z, double w)
    {
      glNamedProgramLocalParameter4dEXT del = (glNamedProgramLocalParameter4dEXT)GetProc<glNamedProgramLocalParameter4dEXT>();
      del(program, target, index, x, y, z, w);
    }

    public static void NamedProgramLocalParameter4dvEXT(uint program, uint target, uint index, ref double[] parameters)
    {
      glNamedProgramLocalParameter4dvEXT del = (glNamedProgramLocalParameter4dvEXT)GetProc<glNamedProgramLocalParameter4dvEXT>();
      del(program, target, index, ref parameters);
    }

    public static void NamedProgramLocalParameter4fEXT(uint program, uint target, uint index, float x, float y, float z, float w)
    {
      glNamedProgramLocalParameter4fEXT del = (glNamedProgramLocalParameter4fEXT)GetProc<glNamedProgramLocalParameter4fEXT>();
      del(program, target, index, x, y, z, w);
    }

    public static void NamedProgramLocalParameter4fvEXT(uint program, uint target, uint index, ref float[] parameters)
    {
      glNamedProgramLocalParameter4fvEXT del = (glNamedProgramLocalParameter4fvEXT)GetProc<glNamedProgramLocalParameter4fvEXT>();
      del(program, target, index, ref parameters);
    }

    public static void NamedProgramLocalParameterI4iEXT(uint program, uint target, uint index, int x, int y, int z, int w)
    {
      glNamedProgramLocalParameterI4iEXT del = (glNamedProgramLocalParameterI4iEXT)GetProc<glNamedProgramLocalParameterI4iEXT>();
      del(program, target, index, x, y, z, w);
    }

    public static void NamedProgramLocalParameterI4ivEXT(uint program, uint target, uint index, ref int[] parameters)
    {
      glNamedProgramLocalParameterI4ivEXT del = (glNamedProgramLocalParameterI4ivEXT)GetProc<glNamedProgramLocalParameterI4ivEXT>();
      del(program, target, index, ref parameters);
    }

    public static void NamedProgramLocalParameterI4uiEXT(uint program, uint target, uint index, uint x, uint y, uint z, uint w)
    {
      glNamedProgramLocalParameterI4uiEXT del = (glNamedProgramLocalParameterI4uiEXT)GetProc<glNamedProgramLocalParameterI4uiEXT>();
      del(program, target, index, x, y, z, w);
    }

    public static void NamedProgramLocalParameterI4uivEXT(uint program, uint target, uint index, ref uint[] parameters)
    {
      glNamedProgramLocalParameterI4uivEXT del = (glNamedProgramLocalParameterI4uivEXT)GetProc<glNamedProgramLocalParameterI4uivEXT>();
      del(program, target, index, ref parameters);
    }

    public static void NamedProgramLocalParameters4fvEXT(uint program, uint target, uint index, int count, ref float[] parameters)
    {
      glNamedProgramLocalParameters4fvEXT del = (glNamedProgramLocalParameters4fvEXT)GetProc<glNamedProgramLocalParameters4fvEXT>();
      del(program, target, index, count, ref parameters);
    }

    public static void NamedProgramLocalParametersI4ivEXT(uint program, uint target, uint index, int count, ref int[] parameters)
    {
      glNamedProgramLocalParametersI4ivEXT del = (glNamedProgramLocalParametersI4ivEXT)GetProc<glNamedProgramLocalParametersI4ivEXT>();
      del(program, target, index, count, ref parameters);
    }

    public static void NamedProgramLocalParametersI4uivEXT(uint program, uint target, uint index, int count, ref uint[] parameters)
    {
      glNamedProgramLocalParametersI4uivEXT del = (glNamedProgramLocalParametersI4uivEXT)GetProc<glNamedProgramLocalParametersI4uivEXT>();
      del(program, target, index, count, ref parameters);
    }

    public static void NamedProgramStringEXT(uint program, uint target, uint format, int len, IntPtr str)
    {
      glNamedProgramStringEXT del = (glNamedProgramStringEXT)GetProc<glNamedProgramStringEXT>();
      del(program, target, format, len, str);
    }

    public static void NamedRenderbufferStorageEXT(uint renderbuffer, uint internalformat, int width, int height)
    {
      glNamedRenderbufferStorageEXT del = (glNamedRenderbufferStorageEXT)GetProc<glNamedRenderbufferStorageEXT>();
      del(renderbuffer, internalformat, width, height);
    }

    public static void NamedRenderbufferStorageMultisampleCoverageEXT(uint renderbuffer, int coverageSamples, int colorSamples, uint internalformat, int width, int height)
    {
      glNamedRenderbufferStorageMultisampleCoverageEXT del = (glNamedRenderbufferStorageMultisampleCoverageEXT)GetProc<glNamedRenderbufferStorageMultisampleCoverageEXT>();
      del(renderbuffer, coverageSamples, colorSamples, internalformat, width, height);
    }

    public static void NamedRenderbufferStorageMultisampleEXT(uint renderbuffer, int samples, uint internalformat, int width, int height)
    {
      glNamedRenderbufferStorageMultisampleEXT del = (glNamedRenderbufferStorageMultisampleEXT)GetProc<glNamedRenderbufferStorageMultisampleEXT>();
      del(renderbuffer, samples, internalformat, width, height);
    }

    public static void NamedStringARB(uint type, int namelen, ref sbyte[] name, int stringlen, ref sbyte[] str)
    {
      glNamedStringARB del = (glNamedStringARB)GetProc<glNamedStringARB>();
      del(type, namelen, ref name, stringlen, ref str);
    }

    public static void Normal3fVertex3fSUN(float nx, float ny, float nz, float x, float y, float z)
    {
      glNormal3fVertex3fSUN del = (glNormal3fVertex3fSUN)GetProc<glNormal3fVertex3fSUN>();
      del(nx, ny, nz, x, y, z);
    }

    public static void Normal3fVertex3fvSUN(ref float[] n, ref float[] v)
    {
      glNormal3fVertex3fvSUN del = (glNormal3fVertex3fvSUN)GetProc<glNormal3fVertex3fvSUN>();
      del(ref n, ref v);
    }

    public static void Normal3hNV(ushort nx, ushort ny, ushort nz)
    {
      glNormal3hNV del = (glNormal3hNV)GetProc<glNormal3hNV>();
      del(nx, ny, nz);
    }

    public static void Normal3hvNV(ref ushort[] v)
    {
      glNormal3hvNV del = (glNormal3hvNV)GetProc<glNormal3hvNV>();
      del(ref v);
    }

    public static void Normal3xOES(int nx, int ny, int nz)
    {
      glNormal3xOES del = (glNormal3xOES)GetProc<glNormal3xOES>();
      del(nx, ny, nz);
    }

    public static void Normal3xvOES(ref int[] coords)
    {
      glNormal3xvOES del = (glNormal3xvOES)GetProc<glNormal3xvOES>();
      del(ref coords);
    }

    public static void NormalFormatNV(uint type, int stride)
    {
      glNormalFormatNV del = (glNormalFormatNV)GetProc<glNormalFormatNV>();
      del(type, stride);
    }

    public static void NormalP3ui(uint type, uint coords)
    {
      glNormalP3ui del = (glNormalP3ui)GetProc<glNormalP3ui>();
      del(type, coords);
    }

    public static void NormalP3uiv(uint type, ref uint[] coords)
    {
      glNormalP3uiv del = (glNormalP3uiv)GetProc<glNormalP3uiv>();
      del(type, ref coords);
    }

    public static void NormalPointerEXT(uint type, int stride, int count, IntPtr pointer)
    {
      glNormalPointerEXT del = (glNormalPointerEXT)GetProc<glNormalPointerEXT>();
      del(type, stride, count, pointer);
    }

    public static void NormalPointerListIBM(uint type, int stride, IntPtr pointer, int ptrstride)
    {
      glNormalPointerListIBM del = (glNormalPointerListIBM)GetProc<glNormalPointerListIBM>();
      del(type, stride, pointer, ptrstride);
    }

    public static void NormalPointervINTEL(uint type, IntPtr pointer)
    {
      glNormalPointervINTEL del = (glNormalPointervINTEL)GetProc<glNormalPointervINTEL>();
      del(type, pointer);
    }

    public static void NormalStream3bATI(uint stream, sbyte nx, sbyte ny, sbyte nz)
    {
      glNormalStream3bATI del = (glNormalStream3bATI)GetProc<glNormalStream3bATI>();
      del(stream, nx, ny, nz);
    }

    public static void NormalStream3bvATI(uint stream, ref sbyte[] coords)
    {
      glNormalStream3bvATI del = (glNormalStream3bvATI)GetProc<glNormalStream3bvATI>();
      del(stream, ref coords);
    }

    public static void NormalStream3dATI(uint stream, double nx, double ny, double nz)
    {
      glNormalStream3dATI del = (glNormalStream3dATI)GetProc<glNormalStream3dATI>();
      del(stream, nx, ny, nz);
    }

    public static void NormalStream3dvATI(uint stream, ref double[] coords)
    {
      glNormalStream3dvATI del = (glNormalStream3dvATI)GetProc<glNormalStream3dvATI>();
      del(stream, ref coords);
    }

    public static void NormalStream3fATI(uint stream, float nx, float ny, float nz)
    {
      glNormalStream3fATI del = (glNormalStream3fATI)GetProc<glNormalStream3fATI>();
      del(stream, nx, ny, nz);
    }

    public static void NormalStream3fvATI(uint stream, ref float[] coords)
    {
      glNormalStream3fvATI del = (glNormalStream3fvATI)GetProc<glNormalStream3fvATI>();
      del(stream, ref coords);
    }

    public static void NormalStream3iATI(uint stream, int nx, int ny, int nz)
    {
      glNormalStream3iATI del = (glNormalStream3iATI)GetProc<glNormalStream3iATI>();
      del(stream, nx, ny, nz);
    }

    public static void NormalStream3ivATI(uint stream, ref int[] coords)
    {
      glNormalStream3ivATI del = (glNormalStream3ivATI)GetProc<glNormalStream3ivATI>();
      del(stream, ref coords);
    }

    public static void NormalStream3sATI(uint stream, short nx, short ny, short nz)
    {
      glNormalStream3sATI del = (glNormalStream3sATI)GetProc<glNormalStream3sATI>();
      del(stream, nx, ny, nz);
    }

    public static void NormalStream3svATI(uint stream, ref short[] coords)
    {
      glNormalStream3svATI del = (glNormalStream3svATI)GetProc<glNormalStream3svATI>();
      del(stream, ref coords);
    }

    public static void ObjectLabel(uint identifier, uint name, int length, ref sbyte[] label)
    {
      glObjectLabel del = (glObjectLabel)GetProc<glObjectLabel>();
      del(identifier, name, length, ref label);
    }

    public static void ObjectPtrLabel(IntPtr ptr, int length, ref sbyte[] label)
    {
      glObjectPtrLabel del = (glObjectPtrLabel)GetProc<glObjectPtrLabel>();
      del(ptr, length, ref label);
    }

    public static void OrthofOES(float l, float r, float b, float t, float n, float f)
    {
      glOrthofOES del = (glOrthofOES)GetProc<glOrthofOES>();
      del(l, r, b, t, n, f);
    }

    public static void OrthoxOES(int l, int r, int b, int t, int n, int f)
    {
      glOrthoxOES del = (glOrthoxOES)GetProc<glOrthoxOES>();
      del(l, r, b, t, n, f);
    }

    public static void PassTexCoordATI(uint dst, uint coord, uint swizzle)
    {
      glPassTexCoordATI del = (glPassTexCoordATI)GetProc<glPassTexCoordATI>();
      del(dst, coord, swizzle);
    }

    public static void PassThroughxOES(int token)
    {
      glPassThroughxOES del = (glPassThroughxOES)GetProc<glPassThroughxOES>();
      del(token);
    }

    public static void PatchParameterfv(uint pname, ref float[] values)
    {
      glPatchParameterfv del = (glPatchParameterfv)GetProc<glPatchParameterfv>();
      del(pname, ref values);
    }

    public static void PatchParameteri(uint pname, int value)
    {
      glPatchParameteri del = (glPatchParameteri)GetProc<glPatchParameteri>();
      del(pname, value);
    }

    public static void PathColorGenNV(uint color, uint genMode, uint colorFormat, ref float[] coeffs)
    {
      glPathColorGenNV del = (glPathColorGenNV)GetProc<glPathColorGenNV>();
      del(color, genMode, colorFormat, ref coeffs);
    }

    public static void PathCommandsNV(uint path, int numCommands, ref byte[] commands, int numCoords, uint coordType, IntPtr coords)
    {
      glPathCommandsNV del = (glPathCommandsNV)GetProc<glPathCommandsNV>();
      del(path, numCommands, ref commands, numCoords, coordType, coords);
    }

    public static void PathCoordsNV(uint path, int numCoords, uint coordType, IntPtr coords)
    {
      glPathCoordsNV del = (glPathCoordsNV)GetProc<glPathCoordsNV>();
      del(path, numCoords, coordType, coords);
    }

    public static void PathCoverDepthFuncNV(uint func)
    {
      glPathCoverDepthFuncNV del = (glPathCoverDepthFuncNV)GetProc<glPathCoverDepthFuncNV>();
      del(func);
    }

    public static void PathDashArrayNV(uint path, int dashCount, ref float[] dashArray)
    {
      glPathDashArrayNV del = (glPathDashArrayNV)GetProc<glPathDashArrayNV>();
      del(path, dashCount, ref dashArray);
    }

    public static void PathFogGenNV(uint genMode)
    {
      glPathFogGenNV del = (glPathFogGenNV)GetProc<glPathFogGenNV>();
      del(genMode);
    }

    public static void PathGlyphRangeNV(uint firstPathName, uint fontTarget, IntPtr fontName, uint fontStyle, uint firstGlyph, int numGlyphs, uint handleMissingGlyphs, uint pathParameterTemplate, float emScale)
    {
      glPathGlyphRangeNV del = (glPathGlyphRangeNV)GetProc<glPathGlyphRangeNV>();
      del(firstPathName, fontTarget, fontName, fontStyle, firstGlyph, numGlyphs, handleMissingGlyphs, pathParameterTemplate, emScale);
    }

    public static void PathGlyphsNV(uint firstPathName, uint fontTarget, IntPtr fontName, uint fontStyle, int numGlyphs, uint type, IntPtr charcodes, uint handleMissingGlyphs, uint pathParameterTemplate, float emScale)
    {
      glPathGlyphsNV del = (glPathGlyphsNV)GetProc<glPathGlyphsNV>();
      del(firstPathName, fontTarget, fontName, fontStyle, numGlyphs, type, charcodes, handleMissingGlyphs, pathParameterTemplate, emScale);
    }

    public static void PathParameterfNV(uint path, uint pname, float value)
    {
      glPathParameterfNV del = (glPathParameterfNV)GetProc<glPathParameterfNV>();
      del(path, pname, value);
    }

    public static void PathParameterfvNV(uint path, uint pname, ref float[] value)
    {
      glPathParameterfvNV del = (glPathParameterfvNV)GetProc<glPathParameterfvNV>();
      del(path, pname, ref value);
    }

    public static void PathParameteriNV(uint path, uint pname, int value)
    {
      glPathParameteriNV del = (glPathParameteriNV)GetProc<glPathParameteriNV>();
      del(path, pname, value);
    }

    public static void PathParameterivNV(uint path, uint pname, ref int[] value)
    {
      glPathParameterivNV del = (glPathParameterivNV)GetProc<glPathParameterivNV>();
      del(path, pname, ref value);
    }

    public static void PathStencilDepthOffsetNV(float factor, float units)
    {
      glPathStencilDepthOffsetNV del = (glPathStencilDepthOffsetNV)GetProc<glPathStencilDepthOffsetNV>();
      del(factor, units);
    }

    public static void PathStencilFuncNV(uint func, int reference, uint mask)
    {
      glPathStencilFuncNV del = (glPathStencilFuncNV)GetProc<glPathStencilFuncNV>();
      del(func, reference, mask);
    }

    public static void PathStringNV(uint path, uint format, int length, IntPtr pathString)
    {
      glPathStringNV del = (glPathStringNV)GetProc<glPathStringNV>();
      del(path, format, length, pathString);
    }

    public static void PathSubCommandsNV(uint path, int commandStart, int commandsToDelete, int numCommands, ref byte[] commands, int numCoords, uint coordType, IntPtr coords)
    {
      glPathSubCommandsNV del = (glPathSubCommandsNV)GetProc<glPathSubCommandsNV>();
      del(path, commandStart, commandsToDelete, numCommands, ref commands, numCoords, coordType, coords);
    }

    public static void PathSubCoordsNV(uint path, int coordStart, int numCoords, uint coordType, IntPtr coords)
    {
      glPathSubCoordsNV del = (glPathSubCoordsNV)GetProc<glPathSubCoordsNV>();
      del(path, coordStart, numCoords, coordType, coords);
    }

    public static void PathTexGenNV(uint texCoordSet, uint genMode, int components, ref float[] coeffs)
    {
      glPathTexGenNV del = (glPathTexGenNV)GetProc<glPathTexGenNV>();
      del(texCoordSet, genMode, components, ref coeffs);
    }

    public static void PauseTransformFeedback()
    {
      glPauseTransformFeedback del = (glPauseTransformFeedback)GetProc<glPauseTransformFeedback>();
      del();
    }

    public static void PauseTransformFeedbackNV()
    {
      glPauseTransformFeedbackNV del = (glPauseTransformFeedbackNV)GetProc<glPauseTransformFeedbackNV>();
      del();
    }

    public static void PixelDataRangeNV(uint target, int length, IntPtr pointer)
    {
      glPixelDataRangeNV del = (glPixelDataRangeNV)GetProc<glPixelDataRangeNV>();
      del(target, length, pointer);
    }

    public static void PixelMapx(uint map, int size, ref int[] values)
    {
      glPixelMapx del = (glPixelMapx)GetProc<glPixelMapx>();
      del(map, size, ref values);
    }

    public static void PixelStorex(uint pname, int param)
    {
      glPixelStorex del = (glPixelStorex)GetProc<glPixelStorex>();
      del(pname, param);
    }

    public static void PixelTexGenParameterfSGIS(uint pname, float param)
    {
      glPixelTexGenParameterfSGIS del = (glPixelTexGenParameterfSGIS)GetProc<glPixelTexGenParameterfSGIS>();
      del(pname, param);
    }

    public static void PixelTexGenParameterfvSGIS(uint pname, ref float[] parameters)
    {
      glPixelTexGenParameterfvSGIS del = (glPixelTexGenParameterfvSGIS)GetProc<glPixelTexGenParameterfvSGIS>();
      del(pname, ref parameters);
    }

    public static void PixelTexGenParameteriSGIS(uint pname, int param)
    {
      glPixelTexGenParameteriSGIS del = (glPixelTexGenParameteriSGIS)GetProc<glPixelTexGenParameteriSGIS>();
      del(pname, param);
    }

    public static void PixelTexGenParameterivSGIS(uint pname, ref int[] parameters)
    {
      glPixelTexGenParameterivSGIS del = (glPixelTexGenParameterivSGIS)GetProc<glPixelTexGenParameterivSGIS>();
      del(pname, ref parameters);
    }

    public static void PixelTexGenSGIX(uint mode)
    {
      glPixelTexGenSGIX del = (glPixelTexGenSGIX)GetProc<glPixelTexGenSGIX>();
      del(mode);
    }

    public static void PixelTransferxOES(uint pname, int param)
    {
      glPixelTransferxOES del = (glPixelTransferxOES)GetProc<glPixelTransferxOES>();
      del(pname, param);
    }

    public static void PixelTransformParameterfEXT(uint target, uint pname, float param)
    {
      glPixelTransformParameterfEXT del = (glPixelTransformParameterfEXT)GetProc<glPixelTransformParameterfEXT>();
      del(target, pname, param);
    }

    public static void PixelTransformParameterfvEXT(uint target, uint pname, ref float[] parameters)
    {
      glPixelTransformParameterfvEXT del = (glPixelTransformParameterfvEXT)GetProc<glPixelTransformParameterfvEXT>();
      del(target, pname, ref parameters);
    }

    public static void PixelTransformParameteriEXT(uint target, uint pname, int param)
    {
      glPixelTransformParameteriEXT del = (glPixelTransformParameteriEXT)GetProc<glPixelTransformParameteriEXT>();
      del(target, pname, param);
    }

    public static void PixelTransformParameterivEXT(uint target, uint pname, ref int[] parameters)
    {
      glPixelTransformParameterivEXT del = (glPixelTransformParameterivEXT)GetProc<glPixelTransformParameterivEXT>();
      del(target, pname, ref parameters);
    }

    public static void PixelZoomxOES(int xfactor, int yfactor)
    {
      glPixelZoomxOES del = (glPixelZoomxOES)GetProc<glPixelZoomxOES>();
      del(xfactor, yfactor);
    }

    public static void PNTrianglesfATI(uint pname, float param)
    {
      glPNTrianglesfATI del = (glPNTrianglesfATI)GetProc<glPNTrianglesfATI>();
      del(pname, param);
    }

    public static void PNTrianglesiATI(uint pname, int param)
    {
      glPNTrianglesiATI del = (glPNTrianglesiATI)GetProc<glPNTrianglesiATI>();
      del(pname, param);
    }

    public static void PointParameterf(uint pname, float param)
    {
      glPointParameterf del = (glPointParameterf)GetProc<glPointParameterf>();
      del(pname, param);
    }

    public static void PointParameterfARB(uint pname, float param)
    {
      glPointParameterfARB del = (glPointParameterfARB)GetProc<glPointParameterfARB>();
      del(pname, param);
    }

    public static void PointParameterfEXT(uint pname, float param)
    {
      glPointParameterfEXT del = (glPointParameterfEXT)GetProc<glPointParameterfEXT>();
      del(pname, param);
    }

    public static void PointParameterfSGIS(uint pname, float param)
    {
      glPointParameterfSGIS del = (glPointParameterfSGIS)GetProc<glPointParameterfSGIS>();
      del(pname, param);
    }

    public static void PointParameterfv(uint pname, ref float[] parameters)
    {
      glPointParameterfv del = (glPointParameterfv)GetProc<glPointParameterfv>();
      del(pname, ref parameters);
    }

    public static void PointParameterfvARB(uint pname, ref float[] parameters)
    {
      glPointParameterfvARB del = (glPointParameterfvARB)GetProc<glPointParameterfvARB>();
      del(pname, ref parameters);
    }

    public static void PointParameterfvEXT(uint pname, ref float[] parameters)
    {
      glPointParameterfvEXT del = (glPointParameterfvEXT)GetProc<glPointParameterfvEXT>();
      del(pname, ref parameters);
    }

    public static void PointParameterfvSGIS(uint pname, ref float[] parameters)
    {
      glPointParameterfvSGIS del = (glPointParameterfvSGIS)GetProc<glPointParameterfvSGIS>();
      del(pname, ref parameters);
    }

    public static void PointParameteri(uint pname, int param)
    {
      glPointParameteri del = (glPointParameteri)GetProc<glPointParameteri>();
      del(pname, param);
    }

    public static void PointParameteriNV(uint pname, int param)
    {
      glPointParameteriNV del = (glPointParameteriNV)GetProc<glPointParameteriNV>();
      del(pname, param);
    }

    public static void PointParameteriv(uint pname, ref int[] parameters)
    {
      glPointParameteriv del = (glPointParameteriv)GetProc<glPointParameteriv>();
      del(pname, ref parameters);
    }

    public static void PointParameterivNV(uint pname, ref int[] parameters)
    {
      glPointParameterivNV del = (glPointParameterivNV)GetProc<glPointParameterivNV>();
      del(pname, ref parameters);
    }

    public static void PointParameterxvOES(uint pname, ref int[] parameters)
    {
      glPointParameterxvOES del = (glPointParameterxvOES)GetProc<glPointParameterxvOES>();
      del(pname, ref parameters);
    }

    public static void PointSizexOES(int size)
    {
      glPointSizexOES del = (glPointSizexOES)GetProc<glPointSizexOES>();
      del(size);
    }

    public static void PolygonOffsetEXT(float factor, float bias)
    {
      glPolygonOffsetEXT del = (glPolygonOffsetEXT)GetProc<glPolygonOffsetEXT>();
      del(factor, bias);
    }

    public static void PolygonOffsetxOES(int factor, int units)
    {
      glPolygonOffsetxOES del = (glPolygonOffsetxOES)GetProc<glPolygonOffsetxOES>();
      del(factor, units);
    }

    public static void PopDebugGroup()
    {
      glPopDebugGroup del = (glPopDebugGroup)GetProc<glPopDebugGroup>();
      del();
    }

    public static void PresentFrameDualFillNV(uint video_slot, ulong minPresentTime, uint beginPresentTimeId, uint presentDurationId, uint type, uint target0, uint fill0, uint target1, uint fill1, uint target2, uint fill2, uint target3, uint fill3)
    {
      glPresentFrameDualFillNV del = (glPresentFrameDualFillNV)GetProc<glPresentFrameDualFillNV>();
      del(video_slot, minPresentTime, beginPresentTimeId, presentDurationId, type, target0, fill0, target1, fill1, target2, fill2, target3, fill3);
    }

    public static void PresentFrameKeyedNV(uint video_slot, ulong minPresentTime, uint beginPresentTimeId, uint presentDurationId, uint type, uint target0, uint fill0, uint key0, uint target1, uint fill1, uint key1)
    {
      glPresentFrameKeyedNV del = (glPresentFrameKeyedNV)GetProc<glPresentFrameKeyedNV>();
      del(video_slot, minPresentTime, beginPresentTimeId, presentDurationId, type, target0, fill0, key0, target1, fill1, key1);
    }

    public static void PrimitiveRestartIndex(uint index)
    {
      glPrimitiveRestartIndex del = (glPrimitiveRestartIndex)GetProc<glPrimitiveRestartIndex>();
      del(index);
    }

    public static void PrimitiveRestartIndexNV(uint index)
    {
      glPrimitiveRestartIndexNV del = (glPrimitiveRestartIndexNV)GetProc<glPrimitiveRestartIndexNV>();
      del(index);
    }

    public static void PrimitiveRestartNV()
    {
      glPrimitiveRestartNV del = (glPrimitiveRestartNV)GetProc<glPrimitiveRestartNV>();
      del();
    }

    public static void PrioritizeTexturesEXT(int n, ref uint[] textures, ref float[] priorities)
    {
      glPrioritizeTexturesEXT del = (glPrioritizeTexturesEXT)GetProc<glPrioritizeTexturesEXT>();
      del(n, ref textures, ref priorities);
    }

    public static void PrioritizeTexturesxOES(int n, ref uint[] textures, ref int[] priorities)
    {
      glPrioritizeTexturesxOES del = (glPrioritizeTexturesxOES)GetProc<glPrioritizeTexturesxOES>();
      del(n, ref textures, ref priorities);
    }

    public static void ProgramBinary(uint program, uint binaryFormat, IntPtr binary, int length)
    {
      glProgramBinary del = (glProgramBinary)GetProc<glProgramBinary>();
      del(program, binaryFormat, binary, length);
    }

    public static void ProgramBufferParametersfvNV(uint target, uint bindingIndex, uint wordIndex, int count, ref float[] parameters)
    {
      glProgramBufferParametersfvNV del = (glProgramBufferParametersfvNV)GetProc<glProgramBufferParametersfvNV>();
      del(target, bindingIndex, wordIndex, count, ref parameters);
    }

    public static void ProgramBufferParametersIivNV(uint target, uint bindingIndex, uint wordIndex, int count, ref int[] parameters)
    {
      glProgramBufferParametersIivNV del = (glProgramBufferParametersIivNV)GetProc<glProgramBufferParametersIivNV>();
      del(target, bindingIndex, wordIndex, count, ref parameters);
    }

    public static void ProgramBufferParametersIuivNV(uint target, uint bindingIndex, uint wordIndex, int count, ref uint[] parameters)
    {
      glProgramBufferParametersIuivNV del = (glProgramBufferParametersIuivNV)GetProc<glProgramBufferParametersIuivNV>();
      del(target, bindingIndex, wordIndex, count, ref parameters);
    }

    public static void ProgramEnvParameter4dARB(uint target, uint index, double x, double y, double z, double w)
    {
      glProgramEnvParameter4dARB del = (glProgramEnvParameter4dARB)GetProc<glProgramEnvParameter4dARB>();
      del(target, index, x, y, z, w);
    }

    public static void ProgramEnvParameter4dvARB(uint target, uint index, ref double[] parameters)
    {
      glProgramEnvParameter4dvARB del = (glProgramEnvParameter4dvARB)GetProc<glProgramEnvParameter4dvARB>();
      del(target, index, ref parameters);
    }

    public static void ProgramEnvParameter4fARB(uint target, uint index, float x, float y, float z, float w)
    {
      glProgramEnvParameter4fARB del = (glProgramEnvParameter4fARB)GetProc<glProgramEnvParameter4fARB>();
      del(target, index, x, y, z, w);
    }

    public static void ProgramEnvParameter4fvARB(uint target, uint index, ref float[] parameters)
    {
      glProgramEnvParameter4fvARB del = (glProgramEnvParameter4fvARB)GetProc<glProgramEnvParameter4fvARB>();
      del(target, index, ref parameters);
    }

    public static void ProgramEnvParameterI4iNV(uint target, uint index, int x, int y, int z, int w)
    {
      glProgramEnvParameterI4iNV del = (glProgramEnvParameterI4iNV)GetProc<glProgramEnvParameterI4iNV>();
      del(target, index, x, y, z, w);
    }

    public static void ProgramEnvParameterI4ivNV(uint target, uint index, ref int[] parameters)
    {
      glProgramEnvParameterI4ivNV del = (glProgramEnvParameterI4ivNV)GetProc<glProgramEnvParameterI4ivNV>();
      del(target, index, ref parameters);
    }

    public static void ProgramEnvParameterI4uiNV(uint target, uint index, uint x, uint y, uint z, uint w)
    {
      glProgramEnvParameterI4uiNV del = (glProgramEnvParameterI4uiNV)GetProc<glProgramEnvParameterI4uiNV>();
      del(target, index, x, y, z, w);
    }

    public static void ProgramEnvParameterI4uivNV(uint target, uint index, ref uint[] parameters)
    {
      glProgramEnvParameterI4uivNV del = (glProgramEnvParameterI4uivNV)GetProc<glProgramEnvParameterI4uivNV>();
      del(target, index, ref parameters);
    }

    public static void ProgramEnvParameters4fvEXT(uint target, uint index, int count, ref float[] parameters)
    {
      glProgramEnvParameters4fvEXT del = (glProgramEnvParameters4fvEXT)GetProc<glProgramEnvParameters4fvEXT>();
      del(target, index, count, ref parameters);
    }

    public static void ProgramEnvParametersI4ivNV(uint target, uint index, int count, ref int[] parameters)
    {
      glProgramEnvParametersI4ivNV del = (glProgramEnvParametersI4ivNV)GetProc<glProgramEnvParametersI4ivNV>();
      del(target, index, count, ref parameters);
    }

    public static void ProgramEnvParametersI4uivNV(uint target, uint index, int count, ref uint[] parameters)
    {
      glProgramEnvParametersI4uivNV del = (glProgramEnvParametersI4uivNV)GetProc<glProgramEnvParametersI4uivNV>();
      del(target, index, count, ref parameters);
    }

    public static void ProgramLocalParameter4dARB(uint target, uint index, double x, double y, double z, double w)
    {
      glProgramLocalParameter4dARB del = (glProgramLocalParameter4dARB)GetProc<glProgramLocalParameter4dARB>();
      del(target, index, x, y, z, w);
    }

    public static void ProgramLocalParameter4dvARB(uint target, uint index, ref double[] parameters)
    {
      glProgramLocalParameter4dvARB del = (glProgramLocalParameter4dvARB)GetProc<glProgramLocalParameter4dvARB>();
      del(target, index, ref parameters);
    }

    public static void ProgramLocalParameter4fARB(uint target, uint index, float x, float y, float z, float w)
    {
      glProgramLocalParameter4fARB del = (glProgramLocalParameter4fARB)GetProc<glProgramLocalParameter4fARB>();
      del(target, index, x, y, z, w);
    }

    public static void ProgramLocalParameter4fvARB(uint target, uint index, ref float[] parameters)
    {
      glProgramLocalParameter4fvARB del = (glProgramLocalParameter4fvARB)GetProc<glProgramLocalParameter4fvARB>();
      del(target, index, ref parameters);
    }

    public static void ProgramLocalParameterI4iNV(uint target, uint index, int x, int y, int z, int w)
    {
      glProgramLocalParameterI4iNV del = (glProgramLocalParameterI4iNV)GetProc<glProgramLocalParameterI4iNV>();
      del(target, index, x, y, z, w);
    }

    public static void ProgramLocalParameterI4ivNV(uint target, uint index, ref int[] parameters)
    {
      glProgramLocalParameterI4ivNV del = (glProgramLocalParameterI4ivNV)GetProc<glProgramLocalParameterI4ivNV>();
      del(target, index, ref parameters);
    }

    public static void ProgramLocalParameterI4uiNV(uint target, uint index, uint x, uint y, uint z, uint w)
    {
      glProgramLocalParameterI4uiNV del = (glProgramLocalParameterI4uiNV)GetProc<glProgramLocalParameterI4uiNV>();
      del(target, index, x, y, z, w);
    }

    public static void ProgramLocalParameterI4uivNV(uint target, uint index, ref uint[] parameters)
    {
      glProgramLocalParameterI4uivNV del = (glProgramLocalParameterI4uivNV)GetProc<glProgramLocalParameterI4uivNV>();
      del(target, index, ref parameters);
    }

    public static void ProgramLocalParameters4fvEXT(uint target, uint index, int count, ref float[] parameters)
    {
      glProgramLocalParameters4fvEXT del = (glProgramLocalParameters4fvEXT)GetProc<glProgramLocalParameters4fvEXT>();
      del(target, index, count, ref parameters);
    }

    public static void ProgramLocalParametersI4ivNV(uint target, uint index, int count, ref int[] parameters)
    {
      glProgramLocalParametersI4ivNV del = (glProgramLocalParametersI4ivNV)GetProc<glProgramLocalParametersI4ivNV>();
      del(target, index, count, ref parameters);
    }

    public static void ProgramLocalParametersI4uivNV(uint target, uint index, int count, ref uint[] parameters)
    {
      glProgramLocalParametersI4uivNV del = (glProgramLocalParametersI4uivNV)GetProc<glProgramLocalParametersI4uivNV>();
      del(target, index, count, ref parameters);
    }

    public static void ProgramNamedParameter4dNV(uint id, int len, ref byte[] name, double x, double y, double z, double w)
    {
      glProgramNamedParameter4dNV del = (glProgramNamedParameter4dNV)GetProc<glProgramNamedParameter4dNV>();
      del(id, len, ref name, x, y, z, w);
    }

    public static void ProgramNamedParameter4dvNV(uint id, int len, ref byte[] name, ref double[] v)
    {
      glProgramNamedParameter4dvNV del = (glProgramNamedParameter4dvNV)GetProc<glProgramNamedParameter4dvNV>();
      del(id, len, ref name, ref v);
    }

    public static void ProgramNamedParameter4fNV(uint id, int len, ref byte[] name, float x, float y, float z, float w)
    {
      glProgramNamedParameter4fNV del = (glProgramNamedParameter4fNV)GetProc<glProgramNamedParameter4fNV>();
      del(id, len, ref name, x, y, z, w);
    }

    public static void ProgramNamedParameter4fvNV(uint id, int len, ref byte[] name, ref float[] v)
    {
      glProgramNamedParameter4fvNV del = (glProgramNamedParameter4fvNV)GetProc<glProgramNamedParameter4fvNV>();
      del(id, len, ref name, ref v);
    }

    public static void ProgramParameter4dNV(uint target, uint index, double x, double y, double z, double w)
    {
      glProgramParameter4dNV del = (glProgramParameter4dNV)GetProc<glProgramParameter4dNV>();
      del(target, index, x, y, z, w);
    }

    public static void ProgramParameter4dvNV(uint target, uint index, ref double[] v)
    {
      glProgramParameter4dvNV del = (glProgramParameter4dvNV)GetProc<glProgramParameter4dvNV>();
      del(target, index, ref v);
    }

    public static void ProgramParameter4fNV(uint target, uint index, float x, float y, float z, float w)
    {
      glProgramParameter4fNV del = (glProgramParameter4fNV)GetProc<glProgramParameter4fNV>();
      del(target, index, x, y, z, w);
    }

    public static void ProgramParameter4fvNV(uint target, uint index, ref float[] v)
    {
      glProgramParameter4fvNV del = (glProgramParameter4fvNV)GetProc<glProgramParameter4fvNV>();
      del(target, index, ref v);
    }

    public static void ProgramParameteri(uint program, uint pname, int value)
    {
      glProgramParameteri del = (glProgramParameteri)GetProc<glProgramParameteri>();
      del(program, pname, value);
    }

    public static void ProgramParameteriARB(uint program, uint pname, int value)
    {
      glProgramParameteriARB del = (glProgramParameteriARB)GetProc<glProgramParameteriARB>();
      del(program, pname, value);
    }

    public static void ProgramParameteriEXT(uint program, uint pname, int value)
    {
      glProgramParameteriEXT del = (glProgramParameteriEXT)GetProc<glProgramParameteriEXT>();
      del(program, pname, value);
    }

    public static void ProgramParameters4dvNV(uint target, uint index, int count, ref double[] v)
    {
      glProgramParameters4dvNV del = (glProgramParameters4dvNV)GetProc<glProgramParameters4dvNV>();
      del(target, index, count, ref v);
    }

    public static void ProgramParameters4fvNV(uint target, uint index, int count, ref float[] v)
    {
      glProgramParameters4fvNV del = (glProgramParameters4fvNV)GetProc<glProgramParameters4fvNV>();
      del(target, index, count, ref v);
    }

    public static void ProgramStringARB(uint target, uint format, int len, IntPtr str)
    {
      glProgramStringARB del = (glProgramStringARB)GetProc<glProgramStringARB>();
      del(target, format, len, str);
    }

    public static void ProgramSubroutineParametersuivNV(uint target, int count, ref uint[] parameters)
    {
      glProgramSubroutineParametersuivNV del = (glProgramSubroutineParametersuivNV)GetProc<glProgramSubroutineParametersuivNV>();
      del(target, count, ref parameters);
    }

    public static void ProgramUniform1d(uint program, int location, double v0)
    {
      glProgramUniform1d del = (glProgramUniform1d)GetProc<glProgramUniform1d>();
      del(program, location, v0);
    }

    public static void ProgramUniform1dEXT(uint program, int location, double x)
    {
      glProgramUniform1dEXT del = (glProgramUniform1dEXT)GetProc<glProgramUniform1dEXT>();
      del(program, location, x);
    }

    public static void ProgramUniform1dv(uint program, int location, int count, ref double[] value)
    {
      glProgramUniform1dv del = (glProgramUniform1dv)GetProc<glProgramUniform1dv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform1dvEXT(uint program, int location, int count, ref double[] value)
    {
      glProgramUniform1dvEXT del = (glProgramUniform1dvEXT)GetProc<glProgramUniform1dvEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform1f(uint program, int location, float v0)
    {
      glProgramUniform1f del = (glProgramUniform1f)GetProc<glProgramUniform1f>();
      del(program, location, v0);
    }

    public static void ProgramUniform1fEXT(uint program, int location, float v0)
    {
      glProgramUniform1fEXT del = (glProgramUniform1fEXT)GetProc<glProgramUniform1fEXT>();
      del(program, location, v0);
    }

    public static void ProgramUniform1fv(uint program, int location, int count, ref float[] value)
    {
      glProgramUniform1fv del = (glProgramUniform1fv)GetProc<glProgramUniform1fv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform1fvEXT(uint program, int location, int count, ref float[] value)
    {
      glProgramUniform1fvEXT del = (glProgramUniform1fvEXT)GetProc<glProgramUniform1fvEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform1i(uint program, int location, int v0)
    {
      glProgramUniform1i del = (glProgramUniform1i)GetProc<glProgramUniform1i>();
      del(program, location, v0);
    }

    public static void ProgramUniform1i64NV(uint program, int location, long x)
    {
      glProgramUniform1i64NV del = (glProgramUniform1i64NV)GetProc<glProgramUniform1i64NV>();
      del(program, location, x);
    }

    public static void ProgramUniform1i64vNV(uint program, int location, int count, ref long[] value)
    {
      glProgramUniform1i64vNV del = (glProgramUniform1i64vNV)GetProc<glProgramUniform1i64vNV>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform1iEXT(uint program, int location, int v0)
    {
      glProgramUniform1iEXT del = (glProgramUniform1iEXT)GetProc<glProgramUniform1iEXT>();
      del(program, location, v0);
    }

    public static void ProgramUniform1iv(uint program, int location, int count, ref int[] value)
    {
      glProgramUniform1iv del = (glProgramUniform1iv)GetProc<glProgramUniform1iv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform1ivEXT(uint program, int location, int count, ref int[] value)
    {
      glProgramUniform1ivEXT del = (glProgramUniform1ivEXT)GetProc<glProgramUniform1ivEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform1ui(uint program, int location, uint v0)
    {
      glProgramUniform1ui del = (glProgramUniform1ui)GetProc<glProgramUniform1ui>();
      del(program, location, v0);
    }

    public static void ProgramUniform1ui64NV(uint program, int location, ulong x)
    {
      glProgramUniform1ui64NV del = (glProgramUniform1ui64NV)GetProc<glProgramUniform1ui64NV>();
      del(program, location, x);
    }

    public static void ProgramUniform1ui64vNV(uint program, int location, int count, ref ulong[] value)
    {
      glProgramUniform1ui64vNV del = (glProgramUniform1ui64vNV)GetProc<glProgramUniform1ui64vNV>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform1uiEXT(uint program, int location, uint v0)
    {
      glProgramUniform1uiEXT del = (glProgramUniform1uiEXT)GetProc<glProgramUniform1uiEXT>();
      del(program, location, v0);
    }

    public static void ProgramUniform1uiv(uint program, int location, int count, ref uint[] value)
    {
      glProgramUniform1uiv del = (glProgramUniform1uiv)GetProc<glProgramUniform1uiv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform1uivEXT(uint program, int location, int count, ref uint[] value)
    {
      glProgramUniform1uivEXT del = (glProgramUniform1uivEXT)GetProc<glProgramUniform1uivEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform2d(uint program, int location, double v0, double v1)
    {
      glProgramUniform2d del = (glProgramUniform2d)GetProc<glProgramUniform2d>();
      del(program, location, v0, v1);
    }

    public static void ProgramUniform2dEXT(uint program, int location, double x, double y)
    {
      glProgramUniform2dEXT del = (glProgramUniform2dEXT)GetProc<glProgramUniform2dEXT>();
      del(program, location, x, y);
    }

    public static void ProgramUniform2dv(uint program, int location, int count, ref double[] value)
    {
      glProgramUniform2dv del = (glProgramUniform2dv)GetProc<glProgramUniform2dv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform2dvEXT(uint program, int location, int count, ref double[] value)
    {
      glProgramUniform2dvEXT del = (glProgramUniform2dvEXT)GetProc<glProgramUniform2dvEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform2f(uint program, int location, float v0, float v1)
    {
      glProgramUniform2f del = (glProgramUniform2f)GetProc<glProgramUniform2f>();
      del(program, location, v0, v1);
    }

    public static void ProgramUniform2fEXT(uint program, int location, float v0, float v1)
    {
      glProgramUniform2fEXT del = (glProgramUniform2fEXT)GetProc<glProgramUniform2fEXT>();
      del(program, location, v0, v1);
    }

    public static void ProgramUniform2fv(uint program, int location, int count, ref float[] value)
    {
      glProgramUniform2fv del = (glProgramUniform2fv)GetProc<glProgramUniform2fv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform2fvEXT(uint program, int location, int count, ref float[] value)
    {
      glProgramUniform2fvEXT del = (glProgramUniform2fvEXT)GetProc<glProgramUniform2fvEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform2i(uint program, int location, int v0, int v1)
    {
      glProgramUniform2i del = (glProgramUniform2i)GetProc<glProgramUniform2i>();
      del(program, location, v0, v1);
    }

    public static void ProgramUniform2i64NV(uint program, int location, long x, long y)
    {
      glProgramUniform2i64NV del = (glProgramUniform2i64NV)GetProc<glProgramUniform2i64NV>();
      del(program, location, x, y);
    }

    public static void ProgramUniform2i64vNV(uint program, int location, int count, ref long[] value)
    {
      glProgramUniform2i64vNV del = (glProgramUniform2i64vNV)GetProc<glProgramUniform2i64vNV>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform2iEXT(uint program, int location, int v0, int v1)
    {
      glProgramUniform2iEXT del = (glProgramUniform2iEXT)GetProc<glProgramUniform2iEXT>();
      del(program, location, v0, v1);
    }

    public static void ProgramUniform2iv(uint program, int location, int count, ref int[] value)
    {
      glProgramUniform2iv del = (glProgramUniform2iv)GetProc<glProgramUniform2iv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform2ivEXT(uint program, int location, int count, ref int[] value)
    {
      glProgramUniform2ivEXT del = (glProgramUniform2ivEXT)GetProc<glProgramUniform2ivEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform2ui(uint program, int location, uint v0, uint v1)
    {
      glProgramUniform2ui del = (glProgramUniform2ui)GetProc<glProgramUniform2ui>();
      del(program, location, v0, v1);
    }

    public static void ProgramUniform2ui64NV(uint program, int location, ulong x, ulong y)
    {
      glProgramUniform2ui64NV del = (glProgramUniform2ui64NV)GetProc<glProgramUniform2ui64NV>();
      del(program, location, x, y);
    }

    public static void ProgramUniform2ui64vNV(uint program, int location, int count, ref ulong[] value)
    {
      glProgramUniform2ui64vNV del = (glProgramUniform2ui64vNV)GetProc<glProgramUniform2ui64vNV>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform2uiEXT(uint program, int location, uint v0, uint v1)
    {
      glProgramUniform2uiEXT del = (glProgramUniform2uiEXT)GetProc<glProgramUniform2uiEXT>();
      del(program, location, v0, v1);
    }

    public static void ProgramUniform2uiv(uint program, int location, int count, ref uint[] value)
    {
      glProgramUniform2uiv del = (glProgramUniform2uiv)GetProc<glProgramUniform2uiv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform2uivEXT(uint program, int location, int count, ref uint[] value)
    {
      glProgramUniform2uivEXT del = (glProgramUniform2uivEXT)GetProc<glProgramUniform2uivEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform3d(uint program, int location, double v0, double v1, double v2)
    {
      glProgramUniform3d del = (glProgramUniform3d)GetProc<glProgramUniform3d>();
      del(program, location, v0, v1, v2);
    }

    public static void ProgramUniform3dEXT(uint program, int location, double x, double y, double z)
    {
      glProgramUniform3dEXT del = (glProgramUniform3dEXT)GetProc<glProgramUniform3dEXT>();
      del(program, location, x, y, z);
    }

    public static void ProgramUniform3dv(uint program, int location, int count, ref double[] value)
    {
      glProgramUniform3dv del = (glProgramUniform3dv)GetProc<glProgramUniform3dv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform3dvEXT(uint program, int location, int count, ref double[] value)
    {
      glProgramUniform3dvEXT del = (glProgramUniform3dvEXT)GetProc<glProgramUniform3dvEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform3f(uint program, int location, float v0, float v1, float v2)
    {
      glProgramUniform3f del = (glProgramUniform3f)GetProc<glProgramUniform3f>();
      del(program, location, v0, v1, v2);
    }

    public static void ProgramUniform3fEXT(uint program, int location, float v0, float v1, float v2)
    {
      glProgramUniform3fEXT del = (glProgramUniform3fEXT)GetProc<glProgramUniform3fEXT>();
      del(program, location, v0, v1, v2);
    }

    public static void ProgramUniform3fv(uint program, int location, int count, ref float[] value)
    {
      glProgramUniform3fv del = (glProgramUniform3fv)GetProc<glProgramUniform3fv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform3fvEXT(uint program, int location, int count, ref float[] value)
    {
      glProgramUniform3fvEXT del = (glProgramUniform3fvEXT)GetProc<glProgramUniform3fvEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform3i(uint program, int location, int v0, int v1, int v2)
    {
      glProgramUniform3i del = (glProgramUniform3i)GetProc<glProgramUniform3i>();
      del(program, location, v0, v1, v2);
    }

    public static void ProgramUniform3i64NV(uint program, int location, long x, long y, long z)
    {
      glProgramUniform3i64NV del = (glProgramUniform3i64NV)GetProc<glProgramUniform3i64NV>();
      del(program, location, x, y, z);
    }

    public static void ProgramUniform3i64vNV(uint program, int location, int count, ref long[] value)
    {
      glProgramUniform3i64vNV del = (glProgramUniform3i64vNV)GetProc<glProgramUniform3i64vNV>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform3iEXT(uint program, int location, int v0, int v1, int v2)
    {
      glProgramUniform3iEXT del = (glProgramUniform3iEXT)GetProc<glProgramUniform3iEXT>();
      del(program, location, v0, v1, v2);
    }

    public static void ProgramUniform3iv(uint program, int location, int count, ref int[] value)
    {
      glProgramUniform3iv del = (glProgramUniform3iv)GetProc<glProgramUniform3iv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform3ivEXT(uint program, int location, int count, ref int[] value)
    {
      glProgramUniform3ivEXT del = (glProgramUniform3ivEXT)GetProc<glProgramUniform3ivEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform3ui(uint program, int location, uint v0, uint v1, uint v2)
    {
      glProgramUniform3ui del = (glProgramUniform3ui)GetProc<glProgramUniform3ui>();
      del(program, location, v0, v1, v2);
    }

    public static void ProgramUniform3ui64NV(uint program, int location, ulong x, ulong y, ulong z)
    {
      glProgramUniform3ui64NV del = (glProgramUniform3ui64NV)GetProc<glProgramUniform3ui64NV>();
      del(program, location, x, y, z);
    }

    public static void ProgramUniform3ui64vNV(uint program, int location, int count, ref ulong[] value)
    {
      glProgramUniform3ui64vNV del = (glProgramUniform3ui64vNV)GetProc<glProgramUniform3ui64vNV>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform3uiEXT(uint program, int location, uint v0, uint v1, uint v2)
    {
      glProgramUniform3uiEXT del = (glProgramUniform3uiEXT)GetProc<glProgramUniform3uiEXT>();
      del(program, location, v0, v1, v2);
    }

    public static void ProgramUniform3uiv(uint program, int location, int count, ref uint[] value)
    {
      glProgramUniform3uiv del = (glProgramUniform3uiv)GetProc<glProgramUniform3uiv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform3uivEXT(uint program, int location, int count, ref uint[] value)
    {
      glProgramUniform3uivEXT del = (glProgramUniform3uivEXT)GetProc<glProgramUniform3uivEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform4d(uint program, int location, double v0, double v1, double v2, double v3)
    {
      glProgramUniform4d del = (glProgramUniform4d)GetProc<glProgramUniform4d>();
      del(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform4dEXT(uint program, int location, double x, double y, double z, double w)
    {
      glProgramUniform4dEXT del = (glProgramUniform4dEXT)GetProc<glProgramUniform4dEXT>();
      del(program, location, x, y, z, w);
    }

    public static void ProgramUniform4dv(uint program, int location, int count, ref double[] value)
    {
      glProgramUniform4dv del = (glProgramUniform4dv)GetProc<glProgramUniform4dv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform4dvEXT(uint program, int location, int count, ref double[] value)
    {
      glProgramUniform4dvEXT del = (glProgramUniform4dvEXT)GetProc<glProgramUniform4dvEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform4f(uint program, int location, float v0, float v1, float v2, float v3)
    {
      glProgramUniform4f del = (glProgramUniform4f)GetProc<glProgramUniform4f>();
      del(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform4fEXT(uint program, int location, float v0, float v1, float v2, float v3)
    {
      glProgramUniform4fEXT del = (glProgramUniform4fEXT)GetProc<glProgramUniform4fEXT>();
      del(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform4fv(uint program, int location, int count, ref float[] value)
    {
      glProgramUniform4fv del = (glProgramUniform4fv)GetProc<glProgramUniform4fv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform4fvEXT(uint program, int location, int count, ref float[] value)
    {
      glProgramUniform4fvEXT del = (glProgramUniform4fvEXT)GetProc<glProgramUniform4fvEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform4i(uint program, int location, int v0, int v1, int v2, int v3)
    {
      glProgramUniform4i del = (glProgramUniform4i)GetProc<glProgramUniform4i>();
      del(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform4i64NV(uint program, int location, long x, long y, long z, long w)
    {
      glProgramUniform4i64NV del = (glProgramUniform4i64NV)GetProc<glProgramUniform4i64NV>();
      del(program, location, x, y, z, w);
    }

    public static void ProgramUniform4i64vNV(uint program, int location, int count, ref long[] value)
    {
      glProgramUniform4i64vNV del = (glProgramUniform4i64vNV)GetProc<glProgramUniform4i64vNV>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform4iEXT(uint program, int location, int v0, int v1, int v2, int v3)
    {
      glProgramUniform4iEXT del = (glProgramUniform4iEXT)GetProc<glProgramUniform4iEXT>();
      del(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform4iv(uint program, int location, int count, ref int[] value)
    {
      glProgramUniform4iv del = (glProgramUniform4iv)GetProc<glProgramUniform4iv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform4ivEXT(uint program, int location, int count, ref int[] value)
    {
      glProgramUniform4ivEXT del = (glProgramUniform4ivEXT)GetProc<glProgramUniform4ivEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform4ui(uint program, int location, uint v0, uint v1, uint v2, uint v3)
    {
      glProgramUniform4ui del = (glProgramUniform4ui)GetProc<glProgramUniform4ui>();
      del(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform4ui64NV(uint program, int location, ulong x, ulong y, ulong z, ulong w)
    {
      glProgramUniform4ui64NV del = (glProgramUniform4ui64NV)GetProc<glProgramUniform4ui64NV>();
      del(program, location, x, y, z, w);
    }

    public static void ProgramUniform4ui64vNV(uint program, int location, int count, ref ulong[] value)
    {
      glProgramUniform4ui64vNV del = (glProgramUniform4ui64vNV)GetProc<glProgramUniform4ui64vNV>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform4uiEXT(uint program, int location, uint v0, uint v1, uint v2, uint v3)
    {
      glProgramUniform4uiEXT del = (glProgramUniform4uiEXT)GetProc<glProgramUniform4uiEXT>();
      del(program, location, v0, v1, v2, v3);
    }

    public static void ProgramUniform4uiv(uint program, int location, int count, ref uint[] value)
    {
      glProgramUniform4uiv del = (glProgramUniform4uiv)GetProc<glProgramUniform4uiv>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniform4uivEXT(uint program, int location, int count, ref uint[] value)
    {
      glProgramUniform4uivEXT del = (glProgramUniform4uivEXT)GetProc<glProgramUniform4uivEXT>();
      del(program, location, count, ref value);
    }

    public static void ProgramUniformHandleui64ARB(uint program, int location, ulong value)
    {
      glProgramUniformHandleui64ARB del = (glProgramUniformHandleui64ARB)GetProc<glProgramUniformHandleui64ARB>();
      del(program, location, value);
    }

    public static void ProgramUniformHandleui64NV(uint program, int location, ulong value)
    {
      glProgramUniformHandleui64NV del = (glProgramUniformHandleui64NV)GetProc<glProgramUniformHandleui64NV>();
      del(program, location, value);
    }

    public static void ProgramUniformHandleui64vARB(uint program, int location, int count, ref ulong[] values)
    {
      glProgramUniformHandleui64vARB del = (glProgramUniformHandleui64vARB)GetProc<glProgramUniformHandleui64vARB>();
      del(program, location, count, ref values);
    }

    public static void ProgramUniformHandleui64vNV(uint program, int location, int count, ref ulong[] values)
    {
      glProgramUniformHandleui64vNV del = (glProgramUniformHandleui64vNV)GetProc<glProgramUniformHandleui64vNV>();
      del(program, location, count, ref values);
    }

    public static void ProgramUniformMatrix2dv(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix2dv del = (glProgramUniformMatrix2dv)GetProc<glProgramUniformMatrix2dv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix2dvEXT(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix2dvEXT del = (glProgramUniformMatrix2dvEXT)GetProc<glProgramUniformMatrix2dvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix2fv(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix2fv del = (glProgramUniformMatrix2fv)GetProc<glProgramUniformMatrix2fv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix2fvEXT(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix2fvEXT del = (glProgramUniformMatrix2fvEXT)GetProc<glProgramUniformMatrix2fvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix2x3dv(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix2x3dv del = (glProgramUniformMatrix2x3dv)GetProc<glProgramUniformMatrix2x3dv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix2x3dvEXT(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix2x3dvEXT del = (glProgramUniformMatrix2x3dvEXT)GetProc<glProgramUniformMatrix2x3dvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix2x3fv(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix2x3fv del = (glProgramUniformMatrix2x3fv)GetProc<glProgramUniformMatrix2x3fv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix2x3fvEXT(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix2x3fvEXT del = (glProgramUniformMatrix2x3fvEXT)GetProc<glProgramUniformMatrix2x3fvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix2x4dv(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix2x4dv del = (glProgramUniformMatrix2x4dv)GetProc<glProgramUniformMatrix2x4dv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix2x4dvEXT(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix2x4dvEXT del = (glProgramUniformMatrix2x4dvEXT)GetProc<glProgramUniformMatrix2x4dvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix2x4fv(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix2x4fv del = (glProgramUniformMatrix2x4fv)GetProc<glProgramUniformMatrix2x4fv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix2x4fvEXT(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix2x4fvEXT del = (glProgramUniformMatrix2x4fvEXT)GetProc<glProgramUniformMatrix2x4fvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3dv(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix3dv del = (glProgramUniformMatrix3dv)GetProc<glProgramUniformMatrix3dv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3dvEXT(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix3dvEXT del = (glProgramUniformMatrix3dvEXT)GetProc<glProgramUniformMatrix3dvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3fv(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix3fv del = (glProgramUniformMatrix3fv)GetProc<glProgramUniformMatrix3fv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3fvEXT(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix3fvEXT del = (glProgramUniformMatrix3fvEXT)GetProc<glProgramUniformMatrix3fvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3x2dv(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix3x2dv del = (glProgramUniformMatrix3x2dv)GetProc<glProgramUniformMatrix3x2dv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3x2dvEXT(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix3x2dvEXT del = (glProgramUniformMatrix3x2dvEXT)GetProc<glProgramUniformMatrix3x2dvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3x2fv(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix3x2fv del = (glProgramUniformMatrix3x2fv)GetProc<glProgramUniformMatrix3x2fv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3x2fvEXT(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix3x2fvEXT del = (glProgramUniformMatrix3x2fvEXT)GetProc<glProgramUniformMatrix3x2fvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3x4dv(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix3x4dv del = (glProgramUniformMatrix3x4dv)GetProc<glProgramUniformMatrix3x4dv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3x4dvEXT(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix3x4dvEXT del = (glProgramUniformMatrix3x4dvEXT)GetProc<glProgramUniformMatrix3x4dvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3x4fv(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix3x4fv del = (glProgramUniformMatrix3x4fv)GetProc<glProgramUniformMatrix3x4fv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix3x4fvEXT(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix3x4fvEXT del = (glProgramUniformMatrix3x4fvEXT)GetProc<glProgramUniformMatrix3x4fvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4dv(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix4dv del = (glProgramUniformMatrix4dv)GetProc<glProgramUniformMatrix4dv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4dvEXT(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix4dvEXT del = (glProgramUniformMatrix4dvEXT)GetProc<glProgramUniformMatrix4dvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4fv(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix4fv del = (glProgramUniformMatrix4fv)GetProc<glProgramUniformMatrix4fv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4fvEXT(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix4fvEXT del = (glProgramUniformMatrix4fvEXT)GetProc<glProgramUniformMatrix4fvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4x2dv(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix4x2dv del = (glProgramUniformMatrix4x2dv)GetProc<glProgramUniformMatrix4x2dv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4x2dvEXT(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix4x2dvEXT del = (glProgramUniformMatrix4x2dvEXT)GetProc<glProgramUniformMatrix4x2dvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4x2fv(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix4x2fv del = (glProgramUniformMatrix4x2fv)GetProc<glProgramUniformMatrix4x2fv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4x2fvEXT(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix4x2fvEXT del = (glProgramUniformMatrix4x2fvEXT)GetProc<glProgramUniformMatrix4x2fvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4x3dv(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix4x3dv del = (glProgramUniformMatrix4x3dv)GetProc<glProgramUniformMatrix4x3dv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4x3dvEXT(uint program, int location, int count, bool transpose, ref double[] value)
    {
      glProgramUniformMatrix4x3dvEXT del = (glProgramUniformMatrix4x3dvEXT)GetProc<glProgramUniformMatrix4x3dvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4x3fv(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix4x3fv del = (glProgramUniformMatrix4x3fv)GetProc<glProgramUniformMatrix4x3fv>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformMatrix4x3fvEXT(uint program, int location, int count, bool transpose, ref float[] value)
    {
      glProgramUniformMatrix4x3fvEXT del = (glProgramUniformMatrix4x3fvEXT)GetProc<glProgramUniformMatrix4x3fvEXT>();
      del(program, location, count, transpose, ref value);
    }

    public static void ProgramUniformui64NV(uint program, int location, ulong value)
    {
      glProgramUniformui64NV del = (glProgramUniformui64NV)GetProc<glProgramUniformui64NV>();
      del(program, location, value);
    }

    public static void ProgramUniformui64vNV(uint program, int location, int count, ref ulong[] value)
    {
      glProgramUniformui64vNV del = (glProgramUniformui64vNV)GetProc<glProgramUniformui64vNV>();
      del(program, location, count, ref value);
    }

    public static void ProgramVertexLimitNV(uint target, int limit)
    {
      glProgramVertexLimitNV del = (glProgramVertexLimitNV)GetProc<glProgramVertexLimitNV>();
      del(target, limit);
    }

    public static void ProvokingVertex(uint mode)
    {
      glProvokingVertex del = (glProvokingVertex)GetProc<glProvokingVertex>();
      del(mode);
    }

    public static void ProvokingVertexEXT(uint mode)
    {
      glProvokingVertexEXT del = (glProvokingVertexEXT)GetProc<glProvokingVertexEXT>();
      del(mode);
    }

    public static void PushClientAttribDefaultEXT(uint mask)
    {
      glPushClientAttribDefaultEXT del = (glPushClientAttribDefaultEXT)GetProc<glPushClientAttribDefaultEXT>();
      del(mask);
    }

    public static void PushDebugGroup(uint source, uint id, int length, ref sbyte[] message)
    {
      glPushDebugGroup del = (glPushDebugGroup)GetProc<glPushDebugGroup>();
      del(source, id, length, ref message);
    }

    public static void QueryCounter(uint id, uint target)
    {
      glQueryCounter del = (glQueryCounter)GetProc<glQueryCounter>();
      del(id, target);
    }

    public static void RasterPos2xOES(int x, int y)
    {
      glRasterPos2xOES del = (glRasterPos2xOES)GetProc<glRasterPos2xOES>();
      del(x, y);
    }

    public static void RasterPos2xvOES(ref int[] coords)
    {
      glRasterPos2xvOES del = (glRasterPos2xvOES)GetProc<glRasterPos2xvOES>();
      del(ref coords);
    }

    public static void RasterPos3xOES(int x, int y, int z)
    {
      glRasterPos3xOES del = (glRasterPos3xOES)GetProc<glRasterPos3xOES>();
      del(x, y, z);
    }

    public static void RasterPos3xvOES(ref int[] coords)
    {
      glRasterPos3xvOES del = (glRasterPos3xvOES)GetProc<glRasterPos3xvOES>();
      del(ref coords);
    }

    public static void RasterPos4xOES(int x, int y, int z, int w)
    {
      glRasterPos4xOES del = (glRasterPos4xOES)GetProc<glRasterPos4xOES>();
      del(x, y, z, w);
    }

    public static void RasterPos4xvOES(ref int[] coords)
    {
      glRasterPos4xvOES del = (glRasterPos4xvOES)GetProc<glRasterPos4xvOES>();
      del(ref coords);
    }

    public static void ReadInstrumentsSGIX(int marker)
    {
      glReadInstrumentsSGIX del = (glReadInstrumentsSGIX)GetProc<glReadInstrumentsSGIX>();
      del(marker);
    }

    public static void ReadnPixelsARB(int x, int y, int width, int height, uint format, uint type, int bufSize, IntPtr data)
    {
      glReadnPixelsARB del = (glReadnPixelsARB)GetProc<glReadnPixelsARB>();
      del(x, y, width, height, format, type, bufSize, data);
    }

    public static void RectxOES(int x1, int y1, int x2, int y2)
    {
      glRectxOES del = (glRectxOES)GetProc<glRectxOES>();
      del(x1, y1, x2, y2);
    }

    public static void RectxvOES(ref int[] v1, ref int[] v2)
    {
      glRectxvOES del = (glRectxvOES)GetProc<glRectxvOES>();
      del(ref v1, ref v2);
    }

    public static void ReferencePlaneSGIX(ref double[] equation)
    {
      glReferencePlaneSGIX del = (glReferencePlaneSGIX)GetProc<glReferencePlaneSGIX>();
      del(ref equation);
    }

    public static void ReleaseShaderCompiler()
    {
      glReleaseShaderCompiler del = (glReleaseShaderCompiler)GetProc<glReleaseShaderCompiler>();
      del();
    }

    public static void RenderbufferStorage(uint target, uint internalformat, int width, int height)
    {
      glRenderbufferStorage del = (glRenderbufferStorage)GetProc<glRenderbufferStorage>();
      del(target, internalformat, width, height);
    }

    public static void RenderbufferStorageEXT(uint target, uint internalformat, int width, int height)
    {
      glRenderbufferStorageEXT del = (glRenderbufferStorageEXT)GetProc<glRenderbufferStorageEXT>();
      del(target, internalformat, width, height);
    }

    public static void RenderbufferStorageMultisample(uint target, int samples, uint internalformat, int width, int height)
    {
      glRenderbufferStorageMultisample del = (glRenderbufferStorageMultisample)GetProc<glRenderbufferStorageMultisample>();
      del(target, samples, internalformat, width, height);
    }

    public static void RenderbufferStorageMultisampleCoverageNV(uint target, int coverageSamples, int colorSamples, uint internalformat, int width, int height)
    {
      glRenderbufferStorageMultisampleCoverageNV del = (glRenderbufferStorageMultisampleCoverageNV)GetProc<glRenderbufferStorageMultisampleCoverageNV>();
      del(target, coverageSamples, colorSamples, internalformat, width, height);
    }

    public static void RenderbufferStorageMultisampleEXT(uint target, int samples, uint internalformat, int width, int height)
    {
      glRenderbufferStorageMultisampleEXT del = (glRenderbufferStorageMultisampleEXT)GetProc<glRenderbufferStorageMultisampleEXT>();
      del(target, samples, internalformat, width, height);
    }

    public static void ReplacementCodePointerSUN(uint type, int stride, IntPtr pointer)
    {
      glReplacementCodePointerSUN del = (glReplacementCodePointerSUN)GetProc<glReplacementCodePointerSUN>();
      del(type, stride, pointer);
    }

    public static void ReplacementCodeubSUN(byte code)
    {
      glReplacementCodeubSUN del = (glReplacementCodeubSUN)GetProc<glReplacementCodeubSUN>();
      del(code);
    }

    public static void ReplacementCodeubvSUN(ref byte[] code)
    {
      glReplacementCodeubvSUN del = (glReplacementCodeubvSUN)GetProc<glReplacementCodeubvSUN>();
      del(ref code);
    }

    public static void ReplacementCodeuiColor3fVertex3fSUN(uint rc, float r, float g, float b, float x, float y, float z)
    {
      glReplacementCodeuiColor3fVertex3fSUN del = (glReplacementCodeuiColor3fVertex3fSUN)GetProc<glReplacementCodeuiColor3fVertex3fSUN>();
      del(rc, r, g, b, x, y, z);
    }

    public static void ReplacementCodeuiColor3fVertex3fvSUN(ref uint[] rc, ref float[] c, ref float[] v)
    {
      glReplacementCodeuiColor3fVertex3fvSUN del = (glReplacementCodeuiColor3fVertex3fvSUN)GetProc<glReplacementCodeuiColor3fVertex3fvSUN>();
      del(ref rc, ref c, ref v);
    }

    public static void ReplacementCodeuiColor4fNormal3fVertex3fSUN(uint rc, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z)
    {
      glReplacementCodeuiColor4fNormal3fVertex3fSUN del = (glReplacementCodeuiColor4fNormal3fVertex3fSUN)GetProc<glReplacementCodeuiColor4fNormal3fVertex3fSUN>();
      del(rc, r, g, b, a, nx, ny, nz, x, y, z);
    }

    public static void ReplacementCodeuiColor4fNormal3fVertex3fvSUN(ref uint[] rc, ref float[] c, ref float[] n, ref float[] v)
    {
      glReplacementCodeuiColor4fNormal3fVertex3fvSUN del = (glReplacementCodeuiColor4fNormal3fVertex3fvSUN)GetProc<glReplacementCodeuiColor4fNormal3fVertex3fvSUN>();
      del(ref rc, ref c, ref n, ref v);
    }

    public static void ReplacementCodeuiColor4ubVertex3fSUN(uint rc, byte r, byte g, byte b, byte a, float x, float y, float z)
    {
      glReplacementCodeuiColor4ubVertex3fSUN del = (glReplacementCodeuiColor4ubVertex3fSUN)GetProc<glReplacementCodeuiColor4ubVertex3fSUN>();
      del(rc, r, g, b, a, x, y, z);
    }

    public static void ReplacementCodeuiColor4ubVertex3fvSUN(ref uint[] rc, ref byte[] c, ref float[] v)
    {
      glReplacementCodeuiColor4ubVertex3fvSUN del = (glReplacementCodeuiColor4ubVertex3fvSUN)GetProc<glReplacementCodeuiColor4ubVertex3fvSUN>();
      del(ref rc, ref c, ref v);
    }

    public static void ReplacementCodeuiNormal3fVertex3fSUN(uint rc, float nx, float ny, float nz, float x, float y, float z)
    {
      glReplacementCodeuiNormal3fVertex3fSUN del = (glReplacementCodeuiNormal3fVertex3fSUN)GetProc<glReplacementCodeuiNormal3fVertex3fSUN>();
      del(rc, nx, ny, nz, x, y, z);
    }

    public static void ReplacementCodeuiNormal3fVertex3fvSUN(ref uint[] rc, ref float[] n, ref float[] v)
    {
      glReplacementCodeuiNormal3fVertex3fvSUN del = (glReplacementCodeuiNormal3fVertex3fvSUN)GetProc<glReplacementCodeuiNormal3fVertex3fvSUN>();
      del(ref rc, ref n, ref v);
    }

    public static void ReplacementCodeuiSUN(uint code)
    {
      glReplacementCodeuiSUN del = (glReplacementCodeuiSUN)GetProc<glReplacementCodeuiSUN>();
      del(code);
    }

    public static void ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN(uint rc, float s, float t, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z)
    {
      glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN del = (glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN)GetProc<glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fSUN>();
      del(rc, s, t, r, g, b, a, nx, ny, nz, x, y, z);
    }

    public static void ReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN(ref uint[] rc, ref float[] tc, ref float[] c, ref float[] n, ref float[] v)
    {
      glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN del = (glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN)GetProc<glReplacementCodeuiTexCoord2fColor4fNormal3fVertex3fvSUN>();
      del(ref rc, ref tc, ref c, ref n, ref v);
    }

    public static void ReplacementCodeuiTexCoord2fNormal3fVertex3fSUN(uint rc, float s, float t, float nx, float ny, float nz, float x, float y, float z)
    {
      glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN del = (glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN)GetProc<glReplacementCodeuiTexCoord2fNormal3fVertex3fSUN>();
      del(rc, s, t, nx, ny, nz, x, y, z);
    }

    public static void ReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN(ref uint[] rc, ref float[] tc, ref float[] n, ref float[] v)
    {
      glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN del = (glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN)GetProc<glReplacementCodeuiTexCoord2fNormal3fVertex3fvSUN>();
      del(ref rc, ref tc, ref n, ref v);
    }

    public static void ReplacementCodeuiTexCoord2fVertex3fSUN(uint rc, float s, float t, float x, float y, float z)
    {
      glReplacementCodeuiTexCoord2fVertex3fSUN del = (glReplacementCodeuiTexCoord2fVertex3fSUN)GetProc<glReplacementCodeuiTexCoord2fVertex3fSUN>();
      del(rc, s, t, x, y, z);
    }

    public static void ReplacementCodeuiTexCoord2fVertex3fvSUN(ref uint[] rc, ref float[] tc, ref float[] v)
    {
      glReplacementCodeuiTexCoord2fVertex3fvSUN del = (glReplacementCodeuiTexCoord2fVertex3fvSUN)GetProc<glReplacementCodeuiTexCoord2fVertex3fvSUN>();
      del(ref rc, ref tc, ref v);
    }

    public static void ReplacementCodeuiVertex3fSUN(uint rc, float x, float y, float z)
    {
      glReplacementCodeuiVertex3fSUN del = (glReplacementCodeuiVertex3fSUN)GetProc<glReplacementCodeuiVertex3fSUN>();
      del(rc, x, y, z);
    }

    public static void ReplacementCodeuiVertex3fvSUN(ref uint[] rc, ref float[] v)
    {
      glReplacementCodeuiVertex3fvSUN del = (glReplacementCodeuiVertex3fvSUN)GetProc<glReplacementCodeuiVertex3fvSUN>();
      del(ref rc, ref v);
    }

    public static void ReplacementCodeuivSUN(ref uint[] code)
    {
      glReplacementCodeuivSUN del = (glReplacementCodeuivSUN)GetProc<glReplacementCodeuivSUN>();
      del(ref code);
    }

    public static void ReplacementCodeusSUN(ushort code)
    {
      glReplacementCodeusSUN del = (glReplacementCodeusSUN)GetProc<glReplacementCodeusSUN>();
      del(code);
    }

    public static void ReplacementCodeusvSUN(ref ushort[] code)
    {
      glReplacementCodeusvSUN del = (glReplacementCodeusvSUN)GetProc<glReplacementCodeusvSUN>();
      del(ref code);
    }

    public static void RequestResidentProgramsNV(int n, ref uint[] programs)
    {
      glRequestResidentProgramsNV del = (glRequestResidentProgramsNV)GetProc<glRequestResidentProgramsNV>();
      del(n, ref programs);
    }

    public static void ResetHistogram(uint target)
    {
      glResetHistogram del = (glResetHistogram)GetProc<glResetHistogram>();
      del(target);
    }

    public static void ResetHistogramEXT(uint target)
    {
      glResetHistogramEXT del = (glResetHistogramEXT)GetProc<glResetHistogramEXT>();
      del(target);
    }

    public static void ResetMinmax(uint target)
    {
      glResetMinmax del = (glResetMinmax)GetProc<glResetMinmax>();
      del(target);
    }

    public static void ResetMinmaxEXT(uint target)
    {
      glResetMinmaxEXT del = (glResetMinmaxEXT)GetProc<glResetMinmaxEXT>();
      del(target);
    }

    public static void ResizeBuffersMESA()
    {
      glResizeBuffersMESA del = (glResizeBuffersMESA)GetProc<glResizeBuffersMESA>();
      del();
    }

    public static void ResumeTransformFeedback()
    {
      glResumeTransformFeedback del = (glResumeTransformFeedback)GetProc<glResumeTransformFeedback>();
      del();
    }

    public static void ResumeTransformFeedbackNV()
    {
      glResumeTransformFeedbackNV del = (glResumeTransformFeedbackNV)GetProc<glResumeTransformFeedbackNV>();
      del();
    }

    public static void RotatexOES(int angle, int x, int y, int z)
    {
      glRotatexOES del = (glRotatexOES)GetProc<glRotatexOES>();
      del(angle, x, y, z);
    }

    public static void SampleCoverage(float value, bool invert)
    {
      glSampleCoverage del = (glSampleCoverage)GetProc<glSampleCoverage>();
      del(value, invert);
    }

    public static void SampleCoverageARB(float value, bool invert)
    {
      glSampleCoverageARB del = (glSampleCoverageARB)GetProc<glSampleCoverageARB>();
      del(value, invert);
    }

    public static void SampleCoverageOES(int value, bool invert)
    {
      glSampleCoverageOES del = (glSampleCoverageOES)GetProc<glSampleCoverageOES>();
      del(value, invert);
    }

    public static void SampleMapATI(uint dst, uint interp, uint swizzle)
    {
      glSampleMapATI del = (glSampleMapATI)GetProc<glSampleMapATI>();
      del(dst, interp, swizzle);
    }

    public static void SampleMaskEXT(float value, bool invert)
    {
      glSampleMaskEXT del = (glSampleMaskEXT)GetProc<glSampleMaskEXT>();
      del(value, invert);
    }

    public static void SampleMaski(uint index, uint mask)
    {
      glSampleMaski del = (glSampleMaski)GetProc<glSampleMaski>();
      del(index, mask);
    }

    public static void SampleMaskIndexedNV(uint index, uint mask)
    {
      glSampleMaskIndexedNV del = (glSampleMaskIndexedNV)GetProc<glSampleMaskIndexedNV>();
      del(index, mask);
    }

    public static void SampleMaskSGIS(float value, bool invert)
    {
      glSampleMaskSGIS del = (glSampleMaskSGIS)GetProc<glSampleMaskSGIS>();
      del(value, invert);
    }

    public static void SamplePatternEXT(uint pattern)
    {
      glSamplePatternEXT del = (glSamplePatternEXT)GetProc<glSamplePatternEXT>();
      del(pattern);
    }

    public static void SamplePatternSGIS(uint pattern)
    {
      glSamplePatternSGIS del = (glSamplePatternSGIS)GetProc<glSamplePatternSGIS>();
      del(pattern);
    }

    public static void SamplerParameterf(uint sampler, uint pname, float param)
    {
      glSamplerParameterf del = (glSamplerParameterf)GetProc<glSamplerParameterf>();
      del(sampler, pname, param);
    }

    public static void SamplerParameterfv(uint sampler, uint pname, ref float[] param)
    {
      glSamplerParameterfv del = (glSamplerParameterfv)GetProc<glSamplerParameterfv>();
      del(sampler, pname, ref param);
    }

    public static void SamplerParameteri(uint sampler, uint pname, int param)
    {
      glSamplerParameteri del = (glSamplerParameteri)GetProc<glSamplerParameteri>();
      del(sampler, pname, param);
    }

    public static void SamplerParameterIiv(uint sampler, uint pname, ref int[] param)
    {
      glSamplerParameterIiv del = (glSamplerParameterIiv)GetProc<glSamplerParameterIiv>();
      del(sampler, pname, ref param);
    }

    public static void SamplerParameterIuiv(uint sampler, uint pname, ref uint[] param)
    {
      glSamplerParameterIuiv del = (glSamplerParameterIuiv)GetProc<glSamplerParameterIuiv>();
      del(sampler, pname, ref param);
    }

    public static void SamplerParameteriv(uint sampler, uint pname, ref int[] param)
    {
      glSamplerParameteriv del = (glSamplerParameteriv)GetProc<glSamplerParameteriv>();
      del(sampler, pname, ref param);
    }

    public static void ScalexOES(int x, int y, int z)
    {
      glScalexOES del = (glScalexOES)GetProc<glScalexOES>();
      del(x, y, z);
    }

    public static void ScissorArrayv(uint first, int count, ref int[] v)
    {
      glScissorArrayv del = (glScissorArrayv)GetProc<glScissorArrayv>();
      del(first, count, ref v);
    }

    public static void ScissorIndexed(uint index, int left, int bottom, int width, int height)
    {
      glScissorIndexed del = (glScissorIndexed)GetProc<glScissorIndexed>();
      del(index, left, bottom, width, height);
    }

    public static void ScissorIndexedv(uint index, ref int[] v)
    {
      glScissorIndexedv del = (glScissorIndexedv)GetProc<glScissorIndexedv>();
      del(index, ref v);
    }

    public static void SecondaryColor3b(sbyte red, sbyte green, sbyte blue)
    {
      glSecondaryColor3b del = (glSecondaryColor3b)GetProc<glSecondaryColor3b>();
      del(red, green, blue);
    }

    public static void SecondaryColor3bEXT(sbyte red, sbyte green, sbyte blue)
    {
      glSecondaryColor3bEXT del = (glSecondaryColor3bEXT)GetProc<glSecondaryColor3bEXT>();
      del(red, green, blue);
    }

    public static void SecondaryColor3bv(ref sbyte[] v)
    {
      glSecondaryColor3bv del = (glSecondaryColor3bv)GetProc<glSecondaryColor3bv>();
      del(ref v);
    }

    public static void SecondaryColor3bvEXT(ref sbyte[] v)
    {
      glSecondaryColor3bvEXT del = (glSecondaryColor3bvEXT)GetProc<glSecondaryColor3bvEXT>();
      del(ref v);
    }

    public static void SecondaryColor3d(double red, double green, double blue)
    {
      glSecondaryColor3d del = (glSecondaryColor3d)GetProc<glSecondaryColor3d>();
      del(red, green, blue);
    }

    public static void SecondaryColor3dEXT(double red, double green, double blue)
    {
      glSecondaryColor3dEXT del = (glSecondaryColor3dEXT)GetProc<glSecondaryColor3dEXT>();
      del(red, green, blue);
    }

    public static void SecondaryColor3dv(ref double[] v)
    {
      glSecondaryColor3dv del = (glSecondaryColor3dv)GetProc<glSecondaryColor3dv>();
      del(ref v);
    }

    public static void SecondaryColor3dvEXT(ref double[] v)
    {
      glSecondaryColor3dvEXT del = (glSecondaryColor3dvEXT)GetProc<glSecondaryColor3dvEXT>();
      del(ref v);
    }

    public static void SecondaryColor3f(float red, float green, float blue)
    {
      glSecondaryColor3f del = (glSecondaryColor3f)GetProc<glSecondaryColor3f>();
      del(red, green, blue);
    }

    public static void SecondaryColor3fEXT(float red, float green, float blue)
    {
      glSecondaryColor3fEXT del = (glSecondaryColor3fEXT)GetProc<glSecondaryColor3fEXT>();
      del(red, green, blue);
    }

    public static void SecondaryColor3fv(ref float[] v)
    {
      glSecondaryColor3fv del = (glSecondaryColor3fv)GetProc<glSecondaryColor3fv>();
      del(ref v);
    }

    public static void SecondaryColor3fvEXT(ref float[] v)
    {
      glSecondaryColor3fvEXT del = (glSecondaryColor3fvEXT)GetProc<glSecondaryColor3fvEXT>();
      del(ref v);
    }

    public static void SecondaryColor3hNV(ushort red, ushort green, ushort blue)
    {
      glSecondaryColor3hNV del = (glSecondaryColor3hNV)GetProc<glSecondaryColor3hNV>();
      del(red, green, blue);
    }

    public static void SecondaryColor3hvNV(ref ushort[] v)
    {
      glSecondaryColor3hvNV del = (glSecondaryColor3hvNV)GetProc<glSecondaryColor3hvNV>();
      del(ref v);
    }

    public static void SecondaryColor3i(int red, int green, int blue)
    {
      glSecondaryColor3i del = (glSecondaryColor3i)GetProc<glSecondaryColor3i>();
      del(red, green, blue);
    }

    public static void SecondaryColor3iEXT(int red, int green, int blue)
    {
      glSecondaryColor3iEXT del = (glSecondaryColor3iEXT)GetProc<glSecondaryColor3iEXT>();
      del(red, green, blue);
    }

    public static void SecondaryColor3iv(ref int[] v)
    {
      glSecondaryColor3iv del = (glSecondaryColor3iv)GetProc<glSecondaryColor3iv>();
      del(ref v);
    }

    public static void SecondaryColor3ivEXT(ref int[] v)
    {
      glSecondaryColor3ivEXT del = (glSecondaryColor3ivEXT)GetProc<glSecondaryColor3ivEXT>();
      del(ref v);
    }

    public static void SecondaryColor3s(short red, short green, short blue)
    {
      glSecondaryColor3s del = (glSecondaryColor3s)GetProc<glSecondaryColor3s>();
      del(red, green, blue);
    }

    public static void SecondaryColor3sEXT(short red, short green, short blue)
    {
      glSecondaryColor3sEXT del = (glSecondaryColor3sEXT)GetProc<glSecondaryColor3sEXT>();
      del(red, green, blue);
    }

    public static void SecondaryColor3sv(ref short[] v)
    {
      glSecondaryColor3sv del = (glSecondaryColor3sv)GetProc<glSecondaryColor3sv>();
      del(ref v);
    }

    public static void SecondaryColor3svEXT(ref short[] v)
    {
      glSecondaryColor3svEXT del = (glSecondaryColor3svEXT)GetProc<glSecondaryColor3svEXT>();
      del(ref v);
    }

    public static void SecondaryColor3ub(byte red, byte green, byte blue)
    {
      glSecondaryColor3ub del = (glSecondaryColor3ub)GetProc<glSecondaryColor3ub>();
      del(red, green, blue);
    }

    public static void SecondaryColor3ubEXT(byte red, byte green, byte blue)
    {
      glSecondaryColor3ubEXT del = (glSecondaryColor3ubEXT)GetProc<glSecondaryColor3ubEXT>();
      del(red, green, blue);
    }

    public static void SecondaryColor3ubv(ref byte[] v)
    {
      glSecondaryColor3ubv del = (glSecondaryColor3ubv)GetProc<glSecondaryColor3ubv>();
      del(ref v);
    }

    public static void SecondaryColor3ubvEXT(ref byte[] v)
    {
      glSecondaryColor3ubvEXT del = (glSecondaryColor3ubvEXT)GetProc<glSecondaryColor3ubvEXT>();
      del(ref v);
    }

    public static void SecondaryColor3ui(uint red, uint green, uint blue)
    {
      glSecondaryColor3ui del = (glSecondaryColor3ui)GetProc<glSecondaryColor3ui>();
      del(red, green, blue);
    }

    public static void SecondaryColor3uiEXT(uint red, uint green, uint blue)
    {
      glSecondaryColor3uiEXT del = (glSecondaryColor3uiEXT)GetProc<glSecondaryColor3uiEXT>();
      del(red, green, blue);
    }

    public static void SecondaryColor3uiv(ref uint[] v)
    {
      glSecondaryColor3uiv del = (glSecondaryColor3uiv)GetProc<glSecondaryColor3uiv>();
      del(ref v);
    }

    public static void SecondaryColor3uivEXT(ref uint[] v)
    {
      glSecondaryColor3uivEXT del = (glSecondaryColor3uivEXT)GetProc<glSecondaryColor3uivEXT>();
      del(ref v);
    }

    public static void SecondaryColor3us(ushort red, ushort green, ushort blue)
    {
      glSecondaryColor3us del = (glSecondaryColor3us)GetProc<glSecondaryColor3us>();
      del(red, green, blue);
    }

    public static void SecondaryColor3usEXT(ushort red, ushort green, ushort blue)
    {
      glSecondaryColor3usEXT del = (glSecondaryColor3usEXT)GetProc<glSecondaryColor3usEXT>();
      del(red, green, blue);
    }

    public static void SecondaryColor3usv(ref ushort[] v)
    {
      glSecondaryColor3usv del = (glSecondaryColor3usv)GetProc<glSecondaryColor3usv>();
      del(ref v);
    }

    public static void SecondaryColor3usvEXT(ref ushort[] v)
    {
      glSecondaryColor3usvEXT del = (glSecondaryColor3usvEXT)GetProc<glSecondaryColor3usvEXT>();
      del(ref v);
    }

    public static void SecondaryColorFormatNV(int size, uint type, int stride)
    {
      glSecondaryColorFormatNV del = (glSecondaryColorFormatNV)GetProc<glSecondaryColorFormatNV>();
      del(size, type, stride);
    }

    public static void SecondaryColorP3ui(uint type, uint color)
    {
      glSecondaryColorP3ui del = (glSecondaryColorP3ui)GetProc<glSecondaryColorP3ui>();
      del(type, color);
    }

    public static void SecondaryColorP3uiv(uint type, ref uint[] color)
    {
      glSecondaryColorP3uiv del = (glSecondaryColorP3uiv)GetProc<glSecondaryColorP3uiv>();
      del(type, ref color);
    }

    public static void SecondaryColorPointer(int size, uint type, int stride, IntPtr pointer)
    {
      glSecondaryColorPointer del = (glSecondaryColorPointer)GetProc<glSecondaryColorPointer>();
      del(size, type, stride, pointer);
    }

    public static void SecondaryColorPointerEXT(int size, uint type, int stride, IntPtr pointer)
    {
      glSecondaryColorPointerEXT del = (glSecondaryColorPointerEXT)GetProc<glSecondaryColorPointerEXT>();
      del(size, type, stride, pointer);
    }

    public static void SecondaryColorPointerListIBM(int size, uint type, int stride, IntPtr pointer, int ptrstride)
    {
      glSecondaryColorPointerListIBM del = (glSecondaryColorPointerListIBM)GetProc<glSecondaryColorPointerListIBM>();
      del(size, type, stride, pointer, ptrstride);
    }

    public static void SelectPerfMonitorCountersAMD(uint monitor, bool enable, uint group, int numCounters, ref uint[] counterList)
    {
      glSelectPerfMonitorCountersAMD del = (glSelectPerfMonitorCountersAMD)GetProc<glSelectPerfMonitorCountersAMD>();
      del(monitor, enable, group, numCounters, ref counterList);
    }

    public static void SeparableFilter2D(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr row, IntPtr column)
    {
      glSeparableFilter2D del = (glSeparableFilter2D)GetProc<glSeparableFilter2D>();
      del(target, internalformat, width, height, format, type, row, column);
    }

    public static void SeparableFilter2DEXT(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr row, IntPtr column)
    {
      glSeparableFilter2DEXT del = (glSeparableFilter2DEXT)GetProc<glSeparableFilter2DEXT>();
      del(target, internalformat, width, height, format, type, row, column);
    }

    public static void SetFenceAPPLE(uint fence)
    {
      glSetFenceAPPLE del = (glSetFenceAPPLE)GetProc<glSetFenceAPPLE>();
      del(fence);
    }

    public static void SetFenceNV(uint fence, uint condition)
    {
      glSetFenceNV del = (glSetFenceNV)GetProc<glSetFenceNV>();
      del(fence, condition);
    }

    public static void SetFragmentShaderConstantATI(uint dst, ref float[] value)
    {
      glSetFragmentShaderConstantATI del = (glSetFragmentShaderConstantATI)GetProc<glSetFragmentShaderConstantATI>();
      del(dst, ref value);
    }

    public static void SetInvariantEXT(uint id, uint type, IntPtr addr)
    {
      glSetInvariantEXT del = (glSetInvariantEXT)GetProc<glSetInvariantEXT>();
      del(id, type, addr);
    }

    public static void SetLocalConstantEXT(uint id, uint type, IntPtr addr)
    {
      glSetLocalConstantEXT del = (glSetLocalConstantEXT)GetProc<glSetLocalConstantEXT>();
      del(id, type, addr);
    }

    public static void SetMultisamplefvAMD(uint pname, uint index, ref float[] val)
    {
      glSetMultisamplefvAMD del = (glSetMultisamplefvAMD)GetProc<glSetMultisamplefvAMD>();
      del(pname, index, ref val);
    }

    public static void ShaderBinary(int count, ref uint[] shaders, uint binaryformat, IntPtr binary, int length)
    {
      glShaderBinary del = (glShaderBinary)GetProc<glShaderBinary>();
      del(count, ref shaders, binaryformat, binary, length);
    }

    public static void ShaderOp1EXT(uint op, uint res, uint arg1)
    {
      glShaderOp1EXT del = (glShaderOp1EXT)GetProc<glShaderOp1EXT>();
      del(op, res, arg1);
    }

    public static void ShaderOp2EXT(uint op, uint res, uint arg1, uint arg2)
    {
      glShaderOp2EXT del = (glShaderOp2EXT)GetProc<glShaderOp2EXT>();
      del(op, res, arg1, arg2);
    }

    public static void ShaderOp3EXT(uint op, uint res, uint arg1, uint arg2, uint arg3)
    {
      glShaderOp3EXT del = (glShaderOp3EXT)GetProc<glShaderOp3EXT>();
      del(op, res, arg1, arg2, arg3);
    }

    public static void ShaderSource(uint shader, int count, ref sbyte[] str, ref int[] length)
    {
      glShaderSource del = (glShaderSource)GetProc<glShaderSource>();
      del(shader, count, ref str, ref length);
    }

    public static void ShaderSourceARB(uint shaderObj, int count, IntPtr str, ref int[] length)
    {
      glShaderSourceARB del = (glShaderSourceARB)GetProc<glShaderSourceARB>();
      del(shaderObj, count, str, ref length);
    }

    public static void ShaderStorageBlockBinding(uint program, uint storageBlockIndex, uint storageBlockBinding)
    {
      glShaderStorageBlockBinding del = (glShaderStorageBlockBinding)GetProc<glShaderStorageBlockBinding>();
      del(program, storageBlockIndex, storageBlockBinding);
    }

    public static void SharpenTexFuncSGIS(uint target, int n, ref float[] points)
    {
      glSharpenTexFuncSGIS del = (glSharpenTexFuncSGIS)GetProc<glSharpenTexFuncSGIS>();
      del(target, n, ref points);
    }

    public static void SpriteParameterfSGIX(uint pname, float param)
    {
      glSpriteParameterfSGIX del = (glSpriteParameterfSGIX)GetProc<glSpriteParameterfSGIX>();
      del(pname, param);
    }

    public static void SpriteParameterfvSGIX(uint pname, ref float[] parameters)
    {
      glSpriteParameterfvSGIX del = (glSpriteParameterfvSGIX)GetProc<glSpriteParameterfvSGIX>();
      del(pname, ref parameters);
    }

    public static void SpriteParameteriSGIX(uint pname, int param)
    {
      glSpriteParameteriSGIX del = (glSpriteParameteriSGIX)GetProc<glSpriteParameteriSGIX>();
      del(pname, param);
    }

    public static void SpriteParameterivSGIX(uint pname, ref int[] parameters)
    {
      glSpriteParameterivSGIX del = (glSpriteParameterivSGIX)GetProc<glSpriteParameterivSGIX>();
      del(pname, ref parameters);
    }

    public static void StartInstrumentsSGIX()
    {
      glStartInstrumentsSGIX del = (glStartInstrumentsSGIX)GetProc<glStartInstrumentsSGIX>();
      del();
    }

    public static void StencilClearTagEXT(int stencilTagBits, uint stencilClearTag)
    {
      glStencilClearTagEXT del = (glStencilClearTagEXT)GetProc<glStencilClearTagEXT>();
      del(stencilTagBits, stencilClearTag);
    }

    public static void StencilFillPathInstancedNV(int numPaths, uint pathNameType, IntPtr paths, uint pathBase, uint fillMode, uint mask, uint transformType, ref float[] transformValues)
    {
      glStencilFillPathInstancedNV del = (glStencilFillPathInstancedNV)GetProc<glStencilFillPathInstancedNV>();
      del(numPaths, pathNameType, paths, pathBase, fillMode, mask, transformType, ref transformValues);
    }

    public static void StencilFillPathNV(uint path, uint fillMode, uint mask)
    {
      glStencilFillPathNV del = (glStencilFillPathNV)GetProc<glStencilFillPathNV>();
      del(path, fillMode, mask);
    }

    public static void StencilFuncSeparate(uint face, uint func, int reference, uint mask)
    {
      glStencilFuncSeparate del = (glStencilFuncSeparate)GetProc<glStencilFuncSeparate>();
      del(face, func, reference, mask);
    }

    public static void StencilFuncSeparateATI(uint frontfunc, uint backfunc, int reference, uint mask)
    {
      glStencilFuncSeparateATI del = (glStencilFuncSeparateATI)GetProc<glStencilFuncSeparateATI>();
      del(frontfunc, backfunc, reference, mask);
    }

    public static void StencilMaskSeparate(uint face, uint mask)
    {
      glStencilMaskSeparate del = (glStencilMaskSeparate)GetProc<glStencilMaskSeparate>();
      del(face, mask);
    }

    public static void StencilOpSeparate(uint face, uint sfail, uint dpfail, uint dppass)
    {
      glStencilOpSeparate del = (glStencilOpSeparate)GetProc<glStencilOpSeparate>();
      del(face, sfail, dpfail, dppass);
    }

    public static void StencilOpSeparateATI(uint face, uint sfail, uint dpfail, uint dppass)
    {
      glStencilOpSeparateATI del = (glStencilOpSeparateATI)GetProc<glStencilOpSeparateATI>();
      del(face, sfail, dpfail, dppass);
    }

    public static void StencilOpValueAMD(uint face, uint value)
    {
      glStencilOpValueAMD del = (glStencilOpValueAMD)GetProc<glStencilOpValueAMD>();
      del(face, value);
    }

    public static void StencilStrokePathInstancedNV(int numPaths, uint pathNameType, IntPtr paths, uint pathBase, int reference, uint mask, uint transformType, ref float[] transformValues)
    {
      glStencilStrokePathInstancedNV del = (glStencilStrokePathInstancedNV)GetProc<glStencilStrokePathInstancedNV>();
      del(numPaths, pathNameType, paths, pathBase, reference, mask, transformType, ref transformValues);
    }

    public static void StencilStrokePathNV(uint path, int reference, uint mask)
    {
      glStencilStrokePathNV del = (glStencilStrokePathNV)GetProc<glStencilStrokePathNV>();
      del(path, reference, mask);
    }

    public static void StopInstrumentsSGIX(int marker)
    {
      glStopInstrumentsSGIX del = (glStopInstrumentsSGIX)GetProc<glStopInstrumentsSGIX>();
      del(marker);
    }

    public static void StringMarkerGREMEDY(int len, IntPtr str)
    {
      glStringMarkerGREMEDY del = (glStringMarkerGREMEDY)GetProc<glStringMarkerGREMEDY>();
      del(len, str);
    }

    public static void SwizzleEXT(uint res, uint inp, uint outX, uint outY, uint outZ, uint outW)
    {
      glSwizzleEXT del = (glSwizzleEXT)GetProc<glSwizzleEXT>();
      del(res, inp, outX, outY, outZ, outW);
    }

    public static void SyncTextureINTEL(uint texture)
    {
      glSyncTextureINTEL del = (glSyncTextureINTEL)GetProc<glSyncTextureINTEL>();
      del(texture);
    }

    public static void TagSampleBufferSGIX()
    {
      glTagSampleBufferSGIX del = (glTagSampleBufferSGIX)GetProc<glTagSampleBufferSGIX>();
      del();
    }

    public static void Tangent3bEXT(sbyte tx, sbyte ty, sbyte tz)
    {
      glTangent3bEXT del = (glTangent3bEXT)GetProc<glTangent3bEXT>();
      del(tx, ty, tz);
    }

    public static void Tangent3bvEXT(ref sbyte[] v)
    {
      glTangent3bvEXT del = (glTangent3bvEXT)GetProc<glTangent3bvEXT>();
      del(ref v);
    }

    public static void Tangent3dEXT(double tx, double ty, double tz)
    {
      glTangent3dEXT del = (glTangent3dEXT)GetProc<glTangent3dEXT>();
      del(tx, ty, tz);
    }

    public static void Tangent3dvEXT(ref double[] v)
    {
      glTangent3dvEXT del = (glTangent3dvEXT)GetProc<glTangent3dvEXT>();
      del(ref v);
    }

    public static void Tangent3fEXT(float tx, float ty, float tz)
    {
      glTangent3fEXT del = (glTangent3fEXT)GetProc<glTangent3fEXT>();
      del(tx, ty, tz);
    }

    public static void Tangent3fvEXT(ref float[] v)
    {
      glTangent3fvEXT del = (glTangent3fvEXT)GetProc<glTangent3fvEXT>();
      del(ref v);
    }

    public static void Tangent3iEXT(int tx, int ty, int tz)
    {
      glTangent3iEXT del = (glTangent3iEXT)GetProc<glTangent3iEXT>();
      del(tx, ty, tz);
    }

    public static void Tangent3ivEXT(ref int[] v)
    {
      glTangent3ivEXT del = (glTangent3ivEXT)GetProc<glTangent3ivEXT>();
      del(ref v);
    }

    public static void Tangent3sEXT(short tx, short ty, short tz)
    {
      glTangent3sEXT del = (glTangent3sEXT)GetProc<glTangent3sEXT>();
      del(tx, ty, tz);
    }

    public static void Tangent3svEXT(ref short[] v)
    {
      glTangent3svEXT del = (glTangent3svEXT)GetProc<glTangent3svEXT>();
      del(ref v);
    }

    public static void TangentPointerEXT(uint type, int stride, IntPtr pointer)
    {
      glTangentPointerEXT del = (glTangentPointerEXT)GetProc<glTangentPointerEXT>();
      del(type, stride, pointer);
    }

    public static void TbufferMask3DFX(uint mask)
    {
      glTbufferMask3DFX del = (glTbufferMask3DFX)GetProc<glTbufferMask3DFX>();
      del(mask);
    }

    public static void TessellationFactorAMD(float factor)
    {
      glTessellationFactorAMD del = (glTessellationFactorAMD)GetProc<glTessellationFactorAMD>();
      del(factor);
    }

    public static void TessellationModeAMD(uint mode)
    {
      glTessellationModeAMD del = (glTessellationModeAMD)GetProc<glTessellationModeAMD>();
      del(mode);
    }

    public static void TexBuffer(uint target, uint internalformat, uint buffer)
    {
      glTexBuffer del = (glTexBuffer)GetProc<glTexBuffer>();
      del(target, internalformat, buffer);
    }

    public static void TexBufferARB(uint target, uint internalformat, uint buffer)
    {
      glTexBufferARB del = (glTexBufferARB)GetProc<glTexBufferARB>();
      del(target, internalformat, buffer);
    }

    public static void TexBufferEXT(uint target, uint internalformat, uint buffer)
    {
      glTexBufferEXT del = (glTexBufferEXT)GetProc<glTexBufferEXT>();
      del(target, internalformat, buffer);
    }

    public static void TexBufferRange(uint target, uint internalformat, uint buffer, IntPtr offset, IntPtr size)
    {
      glTexBufferRange del = (glTexBufferRange)GetProc<glTexBufferRange>();
      del(target, internalformat, buffer, offset, size);
    }

    public static void TexBumpParameterfvATI(uint pname, ref float[] param)
    {
      glTexBumpParameterfvATI del = (glTexBumpParameterfvATI)GetProc<glTexBumpParameterfvATI>();
      del(pname, ref param);
    }

    public static void TexBumpParameterivATI(uint pname, ref int[] param)
    {
      glTexBumpParameterivATI del = (glTexBumpParameterivATI)GetProc<glTexBumpParameterivATI>();
      del(pname, ref param);
    }

    public static void TexCoord1bOES(sbyte s)
    {
      glTexCoord1bOES del = (glTexCoord1bOES)GetProc<glTexCoord1bOES>();
      del(s);
    }

    public static void TexCoord1bvOES(ref sbyte[] coords)
    {
      glTexCoord1bvOES del = (glTexCoord1bvOES)GetProc<glTexCoord1bvOES>();
      del(ref coords);
    }

    public static void TexCoord1hNV(ushort s)
    {
      glTexCoord1hNV del = (glTexCoord1hNV)GetProc<glTexCoord1hNV>();
      del(s);
    }

    public static void TexCoord1hvNV(ref ushort[] v)
    {
      glTexCoord1hvNV del = (glTexCoord1hvNV)GetProc<glTexCoord1hvNV>();
      del(ref v);
    }

    public static void TexCoord1xOES(int s)
    {
      glTexCoord1xOES del = (glTexCoord1xOES)GetProc<glTexCoord1xOES>();
      del(s);
    }

    public static void TexCoord1xvOES(ref int[] coords)
    {
      glTexCoord1xvOES del = (glTexCoord1xvOES)GetProc<glTexCoord1xvOES>();
      del(ref coords);
    }

    public static void TexCoord2bOES(sbyte s, sbyte t)
    {
      glTexCoord2bOES del = (glTexCoord2bOES)GetProc<glTexCoord2bOES>();
      del(s, t);
    }

    public static void TexCoord2bvOES(ref sbyte[] coords)
    {
      glTexCoord2bvOES del = (glTexCoord2bvOES)GetProc<glTexCoord2bvOES>();
      del(ref coords);
    }

    public static void TexCoord2fColor3fVertex3fSUN(float s, float t, float r, float g, float b, float x, float y, float z)
    {
      glTexCoord2fColor3fVertex3fSUN del = (glTexCoord2fColor3fVertex3fSUN)GetProc<glTexCoord2fColor3fVertex3fSUN>();
      del(s, t, r, g, b, x, y, z);
    }

    public static void TexCoord2fColor3fVertex3fvSUN(ref float[] tc, ref float[] c, ref float[] v)
    {
      glTexCoord2fColor3fVertex3fvSUN del = (glTexCoord2fColor3fVertex3fvSUN)GetProc<glTexCoord2fColor3fVertex3fvSUN>();
      del(ref tc, ref c, ref v);
    }

    public static void TexCoord2fColor4fNormal3fVertex3fSUN(float s, float t, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z)
    {
      glTexCoord2fColor4fNormal3fVertex3fSUN del = (glTexCoord2fColor4fNormal3fVertex3fSUN)GetProc<glTexCoord2fColor4fNormal3fVertex3fSUN>();
      del(s, t, r, g, b, a, nx, ny, nz, x, y, z);
    }

    public static void TexCoord2fColor4fNormal3fVertex3fvSUN(ref float[] tc, ref float[] c, ref float[] n, ref float[] v)
    {
      glTexCoord2fColor4fNormal3fVertex3fvSUN del = (glTexCoord2fColor4fNormal3fVertex3fvSUN)GetProc<glTexCoord2fColor4fNormal3fVertex3fvSUN>();
      del(ref tc, ref c, ref n, ref v);
    }

    public static void TexCoord2fColor4ubVertex3fSUN(float s, float t, byte r, byte g, byte b, byte a, float x, float y, float z)
    {
      glTexCoord2fColor4ubVertex3fSUN del = (glTexCoord2fColor4ubVertex3fSUN)GetProc<glTexCoord2fColor4ubVertex3fSUN>();
      del(s, t, r, g, b, a, x, y, z);
    }

    public static void TexCoord2fColor4ubVertex3fvSUN(ref float[] tc, ref byte[] c, ref float[] v)
    {
      glTexCoord2fColor4ubVertex3fvSUN del = (glTexCoord2fColor4ubVertex3fvSUN)GetProc<glTexCoord2fColor4ubVertex3fvSUN>();
      del(ref tc, ref c, ref v);
    }

    public static void TexCoord2fNormal3fVertex3fSUN(float s, float t, float nx, float ny, float nz, float x, float y, float z)
    {
      glTexCoord2fNormal3fVertex3fSUN del = (glTexCoord2fNormal3fVertex3fSUN)GetProc<glTexCoord2fNormal3fVertex3fSUN>();
      del(s, t, nx, ny, nz, x, y, z);
    }

    public static void TexCoord2fNormal3fVertex3fvSUN(ref float[] tc, ref float[] n, ref float[] v)
    {
      glTexCoord2fNormal3fVertex3fvSUN del = (glTexCoord2fNormal3fVertex3fvSUN)GetProc<glTexCoord2fNormal3fVertex3fvSUN>();
      del(ref tc, ref n, ref v);
    }

    public static void TexCoord2fVertex3fSUN(float s, float t, float x, float y, float z)
    {
      glTexCoord2fVertex3fSUN del = (glTexCoord2fVertex3fSUN)GetProc<glTexCoord2fVertex3fSUN>();
      del(s, t, x, y, z);
    }

    public static void TexCoord2fVertex3fvSUN(ref float[] tc, ref float[] v)
    {
      glTexCoord2fVertex3fvSUN del = (glTexCoord2fVertex3fvSUN)GetProc<glTexCoord2fVertex3fvSUN>();
      del(ref tc, ref v);
    }

    public static void TexCoord2hNV(ushort s, ushort t)
    {
      glTexCoord2hNV del = (glTexCoord2hNV)GetProc<glTexCoord2hNV>();
      del(s, t);
    }

    public static void TexCoord2hvNV(ref ushort[] v)
    {
      glTexCoord2hvNV del = (glTexCoord2hvNV)GetProc<glTexCoord2hvNV>();
      del(ref v);
    }

    public static void TexCoord2xOES(int s, int t)
    {
      glTexCoord2xOES del = (glTexCoord2xOES)GetProc<glTexCoord2xOES>();
      del(s, t);
    }

    public static void TexCoord2xvOES(ref int[] coords)
    {
      glTexCoord2xvOES del = (glTexCoord2xvOES)GetProc<glTexCoord2xvOES>();
      del(ref coords);
    }

    public static void TexCoord3bOES(sbyte s, sbyte t, sbyte r)
    {
      glTexCoord3bOES del = (glTexCoord3bOES)GetProc<glTexCoord3bOES>();
      del(s, t, r);
    }

    public static void TexCoord3bvOES(ref sbyte[] coords)
    {
      glTexCoord3bvOES del = (glTexCoord3bvOES)GetProc<glTexCoord3bvOES>();
      del(ref coords);
    }

    public static void TexCoord3hNV(ushort s, ushort t, ushort r)
    {
      glTexCoord3hNV del = (glTexCoord3hNV)GetProc<glTexCoord3hNV>();
      del(s, t, r);
    }

    public static void TexCoord3hvNV(ref ushort[] v)
    {
      glTexCoord3hvNV del = (glTexCoord3hvNV)GetProc<glTexCoord3hvNV>();
      del(ref v);
    }

    public static void TexCoord3xOES(int s, int t, int r)
    {
      glTexCoord3xOES del = (glTexCoord3xOES)GetProc<glTexCoord3xOES>();
      del(s, t, r);
    }

    public static void TexCoord3xvOES(ref int[] coords)
    {
      glTexCoord3xvOES del = (glTexCoord3xvOES)GetProc<glTexCoord3xvOES>();
      del(ref coords);
    }

    public static void TexCoord4bOES(sbyte s, sbyte t, sbyte r, sbyte q)
    {
      glTexCoord4bOES del = (glTexCoord4bOES)GetProc<glTexCoord4bOES>();
      del(s, t, r, q);
    }

    public static void TexCoord4bvOES(ref sbyte[] coords)
    {
      glTexCoord4bvOES del = (glTexCoord4bvOES)GetProc<glTexCoord4bvOES>();
      del(ref coords);
    }

    public static void TexCoord4fColor4fNormal3fVertex4fSUN(float s, float t, float p, float q, float r, float g, float b, float a, float nx, float ny, float nz, float x, float y, float z, float w)
    {
      glTexCoord4fColor4fNormal3fVertex4fSUN del = (glTexCoord4fColor4fNormal3fVertex4fSUN)GetProc<glTexCoord4fColor4fNormal3fVertex4fSUN>();
      del(s, t, p, q, r, g, b, a, nx, ny, nz, x, y, z, w);
    }

    public static void TexCoord4fColor4fNormal3fVertex4fvSUN(ref float[] tc, ref float[] c, ref float[] n, ref float[] v)
    {
      glTexCoord4fColor4fNormal3fVertex4fvSUN del = (glTexCoord4fColor4fNormal3fVertex4fvSUN)GetProc<glTexCoord4fColor4fNormal3fVertex4fvSUN>();
      del(ref tc, ref c, ref n, ref v);
    }

    public static void TexCoord4fVertex4fSUN(float s, float t, float p, float q, float x, float y, float z, float w)
    {
      glTexCoord4fVertex4fSUN del = (glTexCoord4fVertex4fSUN)GetProc<glTexCoord4fVertex4fSUN>();
      del(s, t, p, q, x, y, z, w);
    }

    public static void TexCoord4fVertex4fvSUN(ref float[] tc, ref float[] v)
    {
      glTexCoord4fVertex4fvSUN del = (glTexCoord4fVertex4fvSUN)GetProc<glTexCoord4fVertex4fvSUN>();
      del(ref tc, ref v);
    }

    public static void TexCoord4hNV(ushort s, ushort t, ushort r, ushort q)
    {
      glTexCoord4hNV del = (glTexCoord4hNV)GetProc<glTexCoord4hNV>();
      del(s, t, r, q);
    }

    public static void TexCoord4hvNV(ref ushort[] v)
    {
      glTexCoord4hvNV del = (glTexCoord4hvNV)GetProc<glTexCoord4hvNV>();
      del(ref v);
    }

    public static void TexCoord4xOES(int s, int t, int r, int q)
    {
      glTexCoord4xOES del = (glTexCoord4xOES)GetProc<glTexCoord4xOES>();
      del(s, t, r, q);
    }

    public static void TexCoord4xvOES(ref int[] coords)
    {
      glTexCoord4xvOES del = (glTexCoord4xvOES)GetProc<glTexCoord4xvOES>();
      del(ref coords);
    }

    public static void TexCoordFormatNV(int size, uint type, int stride)
    {
      glTexCoordFormatNV del = (glTexCoordFormatNV)GetProc<glTexCoordFormatNV>();
      del(size, type, stride);
    }

    public static void TexCoordP1ui(uint type, uint coords)
    {
      glTexCoordP1ui del = (glTexCoordP1ui)GetProc<glTexCoordP1ui>();
      del(type, coords);
    }

    public static void TexCoordP1uiv(uint type, ref uint[] coords)
    {
      glTexCoordP1uiv del = (glTexCoordP1uiv)GetProc<glTexCoordP1uiv>();
      del(type, ref coords);
    }

    public static void TexCoordP2ui(uint type, uint coords)
    {
      glTexCoordP2ui del = (glTexCoordP2ui)GetProc<glTexCoordP2ui>();
      del(type, coords);
    }

    public static void TexCoordP2uiv(uint type, ref uint[] coords)
    {
      glTexCoordP2uiv del = (glTexCoordP2uiv)GetProc<glTexCoordP2uiv>();
      del(type, ref coords);
    }

    public static void TexCoordP3ui(uint type, uint coords)
    {
      glTexCoordP3ui del = (glTexCoordP3ui)GetProc<glTexCoordP3ui>();
      del(type, coords);
    }

    public static void TexCoordP3uiv(uint type, ref uint[] coords)
    {
      glTexCoordP3uiv del = (glTexCoordP3uiv)GetProc<glTexCoordP3uiv>();
      del(type, ref coords);
    }

    public static void TexCoordP4ui(uint type, uint coords)
    {
      glTexCoordP4ui del = (glTexCoordP4ui)GetProc<glTexCoordP4ui>();
      del(type, coords);
    }

    public static void TexCoordP4uiv(uint type, ref uint[] coords)
    {
      glTexCoordP4uiv del = (glTexCoordP4uiv)GetProc<glTexCoordP4uiv>();
      del(type, ref coords);
    }

    public static void TexCoordPointerEXT(int size, uint type, int stride, int count, IntPtr pointer)
    {
      glTexCoordPointerEXT del = (glTexCoordPointerEXT)GetProc<glTexCoordPointerEXT>();
      del(size, type, stride, count, pointer);
    }

    public static void TexCoordPointerListIBM(int size, uint type, int stride, IntPtr pointer, int ptrstride)
    {
      glTexCoordPointerListIBM del = (glTexCoordPointerListIBM)GetProc<glTexCoordPointerListIBM>();
      del(size, type, stride, pointer, ptrstride);
    }

    public static void TexCoordPointervINTEL(int size, uint type, IntPtr pointer)
    {
      glTexCoordPointervINTEL del = (glTexCoordPointervINTEL)GetProc<glTexCoordPointervINTEL>();
      del(size, type, pointer);
    }

    public static void TexEnvxOES(uint target, uint pname, int param)
    {
      glTexEnvxOES del = (glTexEnvxOES)GetProc<glTexEnvxOES>();
      del(target, pname, param);
    }

    public static void TexEnvxvOES(uint target, uint pname, ref int[] parameters)
    {
      glTexEnvxvOES del = (glTexEnvxvOES)GetProc<glTexEnvxvOES>();
      del(target, pname, ref parameters);
    }

    public static void TexFilterFuncSGIS(uint target, uint filter, int n, ref float[] weights)
    {
      glTexFilterFuncSGIS del = (glTexFilterFuncSGIS)GetProc<glTexFilterFuncSGIS>();
      del(target, filter, n, ref weights);
    }

    public static void TexGenxOES(uint coord, uint pname, int param)
    {
      glTexGenxOES del = (glTexGenxOES)GetProc<glTexGenxOES>();
      del(coord, pname, param);
    }

    public static void TexGenxvOES(uint coord, uint pname, ref int[] parameters)
    {
      glTexGenxvOES del = (glTexGenxvOES)GetProc<glTexGenxvOES>();
      del(coord, pname, ref parameters);
    }

    public static void TexImage2DMultisample(uint target, int samples, uint internalformat, int width, int height, bool fixedsamplelocations)
    {
      glTexImage2DMultisample del = (glTexImage2DMultisample)GetProc<glTexImage2DMultisample>();
      del(target, samples, internalformat, width, height, fixedsamplelocations);
    }

    public static void TexImage2DMultisampleCoverageNV(uint target, int coverageSamples, int colorSamples, int internalFormat, int width, int height, bool fixedSampleLocations)
    {
      glTexImage2DMultisampleCoverageNV del = (glTexImage2DMultisampleCoverageNV)GetProc<glTexImage2DMultisampleCoverageNV>();
      del(target, coverageSamples, colorSamples, internalFormat, width, height, fixedSampleLocations);
    }

    public static void TexImage3D(uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, IntPtr pixels)
    {
      glTexImage3D del = (glTexImage3D)GetProc<glTexImage3D>();
      del(target, level, internalformat, width, height, depth, border, format, type, pixels);
    }

    public static void TexImage3DEXT(uint target, int level, uint internalformat, int width, int height, int depth, int border, uint format, uint type, IntPtr pixels)
    {
      glTexImage3DEXT del = (glTexImage3DEXT)GetProc<glTexImage3DEXT>();
      del(target, level, internalformat, width, height, depth, border, format, type, pixels);
    }

    public static void TexImage3DMultisample(uint target, int samples, uint internalformat, int width, int height, int depth, bool fixedsamplelocations)
    {
      glTexImage3DMultisample del = (glTexImage3DMultisample)GetProc<glTexImage3DMultisample>();
      del(target, samples, internalformat, width, height, depth, fixedsamplelocations);
    }

    public static void TexImage3DMultisampleCoverageNV(uint target, int coverageSamples, int colorSamples, int internalFormat, int width, int height, int depth, bool fixedSampleLocations)
    {
      glTexImage3DMultisampleCoverageNV del = (glTexImage3DMultisampleCoverageNV)GetProc<glTexImage3DMultisampleCoverageNV>();
      del(target, coverageSamples, colorSamples, internalFormat, width, height, depth, fixedSampleLocations);
    }

    public static void TexImage4DSGIS(uint target, int level, uint internalformat, int width, int height, int depth, int size4d, int border, uint format, uint type, IntPtr pixels)
    {
      glTexImage4DSGIS del = (glTexImage4DSGIS)GetProc<glTexImage4DSGIS>();
      del(target, level, internalformat, width, height, depth, size4d, border, format, type, pixels);
    }

    public static void TexPageCommitmentARB(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, bool resident)
    {
      glTexPageCommitmentARB del = (glTexPageCommitmentARB)GetProc<glTexPageCommitmentARB>();
      del(target, level, xoffset, yoffset, zoffset, width, height, depth, resident);
    }

    public static void TexParameterIiv(uint target, uint pname, ref int[] parameters)
    {
      glTexParameterIiv del = (glTexParameterIiv)GetProc<glTexParameterIiv>();
      del(target, pname, ref parameters);
    }

    public static void TexParameterIivEXT(uint target, uint pname, ref int[] parameters)
    {
      glTexParameterIivEXT del = (glTexParameterIivEXT)GetProc<glTexParameterIivEXT>();
      del(target, pname, ref parameters);
    }

    public static void TexParameterIuiv(uint target, uint pname, ref uint[] parameters)
    {
      glTexParameterIuiv del = (glTexParameterIuiv)GetProc<glTexParameterIuiv>();
      del(target, pname, ref parameters);
    }

    public static void TexParameterIuivEXT(uint target, uint pname, ref uint[] parameters)
    {
      glTexParameterIuivEXT del = (glTexParameterIuivEXT)GetProc<glTexParameterIuivEXT>();
      del(target, pname, ref parameters);
    }

    public static void TexParameterxOES(uint target, uint pname, int param)
    {
      glTexParameterxOES del = (glTexParameterxOES)GetProc<glTexParameterxOES>();
      del(target, pname, param);
    }

    public static void TexParameterxvOES(uint target, uint pname, ref int[] parameters)
    {
      glTexParameterxvOES del = (glTexParameterxvOES)GetProc<glTexParameterxvOES>();
      del(target, pname, ref parameters);
    }

    public static void TexRenderbufferNV(uint target, uint renderbuffer)
    {
      glTexRenderbufferNV del = (glTexRenderbufferNV)GetProc<glTexRenderbufferNV>();
      del(target, renderbuffer);
    }

    public static void TexStorage1D(uint target, int levels, uint internalformat, int width)
    {
      glTexStorage1D del = (glTexStorage1D)GetProc<glTexStorage1D>();
      del(target, levels, internalformat, width);
    }

    public static void TexStorage2D(uint target, int levels, uint internalformat, int width, int height)
    {
      glTexStorage2D del = (glTexStorage2D)GetProc<glTexStorage2D>();
      del(target, levels, internalformat, width, height);
    }

    public static void TexStorage2DMultisample(uint target, int samples, uint internalformat, int width, int height, bool fixedsamplelocations)
    {
      glTexStorage2DMultisample del = (glTexStorage2DMultisample)GetProc<glTexStorage2DMultisample>();
      del(target, samples, internalformat, width, height, fixedsamplelocations);
    }

    public static void TexStorage3D(uint target, int levels, uint internalformat, int width, int height, int depth)
    {
      glTexStorage3D del = (glTexStorage3D)GetProc<glTexStorage3D>();
      del(target, levels, internalformat, width, height, depth);
    }

    public static void TexStorage3DMultisample(uint target, int samples, uint internalformat, int width, int height, int depth, bool fixedsamplelocations)
    {
      glTexStorage3DMultisample del = (glTexStorage3DMultisample)GetProc<glTexStorage3DMultisample>();
      del(target, samples, internalformat, width, height, depth, fixedsamplelocations);
    }

    public static void TexStorageSparseAMD(uint target, uint internalFormat, int width, int height, int depth, int layers, uint flags)
    {
      glTexStorageSparseAMD del = (glTexStorageSparseAMD)GetProc<glTexStorageSparseAMD>();
      del(target, internalFormat, width, height, depth, layers, flags);
    }

    public static void TexSubImage1DEXT(uint target, int level, int xoffset, int width, uint format, uint type, IntPtr pixels)
    {
      glTexSubImage1DEXT del = (glTexSubImage1DEXT)GetProc<glTexSubImage1DEXT>();
      del(target, level, xoffset, width, format, type, pixels);
    }

    public static void TexSubImage2DEXT(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, IntPtr pixels)
    {
      glTexSubImage2DEXT del = (glTexSubImage2DEXT)GetProc<glTexSubImage2DEXT>();
      del(target, level, xoffset, yoffset, width, height, format, type, pixels);
    }

    public static void TexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, IntPtr pixels)
    {
      glTexSubImage3D del = (glTexSubImage3D)GetProc<glTexSubImage3D>();
      del(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
    }

    public static void TexSubImage3DEXT(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, IntPtr pixels)
    {
      glTexSubImage3DEXT del = (glTexSubImage3DEXT)GetProc<glTexSubImage3DEXT>();
      del(target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
    }

    public static void TexSubImage4DSGIS(uint target, int level, int xoffset, int yoffset, int zoffset, int woffset, int width, int height, int depth, int size4d, uint format, uint type, IntPtr pixels)
    {
      glTexSubImage4DSGIS del = (glTexSubImage4DSGIS)GetProc<glTexSubImage4DSGIS>();
      del(target, level, xoffset, yoffset, zoffset, woffset, width, height, depth, size4d, format, type, pixels);
    }

    public static void TextureBarrierNV()
    {
      glTextureBarrierNV del = (glTextureBarrierNV)GetProc<glTextureBarrierNV>();
      del();
    }

    public static void TextureBufferEXT(uint texture, uint target, uint internalformat, uint buffer)
    {
      glTextureBufferEXT del = (glTextureBufferEXT)GetProc<glTextureBufferEXT>();
      del(texture, target, internalformat, buffer);
    }

    public static void TextureBufferRangeEXT(uint texture, uint target, uint internalformat, uint buffer, IntPtr offset, IntPtr size)
    {
      glTextureBufferRangeEXT del = (glTextureBufferRangeEXT)GetProc<glTextureBufferRangeEXT>();
      del(texture, target, internalformat, buffer, offset, size);
    }

    public static void TextureColorMaskSGIS(bool red, bool green, bool blue, bool alpha)
    {
      glTextureColorMaskSGIS del = (glTextureColorMaskSGIS)GetProc<glTextureColorMaskSGIS>();
      del(red, green, blue, alpha);
    }

    public static void TextureImage1DEXT(uint texture, uint target, int level, int internalformat, int width, int border, uint format, uint type, IntPtr pixels)
    {
      glTextureImage1DEXT del = (glTextureImage1DEXT)GetProc<glTextureImage1DEXT>();
      del(texture, target, level, internalformat, width, border, format, type, pixels);
    }

    public static void TextureImage2DEXT(uint texture, uint target, int level, int internalformat, int width, int height, int border, uint format, uint type, IntPtr pixels)
    {
      glTextureImage2DEXT del = (glTextureImage2DEXT)GetProc<glTextureImage2DEXT>();
      del(texture, target, level, internalformat, width, height, border, format, type, pixels);
    }

    public static void TextureImage2DMultisampleCoverageNV(uint texture, uint target, int coverageSamples, int colorSamples, int internalFormat, int width, int height, bool fixedSampleLocations)
    {
      glTextureImage2DMultisampleCoverageNV del = (glTextureImage2DMultisampleCoverageNV)GetProc<glTextureImage2DMultisampleCoverageNV>();
      del(texture, target, coverageSamples, colorSamples, internalFormat, width, height, fixedSampleLocations);
    }

    public static void TextureImage2DMultisampleNV(uint texture, uint target, int samples, int internalFormat, int width, int height, bool fixedSampleLocations)
    {
      glTextureImage2DMultisampleNV del = (glTextureImage2DMultisampleNV)GetProc<glTextureImage2DMultisampleNV>();
      del(texture, target, samples, internalFormat, width, height, fixedSampleLocations);
    }

    public static void TextureImage3DEXT(uint texture, uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, IntPtr pixels)
    {
      glTextureImage3DEXT del = (glTextureImage3DEXT)GetProc<glTextureImage3DEXT>();
      del(texture, target, level, internalformat, width, height, depth, border, format, type, pixels);
    }

    public static void TextureImage3DMultisampleCoverageNV(uint texture, uint target, int coverageSamples, int colorSamples, int internalFormat, int width, int height, int depth, bool fixedSampleLocations)
    {
      glTextureImage3DMultisampleCoverageNV del = (glTextureImage3DMultisampleCoverageNV)GetProc<glTextureImage3DMultisampleCoverageNV>();
      del(texture, target, coverageSamples, colorSamples, internalFormat, width, height, depth, fixedSampleLocations);
    }

    public static void TextureImage3DMultisampleNV(uint texture, uint target, int samples, int internalFormat, int width, int height, int depth, bool fixedSampleLocations)
    {
      glTextureImage3DMultisampleNV del = (glTextureImage3DMultisampleNV)GetProc<glTextureImage3DMultisampleNV>();
      del(texture, target, samples, internalFormat, width, height, depth, fixedSampleLocations);
    }

    public static void TextureLightEXT(uint pname)
    {
      glTextureLightEXT del = (glTextureLightEXT)GetProc<glTextureLightEXT>();
      del(pname);
    }

    public static void TextureMaterialEXT(uint face, uint mode)
    {
      glTextureMaterialEXT del = (glTextureMaterialEXT)GetProc<glTextureMaterialEXT>();
      del(face, mode);
    }

    public static void TextureNormalEXT(uint mode)
    {
      glTextureNormalEXT del = (glTextureNormalEXT)GetProc<glTextureNormalEXT>();
      del(mode);
    }

    public static void TexturePageCommitmentEXT(uint texture, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, bool resident)
    {
      glTexturePageCommitmentEXT del = (glTexturePageCommitmentEXT)GetProc<glTexturePageCommitmentEXT>();
      del(texture, level, xoffset, yoffset, zoffset, width, height, depth, resident);
    }

    public static void TextureParameterfEXT(uint texture, uint target, uint pname, float param)
    {
      glTextureParameterfEXT del = (glTextureParameterfEXT)GetProc<glTextureParameterfEXT>();
      del(texture, target, pname, param);
    }

    public static void TextureParameterfvEXT(uint texture, uint target, uint pname, ref float[] parameters)
    {
      glTextureParameterfvEXT del = (glTextureParameterfvEXT)GetProc<glTextureParameterfvEXT>();
      del(texture, target, pname, ref parameters);
    }

    public static void TextureParameteriEXT(uint texture, uint target, uint pname, int param)
    {
      glTextureParameteriEXT del = (glTextureParameteriEXT)GetProc<glTextureParameteriEXT>();
      del(texture, target, pname, param);
    }

    public static void TextureParameterIivEXT(uint texture, uint target, uint pname, ref int[] parameters)
    {
      glTextureParameterIivEXT del = (glTextureParameterIivEXT)GetProc<glTextureParameterIivEXT>();
      del(texture, target, pname, ref parameters);
    }

    public static void TextureParameterIuivEXT(uint texture, uint target, uint pname, ref uint[] parameters)
    {
      glTextureParameterIuivEXT del = (glTextureParameterIuivEXT)GetProc<glTextureParameterIuivEXT>();
      del(texture, target, pname, ref parameters);
    }

    public static void TextureParameterivEXT(uint texture, uint target, uint pname, ref int[] parameters)
    {
      glTextureParameterivEXT del = (glTextureParameterivEXT)GetProc<glTextureParameterivEXT>();
      del(texture, target, pname, ref parameters);
    }

    public static void TextureRangeAPPLE(uint target, int length, IntPtr pointer)
    {
      glTextureRangeAPPLE del = (glTextureRangeAPPLE)GetProc<glTextureRangeAPPLE>();
      del(target, length, pointer);
    }

    public static void TextureRenderbufferEXT(uint texture, uint target, uint renderbuffer)
    {
      glTextureRenderbufferEXT del = (glTextureRenderbufferEXT)GetProc<glTextureRenderbufferEXT>();
      del(texture, target, renderbuffer);
    }

    public static void TextureStorage1DEXT(uint texture, uint target, int levels, uint internalformat, int width)
    {
      glTextureStorage1DEXT del = (glTextureStorage1DEXT)GetProc<glTextureStorage1DEXT>();
      del(texture, target, levels, internalformat, width);
    }

    public static void TextureStorage2DEXT(uint texture, uint target, int levels, uint internalformat, int width, int height)
    {
      glTextureStorage2DEXT del = (glTextureStorage2DEXT)GetProc<glTextureStorage2DEXT>();
      del(texture, target, levels, internalformat, width, height);
    }

    public static void TextureStorage2DMultisampleEXT(uint texture, uint target, int samples, uint internalformat, int width, int height, bool fixedsamplelocations)
    {
      glTextureStorage2DMultisampleEXT del = (glTextureStorage2DMultisampleEXT)GetProc<glTextureStorage2DMultisampleEXT>();
      del(texture, target, samples, internalformat, width, height, fixedsamplelocations);
    }

    public static void TextureStorage3DEXT(uint texture, uint target, int levels, uint internalformat, int width, int height, int depth)
    {
      glTextureStorage3DEXT del = (glTextureStorage3DEXT)GetProc<glTextureStorage3DEXT>();
      del(texture, target, levels, internalformat, width, height, depth);
    }

    public static void TextureStorage3DMultisampleEXT(uint texture, uint target, int samples, uint internalformat, int width, int height, int depth, bool fixedsamplelocations)
    {
      glTextureStorage3DMultisampleEXT del = (glTextureStorage3DMultisampleEXT)GetProc<glTextureStorage3DMultisampleEXT>();
      del(texture, target, samples, internalformat, width, height, depth, fixedsamplelocations);
    }

    public static void TextureStorageSparseAMD(uint texture, uint target, uint internalFormat, int width, int height, int depth, int layers, uint flags)
    {
      glTextureStorageSparseAMD del = (glTextureStorageSparseAMD)GetProc<glTextureStorageSparseAMD>();
      del(texture, target, internalFormat, width, height, depth, layers, flags);
    }

    public static void TextureSubImage1DEXT(uint texture, uint target, int level, int xoffset, int width, uint format, uint type, IntPtr pixels)
    {
      glTextureSubImage1DEXT del = (glTextureSubImage1DEXT)GetProc<glTextureSubImage1DEXT>();
      del(texture, target, level, xoffset, width, format, type, pixels);
    }

    public static void TextureSubImage2DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, IntPtr pixels)
    {
      glTextureSubImage2DEXT del = (glTextureSubImage2DEXT)GetProc<glTextureSubImage2DEXT>();
      del(texture, target, level, xoffset, yoffset, width, height, format, type, pixels);
    }

    public static void TextureSubImage3DEXT(uint texture, uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, IntPtr pixels)
    {
      glTextureSubImage3DEXT del = (glTextureSubImage3DEXT)GetProc<glTextureSubImage3DEXT>();
      del(texture, target, level, xoffset, yoffset, zoffset, width, height, depth, format, type, pixels);
    }

    public static void TextureView(uint texture, uint target, uint origtexture, uint internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers)
    {
      glTextureView del = (glTextureView)GetProc<glTextureView>();
      del(texture, target, origtexture, internalformat, minlevel, numlevels, minlayer, numlayers);
    }

    public static void TrackMatrixNV(uint target, uint address, uint matrix, uint transform)
    {
      glTrackMatrixNV del = (glTrackMatrixNV)GetProc<glTrackMatrixNV>();
      del(target, address, matrix, transform);
    }

    public static void TransformFeedbackAttribsNV(uint count, ref int[] attribs, uint bufferMode)
    {
      glTransformFeedbackAttribsNV del = (glTransformFeedbackAttribsNV)GetProc<glTransformFeedbackAttribsNV>();
      del(count, ref attribs, bufferMode);
    }

    public static void TransformFeedbackStreamAttribsNV(int count, ref int[] attribs, int nbuffers, ref int[] bufstreams, uint bufferMode)
    {
      glTransformFeedbackStreamAttribsNV del = (glTransformFeedbackStreamAttribsNV)GetProc<glTransformFeedbackStreamAttribsNV>();
      del(count, ref attribs, nbuffers, ref bufstreams, bufferMode);
    }

    public static void TransformFeedbackVaryings(uint program, int count, ref sbyte[] varyings, uint bufferMode)
    {
      glTransformFeedbackVaryings del = (glTransformFeedbackVaryings)GetProc<glTransformFeedbackVaryings>();
      del(program, count, ref varyings, bufferMode);
    }

    public static void TransformFeedbackVaryingsEXT(uint program, int count, ref sbyte[] varyings, uint bufferMode)
    {
      glTransformFeedbackVaryingsEXT del = (glTransformFeedbackVaryingsEXT)GetProc<glTransformFeedbackVaryingsEXT>();
      del(program, count, ref varyings, bufferMode);
    }

    public static void TransformFeedbackVaryingsNV(uint program, int count, ref int[] locations, uint bufferMode)
    {
      glTransformFeedbackVaryingsNV del = (glTransformFeedbackVaryingsNV)GetProc<glTransformFeedbackVaryingsNV>();
      del(program, count, ref locations, bufferMode);
    }

    public static void TransformPathNV(uint resultPath, uint srcPath, uint transformType, ref float[] transformValues)
    {
      glTransformPathNV del = (glTransformPathNV)GetProc<glTransformPathNV>();
      del(resultPath, srcPath, transformType, ref transformValues);
    }

    public static void TranslatexOES(int x, int y, int z)
    {
      glTranslatexOES del = (glTranslatexOES)GetProc<glTranslatexOES>();
      del(x, y, z);
    }

    public static void Uniform1d(int location, double x)
    {
      glUniform1d del = (glUniform1d)GetProc<glUniform1d>();
      del(location, x);
    }

    public static void Uniform1dv(int location, int count, ref double[] value)
    {
      glUniform1dv del = (glUniform1dv)GetProc<glUniform1dv>();
      del(location, count, ref value);
    }

    public static void Uniform1f(int location, float v0)
    {
      glUniform1f del = (glUniform1f)GetProc<glUniform1f>();
      del(location, v0);
    }

    public static void Uniform1fARB(int location, float v0)
    {
      glUniform1fARB del = (glUniform1fARB)GetProc<glUniform1fARB>();
      del(location, v0);
    }

    public static void Uniform1fv(int location, int count, ref float[] value)
    {
      glUniform1fv del = (glUniform1fv)GetProc<glUniform1fv>();
      del(location, count, ref value);
    }

    public static void Uniform1fvARB(int location, int count, ref float[] value)
    {
      glUniform1fvARB del = (glUniform1fvARB)GetProc<glUniform1fvARB>();
      del(location, count, ref value);
    }

    public static void Uniform1i(int location, int v0)
    {
      glUniform1i del = (glUniform1i)GetProc<glUniform1i>();
      del(location, v0);
    }

    public static void Uniform1i64NV(int location, long x)
    {
      glUniform1i64NV del = (glUniform1i64NV)GetProc<glUniform1i64NV>();
      del(location, x);
    }

    public static void Uniform1i64vNV(int location, int count, ref long[] value)
    {
      glUniform1i64vNV del = (glUniform1i64vNV)GetProc<glUniform1i64vNV>();
      del(location, count, ref value);
    }

    public static void Uniform1iARB(int location, int v0)
    {
      glUniform1iARB del = (glUniform1iARB)GetProc<glUniform1iARB>();
      del(location, v0);
    }

    public static void Uniform1iv(int location, int count, ref int[] value)
    {
      glUniform1iv del = (glUniform1iv)GetProc<glUniform1iv>();
      del(location, count, ref value);
    }

    public static void Uniform1ivARB(int location, int count, ref int[] value)
    {
      glUniform1ivARB del = (glUniform1ivARB)GetProc<glUniform1ivARB>();
      del(location, count, ref value);
    }

    public static void Uniform1ui(int location, uint v0)
    {
      glUniform1ui del = (glUniform1ui)GetProc<glUniform1ui>();
      del(location, v0);
    }

    public static void Uniform1ui64NV(int location, ulong x)
    {
      glUniform1ui64NV del = (glUniform1ui64NV)GetProc<glUniform1ui64NV>();
      del(location, x);
    }

    public static void Uniform1ui64vNV(int location, int count, ref ulong[] value)
    {
      glUniform1ui64vNV del = (glUniform1ui64vNV)GetProc<glUniform1ui64vNV>();
      del(location, count, ref value);
    }

    public static void Uniform1uiEXT(int location, uint v0)
    {
      glUniform1uiEXT del = (glUniform1uiEXT)GetProc<glUniform1uiEXT>();
      del(location, v0);
    }

    public static void Uniform1uiv(int location, int count, ref uint[] value)
    {
      glUniform1uiv del = (glUniform1uiv)GetProc<glUniform1uiv>();
      del(location, count, ref value);
    }

    public static void Uniform1uivEXT(int location, int count, ref uint[] value)
    {
      glUniform1uivEXT del = (glUniform1uivEXT)GetProc<glUniform1uivEXT>();
      del(location, count, ref value);
    }

    public static void Uniform2d(int location, double x, double y)
    {
      glUniform2d del = (glUniform2d)GetProc<glUniform2d>();
      del(location, x, y);
    }

    public static void Uniform2dv(int location, int count, ref double[] value)
    {
      glUniform2dv del = (glUniform2dv)GetProc<glUniform2dv>();
      del(location, count, ref value);
    }

    public static void Uniform2f(int location, float v0, float v1)
    {
      glUniform2f del = (glUniform2f)GetProc<glUniform2f>();
      del(location, v0, v1);
    }

    public static void Uniform2fARB(int location, float v0, float v1)
    {
      glUniform2fARB del = (glUniform2fARB)GetProc<glUniform2fARB>();
      del(location, v0, v1);
    }

    public static void Uniform2fv(int location, int count, ref float[] value)
    {
      glUniform2fv del = (glUniform2fv)GetProc<glUniform2fv>();
      del(location, count, ref value);
    }

    public static void Uniform2fvARB(int location, int count, ref float[] value)
    {
      glUniform2fvARB del = (glUniform2fvARB)GetProc<glUniform2fvARB>();
      del(location, count, ref value);
    }

    public static void Uniform2i(int location, int v0, int v1)
    {
      glUniform2i del = (glUniform2i)GetProc<glUniform2i>();
      del(location, v0, v1);
    }

    public static void Uniform2i64NV(int location, long x, long y)
    {
      glUniform2i64NV del = (glUniform2i64NV)GetProc<glUniform2i64NV>();
      del(location, x, y);
    }

    public static void Uniform2i64vNV(int location, int count, ref long[] value)
    {
      glUniform2i64vNV del = (glUniform2i64vNV)GetProc<glUniform2i64vNV>();
      del(location, count, ref value);
    }

    public static void Uniform2iARB(int location, int v0, int v1)
    {
      glUniform2iARB del = (glUniform2iARB)GetProc<glUniform2iARB>();
      del(location, v0, v1);
    }

    public static void Uniform2iv(int location, int count, ref int[] value)
    {
      glUniform2iv del = (glUniform2iv)GetProc<glUniform2iv>();
      del(location, count, ref value);
    }

    public static void Uniform2ivARB(int location, int count, ref int[] value)
    {
      glUniform2ivARB del = (glUniform2ivARB)GetProc<glUniform2ivARB>();
      del(location, count, ref value);
    }

    public static void Uniform2ui(int location, uint v0, uint v1)
    {
      glUniform2ui del = (glUniform2ui)GetProc<glUniform2ui>();
      del(location, v0, v1);
    }

    public static void Uniform2ui64NV(int location, ulong x, ulong y)
    {
      glUniform2ui64NV del = (glUniform2ui64NV)GetProc<glUniform2ui64NV>();
      del(location, x, y);
    }

    public static void Uniform2ui64vNV(int location, int count, ref ulong[] value)
    {
      glUniform2ui64vNV del = (glUniform2ui64vNV)GetProc<glUniform2ui64vNV>();
      del(location, count, ref value);
    }

    public static void Uniform2uiEXT(int location, uint v0, uint v1)
    {
      glUniform2uiEXT del = (glUniform2uiEXT)GetProc<glUniform2uiEXT>();
      del(location, v0, v1);
    }

    public static void Uniform2uiv(int location, int count, ref uint[] value)
    {
      glUniform2uiv del = (glUniform2uiv)GetProc<glUniform2uiv>();
      del(location, count, ref value);
    }

    public static void Uniform2uivEXT(int location, int count, ref uint[] value)
    {
      glUniform2uivEXT del = (glUniform2uivEXT)GetProc<glUniform2uivEXT>();
      del(location, count, ref value);
    }

    public static void Uniform3d(int location, double x, double y, double z)
    {
      glUniform3d del = (glUniform3d)GetProc<glUniform3d>();
      del(location, x, y, z);
    }

    public static void Uniform3dv(int location, int count, ref double[] value)
    {
      glUniform3dv del = (glUniform3dv)GetProc<glUniform3dv>();
      del(location, count, ref value);
    }

    public static void Uniform3f(int location, float v0, float v1, float v2)
    {
      glUniform3f del = (glUniform3f)GetProc<glUniform3f>();
      del(location, v0, v1, v2);
    }

    public static void Uniform3fARB(int location, float v0, float v1, float v2)
    {
      glUniform3fARB del = (glUniform3fARB)GetProc<glUniform3fARB>();
      del(location, v0, v1, v2);
    }

    public static void Uniform3fv(int location, int count, ref float[] value)
    {
      glUniform3fv del = (glUniform3fv)GetProc<glUniform3fv>();
      del(location, count, ref value);
    }

    public static void Uniform3fvARB(int location, int count, ref float[] value)
    {
      glUniform3fvARB del = (glUniform3fvARB)GetProc<glUniform3fvARB>();
      del(location, count, ref value);
    }

    public static void Uniform3i(int location, int v0, int v1, int v2)
    {
      glUniform3i del = (glUniform3i)GetProc<glUniform3i>();
      del(location, v0, v1, v2);
    }

    public static void Uniform3i64NV(int location, long x, long y, long z)
    {
      glUniform3i64NV del = (glUniform3i64NV)GetProc<glUniform3i64NV>();
      del(location, x, y, z);
    }

    public static void Uniform3i64vNV(int location, int count, ref long[] value)
    {
      glUniform3i64vNV del = (glUniform3i64vNV)GetProc<glUniform3i64vNV>();
      del(location, count, ref value);
    }

    public static void Uniform3iARB(int location, int v0, int v1, int v2)
    {
      glUniform3iARB del = (glUniform3iARB)GetProc<glUniform3iARB>();
      del(location, v0, v1, v2);
    }

    public static void Uniform3iv(int location, int count, ref int[] value)
    {
      glUniform3iv del = (glUniform3iv)GetProc<glUniform3iv>();
      del(location, count, ref value);
    }

    public static void Uniform3ivARB(int location, int count, ref int[] value)
    {
      glUniform3ivARB del = (glUniform3ivARB)GetProc<glUniform3ivARB>();
      del(location, count, ref value);
    }

    public static void Uniform3ui(int location, uint v0, uint v1, uint v2)
    {
      glUniform3ui del = (glUniform3ui)GetProc<glUniform3ui>();
      del(location, v0, v1, v2);
    }

    public static void Uniform3ui64NV(int location, ulong x, ulong y, ulong z)
    {
      glUniform3ui64NV del = (glUniform3ui64NV)GetProc<glUniform3ui64NV>();
      del(location, x, y, z);
    }

    public static void Uniform3ui64vNV(int location, int count, ref ulong[] value)
    {
      glUniform3ui64vNV del = (glUniform3ui64vNV)GetProc<glUniform3ui64vNV>();
      del(location, count, ref value);
    }

    public static void Uniform3uiEXT(int location, uint v0, uint v1, uint v2)
    {
      glUniform3uiEXT del = (glUniform3uiEXT)GetProc<glUniform3uiEXT>();
      del(location, v0, v1, v2);
    }

    public static void Uniform3uiv(int location, int count, ref uint[] value)
    {
      glUniform3uiv del = (glUniform3uiv)GetProc<glUniform3uiv>();
      del(location, count, ref value);
    }

    public static void Uniform3uivEXT(int location, int count, ref uint[] value)
    {
      glUniform3uivEXT del = (glUniform3uivEXT)GetProc<glUniform3uivEXT>();
      del(location, count, ref value);
    }

    public static void Uniform4d(int location, double x, double y, double z, double w)
    {
      glUniform4d del = (glUniform4d)GetProc<glUniform4d>();
      del(location, x, y, z, w);
    }

    public static void Uniform4dv(int location, int count, ref double[] value)
    {
      glUniform4dv del = (glUniform4dv)GetProc<glUniform4dv>();
      del(location, count, ref value);
    }

    public static void Uniform4f(int location, float v0, float v1, float v2, float v3)
    {
      glUniform4f del = (glUniform4f)GetProc<glUniform4f>();
      del(location, v0, v1, v2, v3);
    }

    public static void Uniform4fARB(int location, float v0, float v1, float v2, float v3)
    {
      glUniform4fARB del = (glUniform4fARB)GetProc<glUniform4fARB>();
      del(location, v0, v1, v2, v3);
    }

    public static void Uniform4fv(int location, int count, ref float[] value)
    {
      glUniform4fv del = (glUniform4fv)GetProc<glUniform4fv>();
      del(location, count, ref value);
    }

    public static void Uniform4fvARB(int location, int count, ref float[] value)
    {
      glUniform4fvARB del = (glUniform4fvARB)GetProc<glUniform4fvARB>();
      del(location, count, ref value);
    }

    public static void Uniform4i(int location, int v0, int v1, int v2, int v3)
    {
      glUniform4i del = (glUniform4i)GetProc<glUniform4i>();
      del(location, v0, v1, v2, v3);
    }

    public static void Uniform4i64NV(int location, long x, long y, long z, long w)
    {
      glUniform4i64NV del = (glUniform4i64NV)GetProc<glUniform4i64NV>();
      del(location, x, y, z, w);
    }

    public static void Uniform4i64vNV(int location, int count, ref long[] value)
    {
      glUniform4i64vNV del = (glUniform4i64vNV)GetProc<glUniform4i64vNV>();
      del(location, count, ref value);
    }

    public static void Uniform4iARB(int location, int v0, int v1, int v2, int v3)
    {
      glUniform4iARB del = (glUniform4iARB)GetProc<glUniform4iARB>();
      del(location, v0, v1, v2, v3);
    }

    public static void Uniform4iv(int location, int count, ref int[] value)
    {
      glUniform4iv del = (glUniform4iv)GetProc<glUniform4iv>();
      del(location, count, ref value);
    }

    public static void Uniform4ivARB(int location, int count, ref int[] value)
    {
      glUniform4ivARB del = (glUniform4ivARB)GetProc<glUniform4ivARB>();
      del(location, count, ref value);
    }

    public static void Uniform4ui(int location, uint v0, uint v1, uint v2, uint v3)
    {
      glUniform4ui del = (glUniform4ui)GetProc<glUniform4ui>();
      del(location, v0, v1, v2, v3);
    }

    public static void Uniform4ui64NV(int location, ulong x, ulong y, ulong z, ulong w)
    {
      glUniform4ui64NV del = (glUniform4ui64NV)GetProc<glUniform4ui64NV>();
      del(location, x, y, z, w);
    }

    public static void Uniform4ui64vNV(int location, int count, ref ulong[] value)
    {
      glUniform4ui64vNV del = (glUniform4ui64vNV)GetProc<glUniform4ui64vNV>();
      del(location, count, ref value);
    }

    public static void Uniform4uiEXT(int location, uint v0, uint v1, uint v2, uint v3)
    {
      glUniform4uiEXT del = (glUniform4uiEXT)GetProc<glUniform4uiEXT>();
      del(location, v0, v1, v2, v3);
    }

    public static void Uniform4uiv(int location, int count, ref uint[] value)
    {
      glUniform4uiv del = (glUniform4uiv)GetProc<glUniform4uiv>();
      del(location, count, ref value);
    }

    public static void Uniform4uivEXT(int location, int count, ref uint[] value)
    {
      glUniform4uivEXT del = (glUniform4uivEXT)GetProc<glUniform4uivEXT>();
      del(location, count, ref value);
    }

    public static void UniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding)
    {
      glUniformBlockBinding del = (glUniformBlockBinding)GetProc<glUniformBlockBinding>();
      del(program, uniformBlockIndex, uniformBlockBinding);
    }

    public static void UniformBufferEXT(uint program, int location, uint buffer)
    {
      glUniformBufferEXT del = (glUniformBufferEXT)GetProc<glUniformBufferEXT>();
      del(program, location, buffer);
    }

    public static void UniformHandleui64ARB(int location, ulong value)
    {
      glUniformHandleui64ARB del = (glUniformHandleui64ARB)GetProc<glUniformHandleui64ARB>();
      del(location, value);
    }

    public static void UniformHandleui64NV(int location, ulong value)
    {
      glUniformHandleui64NV del = (glUniformHandleui64NV)GetProc<glUniformHandleui64NV>();
      del(location, value);
    }

    public static void UniformHandleui64vARB(int location, int count, ref ulong[] value)
    {
      glUniformHandleui64vARB del = (glUniformHandleui64vARB)GetProc<glUniformHandleui64vARB>();
      del(location, count, ref value);
    }

    public static void UniformHandleui64vNV(int location, int count, ref ulong[] value)
    {
      glUniformHandleui64vNV del = (glUniformHandleui64vNV)GetProc<glUniformHandleui64vNV>();
      del(location, count, ref value);
    }

    public static void UniformMatrix2dv(int location, int count, bool transpose, ref double[] value)
    {
      glUniformMatrix2dv del = (glUniformMatrix2dv)GetProc<glUniformMatrix2dv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix2fv(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix2fv del = (glUniformMatrix2fv)GetProc<glUniformMatrix2fv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix2fvARB(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix2fvARB del = (glUniformMatrix2fvARB)GetProc<glUniformMatrix2fvARB>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix2x3dv(int location, int count, bool transpose, ref double[] value)
    {
      glUniformMatrix2x3dv del = (glUniformMatrix2x3dv)GetProc<glUniformMatrix2x3dv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix2x3fv(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix2x3fv del = (glUniformMatrix2x3fv)GetProc<glUniformMatrix2x3fv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix2x4dv(int location, int count, bool transpose, ref double[] value)
    {
      glUniformMatrix2x4dv del = (glUniformMatrix2x4dv)GetProc<glUniformMatrix2x4dv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix2x4fv(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix2x4fv del = (glUniformMatrix2x4fv)GetProc<glUniformMatrix2x4fv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix3dv(int location, int count, bool transpose, ref double[] value)
    {
      glUniformMatrix3dv del = (glUniformMatrix3dv)GetProc<glUniformMatrix3dv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix3fv(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix3fv del = (glUniformMatrix3fv)GetProc<glUniformMatrix3fv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix3fvARB(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix3fvARB del = (glUniformMatrix3fvARB)GetProc<glUniformMatrix3fvARB>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix3x2dv(int location, int count, bool transpose, ref double[] value)
    {
      glUniformMatrix3x2dv del = (glUniformMatrix3x2dv)GetProc<glUniformMatrix3x2dv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix3x2fv(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix3x2fv del = (glUniformMatrix3x2fv)GetProc<glUniformMatrix3x2fv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix3x4dv(int location, int count, bool transpose, ref double[] value)
    {
      glUniformMatrix3x4dv del = (glUniformMatrix3x4dv)GetProc<glUniformMatrix3x4dv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix3x4fv(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix3x4fv del = (glUniformMatrix3x4fv)GetProc<glUniformMatrix3x4fv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix4dv(int location, int count, bool transpose, ref double[] value)
    {
      glUniformMatrix4dv del = (glUniformMatrix4dv)GetProc<glUniformMatrix4dv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix4fv(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix4fv del = (glUniformMatrix4fv)GetProc<glUniformMatrix4fv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix4fvARB(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix4fvARB del = (glUniformMatrix4fvARB)GetProc<glUniformMatrix4fvARB>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix4x2dv(int location, int count, bool transpose, ref double[] value)
    {
      glUniformMatrix4x2dv del = (glUniformMatrix4x2dv)GetProc<glUniformMatrix4x2dv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix4x2fv(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix4x2fv del = (glUniformMatrix4x2fv)GetProc<glUniformMatrix4x2fv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix4x3dv(int location, int count, bool transpose, ref double[] value)
    {
      glUniformMatrix4x3dv del = (glUniformMatrix4x3dv)GetProc<glUniformMatrix4x3dv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformMatrix4x3fv(int location, int count, bool transpose, ref float[] value)
    {
      glUniformMatrix4x3fv del = (glUniformMatrix4x3fv)GetProc<glUniformMatrix4x3fv>();
      del(location, count, transpose, ref value);
    }

    public static void UniformSubroutinesuiv(uint shadertype, int count, ref uint[] indices)
    {
      glUniformSubroutinesuiv del = (glUniformSubroutinesuiv)GetProc<glUniformSubroutinesuiv>();
      del(shadertype, count, ref indices);
    }

    public static void Uniformui64NV(int location, ulong value)
    {
      glUniformui64NV del = (glUniformui64NV)GetProc<glUniformui64NV>();
      del(location, value);
    }

    public static void Uniformui64vNV(int location, int count, ref ulong[] value)
    {
      glUniformui64vNV del = (glUniformui64vNV)GetProc<glUniformui64vNV>();
      del(location, count, ref value);
    }

    public static void UnlockArraysEXT()
    {
      glUnlockArraysEXT del = (glUnlockArraysEXT)GetProc<glUnlockArraysEXT>();
      del();
    }

    public static void UnmapObjectBufferATI(uint buffer)
    {
      glUnmapObjectBufferATI del = (glUnmapObjectBufferATI)GetProc<glUnmapObjectBufferATI>();
      del(buffer);
    }

    public static void UnmapTexture2DINTEL(uint texture, int level)
    {
      glUnmapTexture2DINTEL del = (glUnmapTexture2DINTEL)GetProc<glUnmapTexture2DINTEL>();
      del(texture, level);
    }

    public static void UpdateObjectBufferATI(uint buffer, uint offset, int size, IntPtr pointer, uint preserve)
    {
      glUpdateObjectBufferATI del = (glUpdateObjectBufferATI)GetProc<glUpdateObjectBufferATI>();
      del(buffer, offset, size, pointer, preserve);
    }

    public static void UseProgram(uint program)
    {
      glUseProgram del = (glUseProgram)GetProc<glUseProgram>();
      del(program);
    }

    public static void UseProgramObjectARB(uint programObj)
    {
      glUseProgramObjectARB del = (glUseProgramObjectARB)GetProc<glUseProgramObjectARB>();
      del(programObj);
    }

    public static void UseProgramStages(uint pipeline, uint stages, uint program)
    {
      glUseProgramStages del = (glUseProgramStages)GetProc<glUseProgramStages>();
      del(pipeline, stages, program);
    }

    public static void UseShaderProgramEXT(uint type, uint program)
    {
      glUseShaderProgramEXT del = (glUseShaderProgramEXT)GetProc<glUseShaderProgramEXT>();
      del(type, program);
    }

    public static void ValidateProgram(uint program)
    {
      glValidateProgram del = (glValidateProgram)GetProc<glValidateProgram>();
      del(program);
    }

    public static void ValidateProgramARB(uint programObj)
    {
      glValidateProgramARB del = (glValidateProgramARB)GetProc<glValidateProgramARB>();
      del(programObj);
    }

    public static void ValidateProgramPipeline(uint pipeline)
    {
      glValidateProgramPipeline del = (glValidateProgramPipeline)GetProc<glValidateProgramPipeline>();
      del(pipeline);
    }

    public static void VariantArrayObjectATI(uint id, uint type, int stride, uint buffer, uint offset)
    {
      glVariantArrayObjectATI del = (glVariantArrayObjectATI)GetProc<glVariantArrayObjectATI>();
      del(id, type, stride, buffer, offset);
    }

    public static void VariantbvEXT(uint id, ref sbyte[] addr)
    {
      glVariantbvEXT del = (glVariantbvEXT)GetProc<glVariantbvEXT>();
      del(id, ref addr);
    }

    public static void VariantdvEXT(uint id, ref double[] addr)
    {
      glVariantdvEXT del = (glVariantdvEXT)GetProc<glVariantdvEXT>();
      del(id, ref addr);
    }

    public static void VariantfvEXT(uint id, ref float[] addr)
    {
      glVariantfvEXT del = (glVariantfvEXT)GetProc<glVariantfvEXT>();
      del(id, ref addr);
    }

    public static void VariantivEXT(uint id, ref int[] addr)
    {
      glVariantivEXT del = (glVariantivEXT)GetProc<glVariantivEXT>();
      del(id, ref addr);
    }

    public static void VariantPointerEXT(uint id, uint type, uint stride, IntPtr addr)
    {
      glVariantPointerEXT del = (glVariantPointerEXT)GetProc<glVariantPointerEXT>();
      del(id, type, stride, addr);
    }

    public static void VariantsvEXT(uint id, ref short[] addr)
    {
      glVariantsvEXT del = (glVariantsvEXT)GetProc<glVariantsvEXT>();
      del(id, ref addr);
    }

    public static void VariantubvEXT(uint id, ref byte[] addr)
    {
      glVariantubvEXT del = (glVariantubvEXT)GetProc<glVariantubvEXT>();
      del(id, ref addr);
    }

    public static void VariantuivEXT(uint id, ref uint[] addr)
    {
      glVariantuivEXT del = (glVariantuivEXT)GetProc<glVariantuivEXT>();
      del(id, ref addr);
    }

    public static void VariantusvEXT(uint id, ref ushort[] addr)
    {
      glVariantusvEXT del = (glVariantusvEXT)GetProc<glVariantusvEXT>();
      del(id, ref addr);
    }

    public static void VDPAUFiniNV()
    {
      glVDPAUFiniNV del = (glVDPAUFiniNV)GetProc<glVDPAUFiniNV>();
      del();
    }

    public static void VDPAUGetSurfaceivNV(IntPtr surface, uint pname, int bufSize, ref int[] length, ref int[] values)
    {
      glVDPAUGetSurfaceivNV del = (glVDPAUGetSurfaceivNV)GetProc<glVDPAUGetSurfaceivNV>();
      del(surface, pname, bufSize, ref length, ref values);
    }

    public static void VDPAUInitNV(IntPtr vdpDevice, IntPtr getProcAddress)
    {
      glVDPAUInitNV del = (glVDPAUInitNV)GetProc<glVDPAUInitNV>();
      del(vdpDevice, getProcAddress);
    }

    public static void VDPAUIsSurfaceNV(IntPtr surface)
    {
      glVDPAUIsSurfaceNV del = (glVDPAUIsSurfaceNV)GetProc<glVDPAUIsSurfaceNV>();
      del(surface);
    }

    public static void VDPAUMapSurfacesNV(int numSurfaces, IntPtr surfaces)
    {
      glVDPAUMapSurfacesNV del = (glVDPAUMapSurfacesNV)GetProc<glVDPAUMapSurfacesNV>();
      del(numSurfaces, surfaces);
    }

    public static void VDPAUSurfaceAccessNV(IntPtr surface, uint access)
    {
      glVDPAUSurfaceAccessNV del = (glVDPAUSurfaceAccessNV)GetProc<glVDPAUSurfaceAccessNV>();
      del(surface, access);
    }

    public static void VDPAUUnmapSurfacesNV(int numSurface, IntPtr surfaces)
    {
      glVDPAUUnmapSurfacesNV del = (glVDPAUUnmapSurfacesNV)GetProc<glVDPAUUnmapSurfacesNV>();
      del(numSurface, surfaces);
    }

    public static void VDPAUUnregisterSurfaceNV(IntPtr surface)
    {
      glVDPAUUnregisterSurfaceNV del = (glVDPAUUnregisterSurfaceNV)GetProc<glVDPAUUnregisterSurfaceNV>();
      del(surface);
    }

    public static void Vertex2bOES(sbyte x)
    {
      glVertex2bOES del = (glVertex2bOES)GetProc<glVertex2bOES>();
      del(x);
    }

    public static void Vertex2bvOES(ref sbyte[] coords)
    {
      glVertex2bvOES del = (glVertex2bvOES)GetProc<glVertex2bvOES>();
      del(ref coords);
    }

    public static void Vertex2hNV(ushort x, ushort y)
    {
      glVertex2hNV del = (glVertex2hNV)GetProc<glVertex2hNV>();
      del(x, y);
    }

    public static void Vertex2hvNV(ref ushort[] v)
    {
      glVertex2hvNV del = (glVertex2hvNV)GetProc<glVertex2hvNV>();
      del(ref v);
    }

    public static void Vertex2xOES(int x)
    {
      glVertex2xOES del = (glVertex2xOES)GetProc<glVertex2xOES>();
      del(x);
    }

    public static void Vertex2xvOES(ref int[] coords)
    {
      glVertex2xvOES del = (glVertex2xvOES)GetProc<glVertex2xvOES>();
      del(ref coords);
    }

    public static void Vertex3bOES(sbyte x, sbyte y)
    {
      glVertex3bOES del = (glVertex3bOES)GetProc<glVertex3bOES>();
      del(x, y);
    }

    public static void Vertex3bvOES(ref sbyte[] coords)
    {
      glVertex3bvOES del = (glVertex3bvOES)GetProc<glVertex3bvOES>();
      del(ref coords);
    }

    public static void Vertex3hNV(ushort x, ushort y, ushort z)
    {
      glVertex3hNV del = (glVertex3hNV)GetProc<glVertex3hNV>();
      del(x, y, z);
    }

    public static void Vertex3hvNV(ref ushort[] v)
    {
      glVertex3hvNV del = (glVertex3hvNV)GetProc<glVertex3hvNV>();
      del(ref v);
    }

    public static void Vertex3xOES(int x, int y)
    {
      glVertex3xOES del = (glVertex3xOES)GetProc<glVertex3xOES>();
      del(x, y);
    }

    public static void Vertex3xvOES(ref int[] coords)
    {
      glVertex3xvOES del = (glVertex3xvOES)GetProc<glVertex3xvOES>();
      del(ref coords);
    }

    public static void Vertex4bOES(sbyte x, sbyte y, sbyte z)
    {
      glVertex4bOES del = (glVertex4bOES)GetProc<glVertex4bOES>();
      del(x, y, z);
    }

    public static void Vertex4bvOES(ref sbyte[] coords)
    {
      glVertex4bvOES del = (glVertex4bvOES)GetProc<glVertex4bvOES>();
      del(ref coords);
    }

    public static void Vertex4hNV(ushort x, ushort y, ushort z, ushort w)
    {
      glVertex4hNV del = (glVertex4hNV)GetProc<glVertex4hNV>();
      del(x, y, z, w);
    }

    public static void Vertex4hvNV(ref ushort[] v)
    {
      glVertex4hvNV del = (glVertex4hvNV)GetProc<glVertex4hvNV>();
      del(ref v);
    }

    public static void Vertex4xOES(int x, int y, int z)
    {
      glVertex4xOES del = (glVertex4xOES)GetProc<glVertex4xOES>();
      del(x, y, z);
    }

    public static void Vertex4xvOES(ref int[] coords)
    {
      glVertex4xvOES del = (glVertex4xvOES)GetProc<glVertex4xvOES>();
      del(ref coords);
    }

    public static uint QueryMatrixxOES(ref int[] mantissa, ref int[] exponent)
    {
      glQueryMatrixxOES del = (glQueryMatrixxOES)GetProc<glQueryMatrixxOES>();
      return del(ref mantissa, ref exponent);
    }

    public static void VertexArrayBindVertexBufferEXT(uint vaobj, uint bindingindex, uint buffer, IntPtr offset, int stride)
    {
      glVertexArrayBindVertexBufferEXT del = (glVertexArrayBindVertexBufferEXT)GetProc<glVertexArrayBindVertexBufferEXT>();
      del(vaobj, bindingindex, buffer, offset, stride);
    }

    public static void VertexArrayColorOffsetEXT(uint vaobj, uint buffer, int size, uint type, int stride, IntPtr offset)
    {
      glVertexArrayColorOffsetEXT del = (glVertexArrayColorOffsetEXT)GetProc<glVertexArrayColorOffsetEXT>();
      del(vaobj, buffer, size, type, stride, offset);
    }

    public static void VertexArrayEdgeFlagOffsetEXT(uint vaobj, uint buffer, int stride, IntPtr offset)
    {
      glVertexArrayEdgeFlagOffsetEXT del = (glVertexArrayEdgeFlagOffsetEXT)GetProc<glVertexArrayEdgeFlagOffsetEXT>();
      del(vaobj, buffer, stride, offset);
    }

    public static void VertexArrayFogCoordOffsetEXT(uint vaobj, uint buffer, uint type, int stride, IntPtr offset)
    {
      glVertexArrayFogCoordOffsetEXT del = (glVertexArrayFogCoordOffsetEXT)GetProc<glVertexArrayFogCoordOffsetEXT>();
      del(vaobj, buffer, type, stride, offset);
    }

    public static void VertexArrayIndexOffsetEXT(uint vaobj, uint buffer, uint type, int stride, IntPtr offset)
    {
      glVertexArrayIndexOffsetEXT del = (glVertexArrayIndexOffsetEXT)GetProc<glVertexArrayIndexOffsetEXT>();
      del(vaobj, buffer, type, stride, offset);
    }

    public static void VertexArrayMultiTexCoordOffsetEXT(uint vaobj, uint buffer, uint texunit, int size, uint type, int stride, IntPtr offset)
    {
      glVertexArrayMultiTexCoordOffsetEXT del = (glVertexArrayMultiTexCoordOffsetEXT)GetProc<glVertexArrayMultiTexCoordOffsetEXT>();
      del(vaobj, buffer, texunit, size, type, stride, offset);
    }

    public static void VertexArrayNormalOffsetEXT(uint vaobj, uint buffer, uint type, int stride, IntPtr offset)
    {
      glVertexArrayNormalOffsetEXT del = (glVertexArrayNormalOffsetEXT)GetProc<glVertexArrayNormalOffsetEXT>();
      del(vaobj, buffer, type, stride, offset);
    }

    public static void VertexArrayParameteriAPPLE(uint pname, int param)
    {
      glVertexArrayParameteriAPPLE del = (glVertexArrayParameteriAPPLE)GetProc<glVertexArrayParameteriAPPLE>();
      del(pname, param);
    }

    public static void VertexArrayRangeAPPLE(int length, IntPtr pointer)
    {
      glVertexArrayRangeAPPLE del = (glVertexArrayRangeAPPLE)GetProc<glVertexArrayRangeAPPLE>();
      del(length, pointer);
    }

    public static void VertexArrayRangeNV(int length, IntPtr pointer)
    {
      glVertexArrayRangeNV del = (glVertexArrayRangeNV)GetProc<glVertexArrayRangeNV>();
      del(length, pointer);
    }

    public static void VertexArraySecondaryColorOffsetEXT(uint vaobj, uint buffer, int size, uint type, int stride, IntPtr offset)
    {
      glVertexArraySecondaryColorOffsetEXT del = (glVertexArraySecondaryColorOffsetEXT)GetProc<glVertexArraySecondaryColorOffsetEXT>();
      del(vaobj, buffer, size, type, stride, offset);
    }

    public static void VertexArrayTexCoordOffsetEXT(uint vaobj, uint buffer, int size, uint type, int stride, IntPtr offset)
    {
      glVertexArrayTexCoordOffsetEXT del = (glVertexArrayTexCoordOffsetEXT)GetProc<glVertexArrayTexCoordOffsetEXT>();
      del(vaobj, buffer, size, type, stride, offset);
    }

    public static void VertexArrayVertexAttribBindingEXT(uint vaobj, uint attribindex, uint bindingindex)
    {
      glVertexArrayVertexAttribBindingEXT del = (glVertexArrayVertexAttribBindingEXT)GetProc<glVertexArrayVertexAttribBindingEXT>();
      del(vaobj, attribindex, bindingindex);
    }

    public static void VertexArrayVertexAttribDivisorEXT(uint vaobj, uint index, uint divisor)
    {
      glVertexArrayVertexAttribDivisorEXT del = (glVertexArrayVertexAttribDivisorEXT)GetProc<glVertexArrayVertexAttribDivisorEXT>();
      del(vaobj, index, divisor);
    }

    public static void VertexArrayVertexAttribFormatEXT(uint vaobj, uint attribindex, int size, uint type, bool normalized, uint relativeoffset)
    {
      glVertexArrayVertexAttribFormatEXT del = (glVertexArrayVertexAttribFormatEXT)GetProc<glVertexArrayVertexAttribFormatEXT>();
      del(vaobj, attribindex, size, type, normalized, relativeoffset);
    }

    public static void VertexArrayVertexAttribIFormatEXT(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset)
    {
      glVertexArrayVertexAttribIFormatEXT del = (glVertexArrayVertexAttribIFormatEXT)GetProc<glVertexArrayVertexAttribIFormatEXT>();
      del(vaobj, attribindex, size, type, relativeoffset);
    }

    public static void VertexArrayVertexAttribIOffsetEXT(uint vaobj, uint buffer, uint index, int size, uint type, int stride, IntPtr offset)
    {
      glVertexArrayVertexAttribIOffsetEXT del = (glVertexArrayVertexAttribIOffsetEXT)GetProc<glVertexArrayVertexAttribIOffsetEXT>();
      del(vaobj, buffer, index, size, type, stride, offset);
    }

    public static void VertexArrayVertexAttribLFormatEXT(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset)
    {
      glVertexArrayVertexAttribLFormatEXT del = (glVertexArrayVertexAttribLFormatEXT)GetProc<glVertexArrayVertexAttribLFormatEXT>();
      del(vaobj, attribindex, size, type, relativeoffset);
    }

    public static void VertexArrayVertexAttribLOffsetEXT(uint vaobj, uint buffer, uint index, int size, uint type, int stride, IntPtr offset)
    {
      glVertexArrayVertexAttribLOffsetEXT del = (glVertexArrayVertexAttribLOffsetEXT)GetProc<glVertexArrayVertexAttribLOffsetEXT>();
      del(vaobj, buffer, index, size, type, stride, offset);
    }

    public static void VertexArrayVertexAttribOffsetEXT(uint vaobj, uint buffer, uint index, int size, uint type, bool normalized, int stride, IntPtr offset)
    {
      glVertexArrayVertexAttribOffsetEXT del = (glVertexArrayVertexAttribOffsetEXT)GetProc<glVertexArrayVertexAttribOffsetEXT>();
      del(vaobj, buffer, index, size, type, normalized, stride, offset);
    }

    public static void VertexArrayVertexBindingDivisorEXT(uint vaobj, uint bindingindex, uint divisor)
    {
      glVertexArrayVertexBindingDivisorEXT del = (glVertexArrayVertexBindingDivisorEXT)GetProc<glVertexArrayVertexBindingDivisorEXT>();
      del(vaobj, bindingindex, divisor);
    }

    public static void VertexArrayVertexOffsetEXT(uint vaobj, uint buffer, int size, uint type, int stride, IntPtr offset)
    {
      glVertexArrayVertexOffsetEXT del = (glVertexArrayVertexOffsetEXT)GetProc<glVertexArrayVertexOffsetEXT>();
      del(vaobj, buffer, size, type, stride, offset);
    }

    public static void VertexAttrib1d(uint index, double x)
    {
      glVertexAttrib1d del = (glVertexAttrib1d)GetProc<glVertexAttrib1d>();
      del(index, x);
    }

    public static void VertexAttrib1dARB(uint index, double x)
    {
      glVertexAttrib1dARB del = (glVertexAttrib1dARB)GetProc<glVertexAttrib1dARB>();
      del(index, x);
    }

    public static void VertexAttrib1dNV(uint index, double x)
    {
      glVertexAttrib1dNV del = (glVertexAttrib1dNV)GetProc<glVertexAttrib1dNV>();
      del(index, x);
    }

    public static void VertexAttrib1dv(uint index, ref double[] v)
    {
      glVertexAttrib1dv del = (glVertexAttrib1dv)GetProc<glVertexAttrib1dv>();
      del(index, ref v);
    }

    public static void VertexAttrib1dvARB(uint index, ref double[] v)
    {
      glVertexAttrib1dvARB del = (glVertexAttrib1dvARB)GetProc<glVertexAttrib1dvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib1dvNV(uint index, ref double[] v)
    {
      glVertexAttrib1dvNV del = (glVertexAttrib1dvNV)GetProc<glVertexAttrib1dvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib1f(uint index, float x)
    {
      glVertexAttrib1f del = (glVertexAttrib1f)GetProc<glVertexAttrib1f>();
      del(index, x);
    }

    public static void VertexAttrib1fARB(uint index, float x)
    {
      glVertexAttrib1fARB del = (glVertexAttrib1fARB)GetProc<glVertexAttrib1fARB>();
      del(index, x);
    }

    public static void VertexAttrib1fNV(uint index, float x)
    {
      glVertexAttrib1fNV del = (glVertexAttrib1fNV)GetProc<glVertexAttrib1fNV>();
      del(index, x);
    }

    public static void VertexAttrib1fv(uint index, ref float[] v)
    {
      glVertexAttrib1fv del = (glVertexAttrib1fv)GetProc<glVertexAttrib1fv>();
      del(index, ref v);
    }

    public static void VertexAttrib1fvARB(uint index, ref float[] v)
    {
      glVertexAttrib1fvARB del = (glVertexAttrib1fvARB)GetProc<glVertexAttrib1fvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib1fvNV(uint index, ref float[] v)
    {
      glVertexAttrib1fvNV del = (glVertexAttrib1fvNV)GetProc<glVertexAttrib1fvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib1hNV(uint index, ushort x)
    {
      glVertexAttrib1hNV del = (glVertexAttrib1hNV)GetProc<glVertexAttrib1hNV>();
      del(index, x);
    }

    public static void VertexAttrib1hvNV(uint index, ref ushort[] v)
    {
      glVertexAttrib1hvNV del = (glVertexAttrib1hvNV)GetProc<glVertexAttrib1hvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib1s(uint index, short x)
    {
      glVertexAttrib1s del = (glVertexAttrib1s)GetProc<glVertexAttrib1s>();
      del(index, x);
    }

    public static void VertexAttrib1sARB(uint index, short x)
    {
      glVertexAttrib1sARB del = (glVertexAttrib1sARB)GetProc<glVertexAttrib1sARB>();
      del(index, x);
    }

    public static void VertexAttrib1sNV(uint index, short x)
    {
      glVertexAttrib1sNV del = (glVertexAttrib1sNV)GetProc<glVertexAttrib1sNV>();
      del(index, x);
    }

    public static void VertexAttrib1sv(uint index, ref short[] v)
    {
      glVertexAttrib1sv del = (glVertexAttrib1sv)GetProc<glVertexAttrib1sv>();
      del(index, ref v);
    }

    public static void VertexAttrib1svARB(uint index, ref short[] v)
    {
      glVertexAttrib1svARB del = (glVertexAttrib1svARB)GetProc<glVertexAttrib1svARB>();
      del(index, ref v);
    }

    public static void VertexAttrib1svNV(uint index, ref short[] v)
    {
      glVertexAttrib1svNV del = (glVertexAttrib1svNV)GetProc<glVertexAttrib1svNV>();
      del(index, ref v);
    }

    public static void VertexAttrib2d(uint index, double x, double y)
    {
      glVertexAttrib2d del = (glVertexAttrib2d)GetProc<glVertexAttrib2d>();
      del(index, x, y);
    }

    public static void VertexAttrib2dARB(uint index, double x, double y)
    {
      glVertexAttrib2dARB del = (glVertexAttrib2dARB)GetProc<glVertexAttrib2dARB>();
      del(index, x, y);
    }

    public static void VertexAttrib2dNV(uint index, double x, double y)
    {
      glVertexAttrib2dNV del = (glVertexAttrib2dNV)GetProc<glVertexAttrib2dNV>();
      del(index, x, y);
    }

    public static void VertexAttrib2dv(uint index, ref double[] v)
    {
      glVertexAttrib2dv del = (glVertexAttrib2dv)GetProc<glVertexAttrib2dv>();
      del(index, ref v);
    }

    public static void VertexAttrib2dvARB(uint index, ref double[] v)
    {
      glVertexAttrib2dvARB del = (glVertexAttrib2dvARB)GetProc<glVertexAttrib2dvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib2dvNV(uint index, ref double[] v)
    {
      glVertexAttrib2dvNV del = (glVertexAttrib2dvNV)GetProc<glVertexAttrib2dvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib2f(uint index, float x, float y)
    {
      glVertexAttrib2f del = (glVertexAttrib2f)GetProc<glVertexAttrib2f>();
      del(index, x, y);
    }

    public static void VertexAttrib2fARB(uint index, float x, float y)
    {
      glVertexAttrib2fARB del = (glVertexAttrib2fARB)GetProc<glVertexAttrib2fARB>();
      del(index, x, y);
    }

    public static void VertexAttrib2fNV(uint index, float x, float y)
    {
      glVertexAttrib2fNV del = (glVertexAttrib2fNV)GetProc<glVertexAttrib2fNV>();
      del(index, x, y);
    }

    public static void VertexAttrib2fv(uint index, ref float[] v)
    {
      glVertexAttrib2fv del = (glVertexAttrib2fv)GetProc<glVertexAttrib2fv>();
      del(index, ref v);
    }

    public static void VertexAttrib2fvARB(uint index, ref float[] v)
    {
      glVertexAttrib2fvARB del = (glVertexAttrib2fvARB)GetProc<glVertexAttrib2fvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib2fvNV(uint index, ref float[] v)
    {
      glVertexAttrib2fvNV del = (glVertexAttrib2fvNV)GetProc<glVertexAttrib2fvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib2hNV(uint index, ushort x, ushort y)
    {
      glVertexAttrib2hNV del = (glVertexAttrib2hNV)GetProc<glVertexAttrib2hNV>();
      del(index, x, y);
    }

    public static void VertexAttrib2hvNV(uint index, ref ushort[] v)
    {
      glVertexAttrib2hvNV del = (glVertexAttrib2hvNV)GetProc<glVertexAttrib2hvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib2s(uint index, short x, short y)
    {
      glVertexAttrib2s del = (glVertexAttrib2s)GetProc<glVertexAttrib2s>();
      del(index, x, y);
    }

    public static void VertexAttrib2sARB(uint index, short x, short y)
    {
      glVertexAttrib2sARB del = (glVertexAttrib2sARB)GetProc<glVertexAttrib2sARB>();
      del(index, x, y);
    }

    public static void VertexAttrib2sNV(uint index, short x, short y)
    {
      glVertexAttrib2sNV del = (glVertexAttrib2sNV)GetProc<glVertexAttrib2sNV>();
      del(index, x, y);
    }

    public static void VertexAttrib2sv(uint index, ref short[] v)
    {
      glVertexAttrib2sv del = (glVertexAttrib2sv)GetProc<glVertexAttrib2sv>();
      del(index, ref v);
    }

    public static void VertexAttrib2svARB(uint index, ref short[] v)
    {
      glVertexAttrib2svARB del = (glVertexAttrib2svARB)GetProc<glVertexAttrib2svARB>();
      del(index, ref v);
    }

    public static void VertexAttrib2svNV(uint index, ref short[] v)
    {
      glVertexAttrib2svNV del = (glVertexAttrib2svNV)GetProc<glVertexAttrib2svNV>();
      del(index, ref v);
    }

    public static void VertexAttrib3d(uint index, double x, double y, double z)
    {
      glVertexAttrib3d del = (glVertexAttrib3d)GetProc<glVertexAttrib3d>();
      del(index, x, y, z);
    }

    public static void VertexAttrib3dARB(uint index, double x, double y, double z)
    {
      glVertexAttrib3dARB del = (glVertexAttrib3dARB)GetProc<glVertexAttrib3dARB>();
      del(index, x, y, z);
    }

    public static void VertexAttrib3dNV(uint index, double x, double y, double z)
    {
      glVertexAttrib3dNV del = (glVertexAttrib3dNV)GetProc<glVertexAttrib3dNV>();
      del(index, x, y, z);
    }

    public static void VertexAttrib3dv(uint index, ref double[] v)
    {
      glVertexAttrib3dv del = (glVertexAttrib3dv)GetProc<glVertexAttrib3dv>();
      del(index, ref v);
    }

    public static void VertexAttrib3dvARB(uint index, ref double[] v)
    {
      glVertexAttrib3dvARB del = (glVertexAttrib3dvARB)GetProc<glVertexAttrib3dvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib3dvNV(uint index, ref double[] v)
    {
      glVertexAttrib3dvNV del = (glVertexAttrib3dvNV)GetProc<glVertexAttrib3dvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib3f(uint index, float x, float y, float z)
    {
      glVertexAttrib3f del = (glVertexAttrib3f)GetProc<glVertexAttrib3f>();
      del(index, x, y, z);
    }

    public static void VertexAttrib3fARB(uint index, float x, float y, float z)
    {
      glVertexAttrib3fARB del = (glVertexAttrib3fARB)GetProc<glVertexAttrib3fARB>();
      del(index, x, y, z);
    }

    public static void VertexAttrib3fNV(uint index, float x, float y, float z)
    {
      glVertexAttrib3fNV del = (glVertexAttrib3fNV)GetProc<glVertexAttrib3fNV>();
      del(index, x, y, z);
    }

    public static void VertexAttrib3fv(uint index, ref float[] v)
    {
      glVertexAttrib3fv del = (glVertexAttrib3fv)GetProc<glVertexAttrib3fv>();
      del(index, ref v);
    }

    public static void VertexAttrib3fvARB(uint index, ref float[] v)
    {
      glVertexAttrib3fvARB del = (glVertexAttrib3fvARB)GetProc<glVertexAttrib3fvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib3fvNV(uint index, ref float[] v)
    {
      glVertexAttrib3fvNV del = (glVertexAttrib3fvNV)GetProc<glVertexAttrib3fvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib3hNV(uint index, ushort x, ushort y, ushort z)
    {
      glVertexAttrib3hNV del = (glVertexAttrib3hNV)GetProc<glVertexAttrib3hNV>();
      del(index, x, y, z);
    }

    public static void VertexAttrib3hvNV(uint index, ref ushort[] v)
    {
      glVertexAttrib3hvNV del = (glVertexAttrib3hvNV)GetProc<glVertexAttrib3hvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib3s(uint index, short x, short y, short z)
    {
      glVertexAttrib3s del = (glVertexAttrib3s)GetProc<glVertexAttrib3s>();
      del(index, x, y, z);
    }

    public static void VertexAttrib3sARB(uint index, short x, short y, short z)
    {
      glVertexAttrib3sARB del = (glVertexAttrib3sARB)GetProc<glVertexAttrib3sARB>();
      del(index, x, y, z);
    }

    public static void VertexAttrib3sNV(uint index, short x, short y, short z)
    {
      glVertexAttrib3sNV del = (glVertexAttrib3sNV)GetProc<glVertexAttrib3sNV>();
      del(index, x, y, z);
    }

    public static void VertexAttrib3sv(uint index, ref short[] v)
    {
      glVertexAttrib3sv del = (glVertexAttrib3sv)GetProc<glVertexAttrib3sv>();
      del(index, ref v);
    }

    public static void VertexAttrib3svARB(uint index, ref short[] v)
    {
      glVertexAttrib3svARB del = (glVertexAttrib3svARB)GetProc<glVertexAttrib3svARB>();
      del(index, ref v);
    }

    public static void VertexAttrib3svNV(uint index, ref short[] v)
    {
      glVertexAttrib3svNV del = (glVertexAttrib3svNV)GetProc<glVertexAttrib3svNV>();
      del(index, ref v);
    }

    public static void VertexAttrib4bv(uint index, ref sbyte[] v)
    {
      glVertexAttrib4bv del = (glVertexAttrib4bv)GetProc<glVertexAttrib4bv>();
      del(index, ref v);
    }

    public static void VertexAttrib4bvARB(uint index, ref sbyte[] v)
    {
      glVertexAttrib4bvARB del = (glVertexAttrib4bvARB)GetProc<glVertexAttrib4bvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4d(uint index, double x, double y, double z, double w)
    {
      glVertexAttrib4d del = (glVertexAttrib4d)GetProc<glVertexAttrib4d>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4dARB(uint index, double x, double y, double z, double w)
    {
      glVertexAttrib4dARB del = (glVertexAttrib4dARB)GetProc<glVertexAttrib4dARB>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4dNV(uint index, double x, double y, double z, double w)
    {
      glVertexAttrib4dNV del = (glVertexAttrib4dNV)GetProc<glVertexAttrib4dNV>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4dv(uint index, ref double[] v)
    {
      glVertexAttrib4dv del = (glVertexAttrib4dv)GetProc<glVertexAttrib4dv>();
      del(index, ref v);
    }

    public static void VertexAttrib4dvARB(uint index, ref double[] v)
    {
      glVertexAttrib4dvARB del = (glVertexAttrib4dvARB)GetProc<glVertexAttrib4dvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4dvNV(uint index, ref double[] v)
    {
      glVertexAttrib4dvNV del = (glVertexAttrib4dvNV)GetProc<glVertexAttrib4dvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib4f(uint index, float x, float y, float z, float w)
    {
      glVertexAttrib4f del = (glVertexAttrib4f)GetProc<glVertexAttrib4f>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4fARB(uint index, float x, float y, float z, float w)
    {
      glVertexAttrib4fARB del = (glVertexAttrib4fARB)GetProc<glVertexAttrib4fARB>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4fNV(uint index, float x, float y, float z, float w)
    {
      glVertexAttrib4fNV del = (glVertexAttrib4fNV)GetProc<glVertexAttrib4fNV>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4fv(uint index, ref float[] v)
    {
      glVertexAttrib4fv del = (glVertexAttrib4fv)GetProc<glVertexAttrib4fv>();
      del(index, ref v);
    }

    public static void VertexAttrib4fvARB(uint index, ref float[] v)
    {
      glVertexAttrib4fvARB del = (glVertexAttrib4fvARB)GetProc<glVertexAttrib4fvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4fvNV(uint index, ref float[] v)
    {
      glVertexAttrib4fvNV del = (glVertexAttrib4fvNV)GetProc<glVertexAttrib4fvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib4hNV(uint index, ushort x, ushort y, ushort z, ushort w)
    {
      glVertexAttrib4hNV del = (glVertexAttrib4hNV)GetProc<glVertexAttrib4hNV>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4hvNV(uint index, ref ushort[] v)
    {
      glVertexAttrib4hvNV del = (glVertexAttrib4hvNV)GetProc<glVertexAttrib4hvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib4iv(uint index, ref int[] v)
    {
      glVertexAttrib4iv del = (glVertexAttrib4iv)GetProc<glVertexAttrib4iv>();
      del(index, ref v);
    }

    public static void VertexAttrib4ivARB(uint index, ref int[] v)
    {
      glVertexAttrib4ivARB del = (glVertexAttrib4ivARB)GetProc<glVertexAttrib4ivARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4Nbv(uint index, ref sbyte[] v)
    {
      glVertexAttrib4Nbv del = (glVertexAttrib4Nbv)GetProc<glVertexAttrib4Nbv>();
      del(index, ref v);
    }

    public static void VertexAttrib4NbvARB(uint index, ref sbyte[] v)
    {
      glVertexAttrib4NbvARB del = (glVertexAttrib4NbvARB)GetProc<glVertexAttrib4NbvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4Niv(uint index, ref int[] v)
    {
      glVertexAttrib4Niv del = (glVertexAttrib4Niv)GetProc<glVertexAttrib4Niv>();
      del(index, ref v);
    }

    public static void VertexAttrib4NivARB(uint index, ref int[] v)
    {
      glVertexAttrib4NivARB del = (glVertexAttrib4NivARB)GetProc<glVertexAttrib4NivARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4Nsv(uint index, ref short[] v)
    {
      glVertexAttrib4Nsv del = (glVertexAttrib4Nsv)GetProc<glVertexAttrib4Nsv>();
      del(index, ref v);
    }

    public static void VertexAttrib4NsvARB(uint index, ref short[] v)
    {
      glVertexAttrib4NsvARB del = (glVertexAttrib4NsvARB)GetProc<glVertexAttrib4NsvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w)
    {
      glVertexAttrib4Nub del = (glVertexAttrib4Nub)GetProc<glVertexAttrib4Nub>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4NubARB(uint index, byte x, byte y, byte z, byte w)
    {
      glVertexAttrib4NubARB del = (glVertexAttrib4NubARB)GetProc<glVertexAttrib4NubARB>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4Nubv(uint index, ref byte[] v)
    {
      glVertexAttrib4Nubv del = (glVertexAttrib4Nubv)GetProc<glVertexAttrib4Nubv>();
      del(index, ref v);
    }

    public static void VertexAttrib4NubvARB(uint index, ref byte[] v)
    {
      glVertexAttrib4NubvARB del = (glVertexAttrib4NubvARB)GetProc<glVertexAttrib4NubvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4Nuiv(uint index, ref uint[] v)
    {
      glVertexAttrib4Nuiv del = (glVertexAttrib4Nuiv)GetProc<glVertexAttrib4Nuiv>();
      del(index, ref v);
    }

    public static void VertexAttrib4NuivARB(uint index, ref uint[] v)
    {
      glVertexAttrib4NuivARB del = (glVertexAttrib4NuivARB)GetProc<glVertexAttrib4NuivARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4Nusv(uint index, ref ushort[] v)
    {
      glVertexAttrib4Nusv del = (glVertexAttrib4Nusv)GetProc<glVertexAttrib4Nusv>();
      del(index, ref v);
    }

    public static void VertexAttrib4NusvARB(uint index, ref ushort[] v)
    {
      glVertexAttrib4NusvARB del = (glVertexAttrib4NusvARB)GetProc<glVertexAttrib4NusvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4s(uint index, short x, short y, short z, short w)
    {
      glVertexAttrib4s del = (glVertexAttrib4s)GetProc<glVertexAttrib4s>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4sARB(uint index, short x, short y, short z, short w)
    {
      glVertexAttrib4sARB del = (glVertexAttrib4sARB)GetProc<glVertexAttrib4sARB>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4sNV(uint index, short x, short y, short z, short w)
    {
      glVertexAttrib4sNV del = (glVertexAttrib4sNV)GetProc<glVertexAttrib4sNV>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4sv(uint index, ref short[] v)
    {
      glVertexAttrib4sv del = (glVertexAttrib4sv)GetProc<glVertexAttrib4sv>();
      del(index, ref v);
    }

    public static void VertexAttrib4svARB(uint index, ref short[] v)
    {
      glVertexAttrib4svARB del = (glVertexAttrib4svARB)GetProc<glVertexAttrib4svARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4svNV(uint index, ref short[] v)
    {
      glVertexAttrib4svNV del = (glVertexAttrib4svNV)GetProc<glVertexAttrib4svNV>();
      del(index, ref v);
    }

    public static void VertexAttrib4ubNV(uint index, byte x, byte y, byte z, byte w)
    {
      glVertexAttrib4ubNV del = (glVertexAttrib4ubNV)GetProc<glVertexAttrib4ubNV>();
      del(index, x, y, z, w);
    }

    public static void VertexAttrib4ubv(uint index, ref byte[] v)
    {
      glVertexAttrib4ubv del = (glVertexAttrib4ubv)GetProc<glVertexAttrib4ubv>();
      del(index, ref v);
    }

    public static void VertexAttrib4ubvARB(uint index, ref byte[] v)
    {
      glVertexAttrib4ubvARB del = (glVertexAttrib4ubvARB)GetProc<glVertexAttrib4ubvARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4ubvNV(uint index, ref byte[] v)
    {
      glVertexAttrib4ubvNV del = (glVertexAttrib4ubvNV)GetProc<glVertexAttrib4ubvNV>();
      del(index, ref v);
    }

    public static void VertexAttrib4uiv(uint index, ref uint[] v)
    {
      glVertexAttrib4uiv del = (glVertexAttrib4uiv)GetProc<glVertexAttrib4uiv>();
      del(index, ref v);
    }

    public static void VertexAttrib4uivARB(uint index, ref uint[] v)
    {
      glVertexAttrib4uivARB del = (glVertexAttrib4uivARB)GetProc<glVertexAttrib4uivARB>();
      del(index, ref v);
    }

    public static void VertexAttrib4usv(uint index, ref ushort[] v)
    {
      glVertexAttrib4usv del = (glVertexAttrib4usv)GetProc<glVertexAttrib4usv>();
      del(index, ref v);
    }

    public static void VertexAttrib4usvARB(uint index, ref ushort[] v)
    {
      glVertexAttrib4usvARB del = (glVertexAttrib4usvARB)GetProc<glVertexAttrib4usvARB>();
      del(index, ref v);
    }

    public static void VertexAttribArrayObjectATI(uint index, int size, uint type, bool normalized, int stride, uint buffer, uint offset)
    {
      glVertexAttribArrayObjectATI del = (glVertexAttribArrayObjectATI)GetProc<glVertexAttribArrayObjectATI>();
      del(index, size, type, normalized, stride, buffer, offset);
    }

    public static void VertexAttribBinding(uint attribindex, uint bindingindex)
    {
      glVertexAttribBinding del = (glVertexAttribBinding)GetProc<glVertexAttribBinding>();
      del(attribindex, bindingindex);
    }

    public static void VertexAttribDivisor(uint index, uint divisor)
    {
      glVertexAttribDivisor del = (glVertexAttribDivisor)GetProc<glVertexAttribDivisor>();
      del(index, divisor);
    }

    public static void VertexAttribDivisorARB(uint index, uint divisor)
    {
      glVertexAttribDivisorARB del = (glVertexAttribDivisorARB)GetProc<glVertexAttribDivisorARB>();
      del(index, divisor);
    }

    public static void VertexAttribFormat(uint attribindex, int size, uint type, bool normalized, uint relativeoffset)
    {
      glVertexAttribFormat del = (glVertexAttribFormat)GetProc<glVertexAttribFormat>();
      del(attribindex, size, type, normalized, relativeoffset);
    }

    public static void VertexAttribFormatNV(uint index, int size, uint type, bool normalized, int stride)
    {
      glVertexAttribFormatNV del = (glVertexAttribFormatNV)GetProc<glVertexAttribFormatNV>();
      del(index, size, type, normalized, stride);
    }

    public static void VertexAttribI1i(uint index, int x)
    {
      glVertexAttribI1i del = (glVertexAttribI1i)GetProc<glVertexAttribI1i>();
      del(index, x);
    }

    public static void VertexAttribI1iEXT(uint index, int x)
    {
      glVertexAttribI1iEXT del = (glVertexAttribI1iEXT)GetProc<glVertexAttribI1iEXT>();
      del(index, x);
    }

    public static void VertexAttribI1iv(uint index, ref int[] v)
    {
      glVertexAttribI1iv del = (glVertexAttribI1iv)GetProc<glVertexAttribI1iv>();
      del(index, ref v);
    }

    public static void VertexAttribI1ivEXT(uint index, ref int[] v)
    {
      glVertexAttribI1ivEXT del = (glVertexAttribI1ivEXT)GetProc<glVertexAttribI1ivEXT>();
      del(index, ref v);
    }

    public static void VertexAttribI1ui(uint index, uint x)
    {
      glVertexAttribI1ui del = (glVertexAttribI1ui)GetProc<glVertexAttribI1ui>();
      del(index, x);
    }

    public static void VertexAttribI1uiEXT(uint index, uint x)
    {
      glVertexAttribI1uiEXT del = (glVertexAttribI1uiEXT)GetProc<glVertexAttribI1uiEXT>();
      del(index, x);
    }

    public static void VertexAttribI1uiv(uint index, ref uint[] v)
    {
      glVertexAttribI1uiv del = (glVertexAttribI1uiv)GetProc<glVertexAttribI1uiv>();
      del(index, ref v);
    }

    public static void VertexAttribI1uivEXT(uint index, ref uint[] v)
    {
      glVertexAttribI1uivEXT del = (glVertexAttribI1uivEXT)GetProc<glVertexAttribI1uivEXT>();
      del(index, ref v);
    }

    public static void VertexAttribI2i(uint index, int x, int y)
    {
      glVertexAttribI2i del = (glVertexAttribI2i)GetProc<glVertexAttribI2i>();
      del(index, x, y);
    }

    public static void VertexAttribI2iEXT(uint index, int x, int y)
    {
      glVertexAttribI2iEXT del = (glVertexAttribI2iEXT)GetProc<glVertexAttribI2iEXT>();
      del(index, x, y);
    }

    public static void VertexAttribI2iv(uint index, ref int[] v)
    {
      glVertexAttribI2iv del = (glVertexAttribI2iv)GetProc<glVertexAttribI2iv>();
      del(index, ref v);
    }

    public static void VertexAttribI2ivEXT(uint index, ref int[] v)
    {
      glVertexAttribI2ivEXT del = (glVertexAttribI2ivEXT)GetProc<glVertexAttribI2ivEXT>();
      del(index, ref v);
    }

    public static void VertexAttribI2ui(uint index, uint x, uint y)
    {
      glVertexAttribI2ui del = (glVertexAttribI2ui)GetProc<glVertexAttribI2ui>();
      del(index, x, y);
    }

    public static void VertexAttribI2uiEXT(uint index, uint x, uint y)
    {
      glVertexAttribI2uiEXT del = (glVertexAttribI2uiEXT)GetProc<glVertexAttribI2uiEXT>();
      del(index, x, y);
    }

    public static void VertexAttribI2uiv(uint index, ref uint[] v)
    {
      glVertexAttribI2uiv del = (glVertexAttribI2uiv)GetProc<glVertexAttribI2uiv>();
      del(index, ref v);
    }

    public static void VertexAttribI2uivEXT(uint index, ref uint[] v)
    {
      glVertexAttribI2uivEXT del = (glVertexAttribI2uivEXT)GetProc<glVertexAttribI2uivEXT>();
      del(index, ref v);
    }

    public static void VertexAttribI3i(uint index, int x, int y, int z)
    {
      glVertexAttribI3i del = (glVertexAttribI3i)GetProc<glVertexAttribI3i>();
      del(index, x, y, z);
    }

    public static void VertexAttribI3iEXT(uint index, int x, int y, int z)
    {
      glVertexAttribI3iEXT del = (glVertexAttribI3iEXT)GetProc<glVertexAttribI3iEXT>();
      del(index, x, y, z);
    }

    public static void VertexAttribI3iv(uint index, ref int[] v)
    {
      glVertexAttribI3iv del = (glVertexAttribI3iv)GetProc<glVertexAttribI3iv>();
      del(index, ref v);
    }

    public static void VertexAttribI3ivEXT(uint index, ref int[] v)
    {
      glVertexAttribI3ivEXT del = (glVertexAttribI3ivEXT)GetProc<glVertexAttribI3ivEXT>();
      del(index, ref v);
    }

    public static void VertexAttribI3ui(uint index, uint x, uint y, uint z)
    {
      glVertexAttribI3ui del = (glVertexAttribI3ui)GetProc<glVertexAttribI3ui>();
      del(index, x, y, z);
    }

    public static void VertexAttribI3uiEXT(uint index, uint x, uint y, uint z)
    {
      glVertexAttribI3uiEXT del = (glVertexAttribI3uiEXT)GetProc<glVertexAttribI3uiEXT>();
      del(index, x, y, z);
    }

    public static void VertexAttribI3uiv(uint index, ref uint[] v)
    {
      glVertexAttribI3uiv del = (glVertexAttribI3uiv)GetProc<glVertexAttribI3uiv>();
      del(index, ref v);
    }

    public static void VertexAttribI3uivEXT(uint index, ref uint[] v)
    {
      glVertexAttribI3uivEXT del = (glVertexAttribI3uivEXT)GetProc<glVertexAttribI3uivEXT>();
      del(index, ref v);
    }

    public static void VertexAttribI4bv(uint index, ref sbyte[] v)
    {
      glVertexAttribI4bv del = (glVertexAttribI4bv)GetProc<glVertexAttribI4bv>();
      del(index, ref v);
    }

    public static void VertexAttribI4bvEXT(uint index, ref sbyte[] v)
    {
      glVertexAttribI4bvEXT del = (glVertexAttribI4bvEXT)GetProc<glVertexAttribI4bvEXT>();
      del(index, ref v);
    }

    public static void VertexAttribI4i(uint index, int x, int y, int z, int w)
    {
      glVertexAttribI4i del = (glVertexAttribI4i)GetProc<glVertexAttribI4i>();
      del(index, x, y, z, w);
    }

    public static void VertexAttribI4iEXT(uint index, int x, int y, int z, int w)
    {
      glVertexAttribI4iEXT del = (glVertexAttribI4iEXT)GetProc<glVertexAttribI4iEXT>();
      del(index, x, y, z, w);
    }

    public static void VertexAttribI4iv(uint index, ref int[] v)
    {
      glVertexAttribI4iv del = (glVertexAttribI4iv)GetProc<glVertexAttribI4iv>();
      del(index, ref v);
    }

    public static void VertexAttribI4ivEXT(uint index, ref int[] v)
    {
      glVertexAttribI4ivEXT del = (glVertexAttribI4ivEXT)GetProc<glVertexAttribI4ivEXT>();
      del(index, ref v);
    }

    public static void VertexAttribI4sv(uint index, ref short[] v)
    {
      glVertexAttribI4sv del = (glVertexAttribI4sv)GetProc<glVertexAttribI4sv>();
      del(index, ref v);
    }

    public static void VertexAttribI4svEXT(uint index, ref short[] v)
    {
      glVertexAttribI4svEXT del = (glVertexAttribI4svEXT)GetProc<glVertexAttribI4svEXT>();
      del(index, ref v);
    }

    public static void VertexAttribI4ubv(uint index, ref byte[] v)
    {
      glVertexAttribI4ubv del = (glVertexAttribI4ubv)GetProc<glVertexAttribI4ubv>();
      del(index, ref v);
    }

    public static void VertexAttribI4ubvEXT(uint index, ref byte[] v)
    {
      glVertexAttribI4ubvEXT del = (glVertexAttribI4ubvEXT)GetProc<glVertexAttribI4ubvEXT>();
      del(index, ref v);
    }

    public static void VertexAttribI4ui(uint index, uint x, uint y, uint z, uint w)
    {
      glVertexAttribI4ui del = (glVertexAttribI4ui)GetProc<glVertexAttribI4ui>();
      del(index, x, y, z, w);
    }

    public static void VertexAttribI4uiEXT(uint index, uint x, uint y, uint z, uint w)
    {
      glVertexAttribI4uiEXT del = (glVertexAttribI4uiEXT)GetProc<glVertexAttribI4uiEXT>();
      del(index, x, y, z, w);
    }

    public static void VertexAttribI4uiv(uint index, ref uint[] v)
    {
      glVertexAttribI4uiv del = (glVertexAttribI4uiv)GetProc<glVertexAttribI4uiv>();
      del(index, ref v);
    }

    public static void VertexAttribI4uivEXT(uint index, ref uint[] v)
    {
      glVertexAttribI4uivEXT del = (glVertexAttribI4uivEXT)GetProc<glVertexAttribI4uivEXT>();
      del(index, ref v);
    }

    public static void VertexAttribI4usv(uint index, ref ushort[] v)
    {
      glVertexAttribI4usv del = (glVertexAttribI4usv)GetProc<glVertexAttribI4usv>();
      del(index, ref v);
    }

    public static void VertexAttribI4usvEXT(uint index, ref ushort[] v)
    {
      glVertexAttribI4usvEXT del = (glVertexAttribI4usvEXT)GetProc<glVertexAttribI4usvEXT>();
      del(index, ref v);
    }

    public static void VertexAttribIFormat(uint attribindex, int size, uint type, uint relativeoffset)
    {
      glVertexAttribIFormat del = (glVertexAttribIFormat)GetProc<glVertexAttribIFormat>();
      del(attribindex, size, type, relativeoffset);
    }

    public static void VertexAttribIFormatNV(uint index, int size, uint type, int stride)
    {
      glVertexAttribIFormatNV del = (glVertexAttribIFormatNV)GetProc<glVertexAttribIFormatNV>();
      del(index, size, type, stride);
    }

    public static void VertexAttribIPointer(uint index, int size, uint type, int stride, IntPtr pointer)
    {
      glVertexAttribIPointer del = (glVertexAttribIPointer)GetProc<glVertexAttribIPointer>();
      del(index, size, type, stride, pointer);
    }

    public static void VertexAttribIPointerEXT(uint index, int size, uint type, int stride, IntPtr pointer)
    {
      glVertexAttribIPointerEXT del = (glVertexAttribIPointerEXT)GetProc<glVertexAttribIPointerEXT>();
      del(index, size, type, stride, pointer);
    }

    public static void VertexAttribL1d(uint index, double x)
    {
      glVertexAttribL1d del = (glVertexAttribL1d)GetProc<glVertexAttribL1d>();
      del(index, x);
    }

    public static void VertexAttribL1dEXT(uint index, double x)
    {
      glVertexAttribL1dEXT del = (glVertexAttribL1dEXT)GetProc<glVertexAttribL1dEXT>();
      del(index, x);
    }

    public static void VertexAttribL1dv(uint index, ref double[] v)
    {
      glVertexAttribL1dv del = (glVertexAttribL1dv)GetProc<glVertexAttribL1dv>();
      del(index, ref v);
    }

    public static void VertexAttribL1dvEXT(uint index, ref double[] v)
    {
      glVertexAttribL1dvEXT del = (glVertexAttribL1dvEXT)GetProc<glVertexAttribL1dvEXT>();
      del(index, ref v);
    }

    public static void VertexAttribL1i64NV(uint index, long x)
    {
      glVertexAttribL1i64NV del = (glVertexAttribL1i64NV)GetProc<glVertexAttribL1i64NV>();
      del(index, x);
    }

    public static void VertexAttribL1i64vNV(uint index, ref long[] v)
    {
      glVertexAttribL1i64vNV del = (glVertexAttribL1i64vNV)GetProc<glVertexAttribL1i64vNV>();
      del(index, ref v);
    }

    public static void VertexAttribL1ui64ARB(uint index, ulong x)
    {
      glVertexAttribL1ui64ARB del = (glVertexAttribL1ui64ARB)GetProc<glVertexAttribL1ui64ARB>();
      del(index, x);
    }

    public static void VertexAttribL1ui64NV(uint index, ulong x)
    {
      glVertexAttribL1ui64NV del = (glVertexAttribL1ui64NV)GetProc<glVertexAttribL1ui64NV>();
      del(index, x);
    }

    public static void VertexAttribL1ui64vARB(uint index, ref ulong[] v)
    {
      glVertexAttribL1ui64vARB del = (glVertexAttribL1ui64vARB)GetProc<glVertexAttribL1ui64vARB>();
      del(index, ref v);
    }

    public static void VertexAttribL1ui64vNV(uint index, ref ulong[] v)
    {
      glVertexAttribL1ui64vNV del = (glVertexAttribL1ui64vNV)GetProc<glVertexAttribL1ui64vNV>();
      del(index, ref v);
    }

    public static void VertexAttribL2d(uint index, double x, double y)
    {
      glVertexAttribL2d del = (glVertexAttribL2d)GetProc<glVertexAttribL2d>();
      del(index, x, y);
    }

    public static void VertexAttribL2dEXT(uint index, double x, double y)
    {
      glVertexAttribL2dEXT del = (glVertexAttribL2dEXT)GetProc<glVertexAttribL2dEXT>();
      del(index, x, y);
    }

    public static void VertexAttribL2dv(uint index, ref double[] v)
    {
      glVertexAttribL2dv del = (glVertexAttribL2dv)GetProc<glVertexAttribL2dv>();
      del(index, ref v);
    }

    public static void VertexAttribL2dvEXT(uint index, ref double[] v)
    {
      glVertexAttribL2dvEXT del = (glVertexAttribL2dvEXT)GetProc<glVertexAttribL2dvEXT>();
      del(index, ref v);
    }

    public static void VertexAttribL2i64NV(uint index, long x, long y)
    {
      glVertexAttribL2i64NV del = (glVertexAttribL2i64NV)GetProc<glVertexAttribL2i64NV>();
      del(index, x, y);
    }

    public static void VertexAttribL2i64vNV(uint index, ref long[] v)
    {
      glVertexAttribL2i64vNV del = (glVertexAttribL2i64vNV)GetProc<glVertexAttribL2i64vNV>();
      del(index, ref v);
    }

    public static void VertexAttribL2ui64NV(uint index, ulong x, ulong y)
    {
      glVertexAttribL2ui64NV del = (glVertexAttribL2ui64NV)GetProc<glVertexAttribL2ui64NV>();
      del(index, x, y);
    }

    public static void VertexAttribL2ui64vNV(uint index, ref ulong[] v)
    {
      glVertexAttribL2ui64vNV del = (glVertexAttribL2ui64vNV)GetProc<glVertexAttribL2ui64vNV>();
      del(index, ref v);
    }

    public static void VertexAttribL3d(uint index, double x, double y, double z)
    {
      glVertexAttribL3d del = (glVertexAttribL3d)GetProc<glVertexAttribL3d>();
      del(index, x, y, z);
    }

    public static void VertexAttribL3dEXT(uint index, double x, double y, double z)
    {
      glVertexAttribL3dEXT del = (glVertexAttribL3dEXT)GetProc<glVertexAttribL3dEXT>();
      del(index, x, y, z);
    }

    public static void VertexAttribL3dv(uint index, ref double[] v)
    {
      glVertexAttribL3dv del = (glVertexAttribL3dv)GetProc<glVertexAttribL3dv>();
      del(index, ref v);
    }

    public static void VertexAttribL3dvEXT(uint index, ref double[] v)
    {
      glVertexAttribL3dvEXT del = (glVertexAttribL3dvEXT)GetProc<glVertexAttribL3dvEXT>();
      del(index, ref v);
    }

    public static void VertexAttribL3i64NV(uint index, long x, long y, long z)
    {
      glVertexAttribL3i64NV del = (glVertexAttribL3i64NV)GetProc<glVertexAttribL3i64NV>();
      del(index, x, y, z);
    }

    public static void VertexAttribL3i64vNV(uint index, ref long[] v)
    {
      glVertexAttribL3i64vNV del = (glVertexAttribL3i64vNV)GetProc<glVertexAttribL3i64vNV>();
      del(index, ref v);
    }

    public static void VertexAttribL3ui64NV(uint index, ulong x, ulong y, ulong z)
    {
      glVertexAttribL3ui64NV del = (glVertexAttribL3ui64NV)GetProc<glVertexAttribL3ui64NV>();
      del(index, x, y, z);
    }

    public static void VertexAttribL3ui64vNV(uint index, ref ulong[] v)
    {
      glVertexAttribL3ui64vNV del = (glVertexAttribL3ui64vNV)GetProc<glVertexAttribL3ui64vNV>();
      del(index, ref v);
    }

    public static void VertexAttribL4d(uint index, double x, double y, double z, double w)
    {
      glVertexAttribL4d del = (glVertexAttribL4d)GetProc<glVertexAttribL4d>();
      del(index, x, y, z, w);
    }

    public static void VertexAttribL4dEXT(uint index, double x, double y, double z, double w)
    {
      glVertexAttribL4dEXT del = (glVertexAttribL4dEXT)GetProc<glVertexAttribL4dEXT>();
      del(index, x, y, z, w);
    }

    public static void VertexAttribL4dv(uint index, ref double[] v)
    {
      glVertexAttribL4dv del = (glVertexAttribL4dv)GetProc<glVertexAttribL4dv>();
      del(index, ref v);
    }

    public static void VertexAttribL4dvEXT(uint index, ref double[] v)
    {
      glVertexAttribL4dvEXT del = (glVertexAttribL4dvEXT)GetProc<glVertexAttribL4dvEXT>();
      del(index, ref v);
    }

    public static void VertexAttribL4i64NV(uint index, long x, long y, long z, long w)
    {
      glVertexAttribL4i64NV del = (glVertexAttribL4i64NV)GetProc<glVertexAttribL4i64NV>();
      del(index, x, y, z, w);
    }

    public static void VertexAttribL4i64vNV(uint index, ref long[] v)
    {
      glVertexAttribL4i64vNV del = (glVertexAttribL4i64vNV)GetProc<glVertexAttribL4i64vNV>();
      del(index, ref v);
    }

    public static void VertexAttribL4ui64NV(uint index, ulong x, ulong y, ulong z, ulong w)
    {
      glVertexAttribL4ui64NV del = (glVertexAttribL4ui64NV)GetProc<glVertexAttribL4ui64NV>();
      del(index, x, y, z, w);
    }

    public static void VertexAttribL4ui64vNV(uint index, ref ulong[] v)
    {
      glVertexAttribL4ui64vNV del = (glVertexAttribL4ui64vNV)GetProc<glVertexAttribL4ui64vNV>();
      del(index, ref v);
    }

    public static void VertexAttribLFormat(uint attribindex, int size, uint type, uint relativeoffset)
    {
      glVertexAttribLFormat del = (glVertexAttribLFormat)GetProc<glVertexAttribLFormat>();
      del(attribindex, size, type, relativeoffset);
    }

    public static void VertexAttribLFormatNV(uint index, int size, uint type, int stride)
    {
      glVertexAttribLFormatNV del = (glVertexAttribLFormatNV)GetProc<glVertexAttribLFormatNV>();
      del(index, size, type, stride);
    }

    public static void VertexAttribLPointer(uint index, int size, uint type, int stride, IntPtr pointer)
    {
      glVertexAttribLPointer del = (glVertexAttribLPointer)GetProc<glVertexAttribLPointer>();
      del(index, size, type, stride, pointer);
    }

    public static void VertexAttribLPointerEXT(uint index, int size, uint type, int stride, IntPtr pointer)
    {
      glVertexAttribLPointerEXT del = (glVertexAttribLPointerEXT)GetProc<glVertexAttribLPointerEXT>();
      del(index, size, type, stride, pointer);
    }

    public static void VertexAttribP1ui(uint index, uint type, bool normalized, uint value)
    {
      glVertexAttribP1ui del = (glVertexAttribP1ui)GetProc<glVertexAttribP1ui>();
      del(index, type, normalized, value);
    }

    public static void VertexAttribP1uiv(uint index, uint type, bool normalized, ref uint[] value)
    {
      glVertexAttribP1uiv del = (glVertexAttribP1uiv)GetProc<glVertexAttribP1uiv>();
      del(index, type, normalized, ref value);
    }

    public static void VertexAttribP2ui(uint index, uint type, bool normalized, uint value)
    {
      glVertexAttribP2ui del = (glVertexAttribP2ui)GetProc<glVertexAttribP2ui>();
      del(index, type, normalized, value);
    }

    public static void VertexAttribP2uiv(uint index, uint type, bool normalized, ref uint[] value)
    {
      glVertexAttribP2uiv del = (glVertexAttribP2uiv)GetProc<glVertexAttribP2uiv>();
      del(index, type, normalized, ref value);
    }

    public static void VertexAttribP3ui(uint index, uint type, bool normalized, uint value)
    {
      glVertexAttribP3ui del = (glVertexAttribP3ui)GetProc<glVertexAttribP3ui>();
      del(index, type, normalized, value);
    }

    public static void VertexAttribP3uiv(uint index, uint type, bool normalized, ref uint[] value)
    {
      glVertexAttribP3uiv del = (glVertexAttribP3uiv)GetProc<glVertexAttribP3uiv>();
      del(index, type, normalized, ref value);
    }

    public static void VertexAttribP4ui(uint index, uint type, bool normalized, uint value)
    {
      glVertexAttribP4ui del = (glVertexAttribP4ui)GetProc<glVertexAttribP4ui>();
      del(index, type, normalized, value);
    }

    public static void VertexAttribP4uiv(uint index, uint type, bool normalized, ref uint[] value)
    {
      glVertexAttribP4uiv del = (glVertexAttribP4uiv)GetProc<glVertexAttribP4uiv>();
      del(index, type, normalized, ref value);
    }

    public static void VertexAttribParameteriAMD(uint index, uint pname, int param)
    {
      glVertexAttribParameteriAMD del = (glVertexAttribParameteriAMD)GetProc<glVertexAttribParameteriAMD>();
      del(index, pname, param);
    }

    public static void VertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer)
    {
      glVertexAttribPointer del = (glVertexAttribPointer)GetProc<glVertexAttribPointer>();
      del(index, size, type, normalized, stride, pointer);
    }

    public static void VertexAttribPointerARB(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer)
    {
      glVertexAttribPointerARB del = (glVertexAttribPointerARB)GetProc<glVertexAttribPointerARB>();
      del(index, size, type, normalized, stride, pointer);
    }

    public static void VertexAttribPointerNV(uint index, int fsize, uint type, int stride, IntPtr pointer)
    {
      glVertexAttribPointerNV del = (glVertexAttribPointerNV)GetProc<glVertexAttribPointerNV>();
      del(index, fsize, type, stride, pointer);
    }

    public static void VertexAttribs1dvNV(uint index, int count, ref double[] v)
    {
      glVertexAttribs1dvNV del = (glVertexAttribs1dvNV)GetProc<glVertexAttribs1dvNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs1fvNV(uint index, int count, ref float[] v)
    {
      glVertexAttribs1fvNV del = (glVertexAttribs1fvNV)GetProc<glVertexAttribs1fvNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs1hvNV(uint index, int n, ref ushort[] v)
    {
      glVertexAttribs1hvNV del = (glVertexAttribs1hvNV)GetProc<glVertexAttribs1hvNV>();
      del(index, n, ref v);
    }

    public static void VertexAttribs1svNV(uint index, int count, ref short[] v)
    {
      glVertexAttribs1svNV del = (glVertexAttribs1svNV)GetProc<glVertexAttribs1svNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs2dvNV(uint index, int count, ref double[] v)
    {
      glVertexAttribs2dvNV del = (glVertexAttribs2dvNV)GetProc<glVertexAttribs2dvNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs2fvNV(uint index, int count, ref float[] v)
    {
      glVertexAttribs2fvNV del = (glVertexAttribs2fvNV)GetProc<glVertexAttribs2fvNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs2hvNV(uint index, int n, ref ushort[] v)
    {
      glVertexAttribs2hvNV del = (glVertexAttribs2hvNV)GetProc<glVertexAttribs2hvNV>();
      del(index, n, ref v);
    }

    public static void VertexAttribs2svNV(uint index, int count, ref short[] v)
    {
      glVertexAttribs2svNV del = (glVertexAttribs2svNV)GetProc<glVertexAttribs2svNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs3dvNV(uint index, int count, ref double[] v)
    {
      glVertexAttribs3dvNV del = (glVertexAttribs3dvNV)GetProc<glVertexAttribs3dvNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs3fvNV(uint index, int count, ref float[] v)
    {
      glVertexAttribs3fvNV del = (glVertexAttribs3fvNV)GetProc<glVertexAttribs3fvNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs3hvNV(uint index, int n, ref ushort[] v)
    {
      glVertexAttribs3hvNV del = (glVertexAttribs3hvNV)GetProc<glVertexAttribs3hvNV>();
      del(index, n, ref v);
    }

    public static void VertexAttribs3svNV(uint index, int count, ref short[] v)
    {
      glVertexAttribs3svNV del = (glVertexAttribs3svNV)GetProc<glVertexAttribs3svNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs4dvNV(uint index, int count, ref double[] v)
    {
      glVertexAttribs4dvNV del = (glVertexAttribs4dvNV)GetProc<glVertexAttribs4dvNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs4fvNV(uint index, int count, ref float[] v)
    {
      glVertexAttribs4fvNV del = (glVertexAttribs4fvNV)GetProc<glVertexAttribs4fvNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs4hvNV(uint index, int n, ref ushort[] v)
    {
      glVertexAttribs4hvNV del = (glVertexAttribs4hvNV)GetProc<glVertexAttribs4hvNV>();
      del(index, n, ref v);
    }

    public static void VertexAttribs4svNV(uint index, int count, ref short[] v)
    {
      glVertexAttribs4svNV del = (glVertexAttribs4svNV)GetProc<glVertexAttribs4svNV>();
      del(index, count, ref v);
    }

    public static void VertexAttribs4ubvNV(uint index, int count, ref byte[] v)
    {
      glVertexAttribs4ubvNV del = (glVertexAttribs4ubvNV)GetProc<glVertexAttribs4ubvNV>();
      del(index, count, ref v);
    }

    public static void VertexBindingDivisor(uint bindingindex, uint divisor)
    {
      glVertexBindingDivisor del = (glVertexBindingDivisor)GetProc<glVertexBindingDivisor>();
      del(bindingindex, divisor);
    }

    public static void VertexBlendARB(int count)
    {
      glVertexBlendARB del = (glVertexBlendARB)GetProc<glVertexBlendARB>();
      del(count);
    }

    public static void VertexBlendEnvfATI(uint pname, float param)
    {
      glVertexBlendEnvfATI del = (glVertexBlendEnvfATI)GetProc<glVertexBlendEnvfATI>();
      del(pname, param);
    }

    public static void VertexBlendEnviATI(uint pname, int param)
    {
      glVertexBlendEnviATI del = (glVertexBlendEnviATI)GetProc<glVertexBlendEnviATI>();
      del(pname, param);
    }

    public static void VertexFormatNV(int size, uint type, int stride)
    {
      glVertexFormatNV del = (glVertexFormatNV)GetProc<glVertexFormatNV>();
      del(size, type, stride);
    }

    public static void VertexP2ui(uint type, uint value)
    {
      glVertexP2ui del = (glVertexP2ui)GetProc<glVertexP2ui>();
      del(type, value);
    }

    public static void VertexP2uiv(uint type, ref uint[] value)
    {
      glVertexP2uiv del = (glVertexP2uiv)GetProc<glVertexP2uiv>();
      del(type, ref value);
    }

    public static void VertexP3ui(uint type, uint value)
    {
      glVertexP3ui del = (glVertexP3ui)GetProc<glVertexP3ui>();
      del(type, value);
    }

    public static void VertexP3uiv(uint type, ref uint[] value)
    {
      glVertexP3uiv del = (glVertexP3uiv)GetProc<glVertexP3uiv>();
      del(type, ref value);
    }

    public static void VertexP4ui(uint type, uint value)
    {
      glVertexP4ui del = (glVertexP4ui)GetProc<glVertexP4ui>();
      del(type, value);
    }

    public static void VertexP4uiv(uint type, ref uint[] value)
    {
      glVertexP4uiv del = (glVertexP4uiv)GetProc<glVertexP4uiv>();
      del(type, ref value);
    }

    public static void VertexPointerEXT(int size, uint type, int stride, int count, IntPtr pointer)
    {
      glVertexPointerEXT del = (glVertexPointerEXT)GetProc<glVertexPointerEXT>();
      del(size, type, stride, count, pointer);
    }

    public static void VertexPointerListIBM(int size, uint type, int stride, IntPtr pointer, int ptrstride)
    {
      glVertexPointerListIBM del = (glVertexPointerListIBM)GetProc<glVertexPointerListIBM>();
      del(size, type, stride, pointer, ptrstride);
    }

    public static void VertexPointervINTEL(int size, uint type, IntPtr pointer)
    {
      glVertexPointervINTEL del = (glVertexPointervINTEL)GetProc<glVertexPointervINTEL>();
      del(size, type, pointer);
    }

    public static void VertexStream1dATI(uint stream, double x)
    {
      glVertexStream1dATI del = (glVertexStream1dATI)GetProc<glVertexStream1dATI>();
      del(stream, x);
    }

    public static void VertexStream1dvATI(uint stream, ref double[] coords)
    {
      glVertexStream1dvATI del = (glVertexStream1dvATI)GetProc<glVertexStream1dvATI>();
      del(stream, ref coords);
    }

    public static void VertexStream1fATI(uint stream, float x)
    {
      glVertexStream1fATI del = (glVertexStream1fATI)GetProc<glVertexStream1fATI>();
      del(stream, x);
    }

    public static void VertexStream1fvATI(uint stream, ref float[] coords)
    {
      glVertexStream1fvATI del = (glVertexStream1fvATI)GetProc<glVertexStream1fvATI>();
      del(stream, ref coords);
    }

    public static void VertexStream1iATI(uint stream, int x)
    {
      glVertexStream1iATI del = (glVertexStream1iATI)GetProc<glVertexStream1iATI>();
      del(stream, x);
    }

    public static void VertexStream1ivATI(uint stream, ref int[] coords)
    {
      glVertexStream1ivATI del = (glVertexStream1ivATI)GetProc<glVertexStream1ivATI>();
      del(stream, ref coords);
    }

    public static void VertexStream1sATI(uint stream, short x)
    {
      glVertexStream1sATI del = (glVertexStream1sATI)GetProc<glVertexStream1sATI>();
      del(stream, x);
    }

    public static void VertexStream1svATI(uint stream, ref short[] coords)
    {
      glVertexStream1svATI del = (glVertexStream1svATI)GetProc<glVertexStream1svATI>();
      del(stream, ref coords);
    }

    public static void VertexStream2dATI(uint stream, double x, double y)
    {
      glVertexStream2dATI del = (glVertexStream2dATI)GetProc<glVertexStream2dATI>();
      del(stream, x, y);
    }

    public static void VertexStream2dvATI(uint stream, ref double[] coords)
    {
      glVertexStream2dvATI del = (glVertexStream2dvATI)GetProc<glVertexStream2dvATI>();
      del(stream, ref coords);
    }

    public static void VertexStream2fATI(uint stream, float x, float y)
    {
      glVertexStream2fATI del = (glVertexStream2fATI)GetProc<glVertexStream2fATI>();
      del(stream, x, y);
    }

    public static void VertexStream2fvATI(uint stream, ref float[] coords)
    {
      glVertexStream2fvATI del = (glVertexStream2fvATI)GetProc<glVertexStream2fvATI>();
      del(stream, ref coords);
    }

    public static void VertexStream2iATI(uint stream, int x, int y)
    {
      glVertexStream2iATI del = (glVertexStream2iATI)GetProc<glVertexStream2iATI>();
      del(stream, x, y);
    }

    public static void VertexStream2ivATI(uint stream, ref int[] coords)
    {
      glVertexStream2ivATI del = (glVertexStream2ivATI)GetProc<glVertexStream2ivATI>();
      del(stream, ref coords);
    }

    public static void VertexStream2sATI(uint stream, short x, short y)
    {
      glVertexStream2sATI del = (glVertexStream2sATI)GetProc<glVertexStream2sATI>();
      del(stream, x, y);
    }

    public static void VertexStream2svATI(uint stream, ref short[] coords)
    {
      glVertexStream2svATI del = (glVertexStream2svATI)GetProc<glVertexStream2svATI>();
      del(stream, ref coords);
    }

    public static void VertexStream3dATI(uint stream, double x, double y, double z)
    {
      glVertexStream3dATI del = (glVertexStream3dATI)GetProc<glVertexStream3dATI>();
      del(stream, x, y, z);
    }

    public static void VertexStream3dvATI(uint stream, ref double[] coords)
    {
      glVertexStream3dvATI del = (glVertexStream3dvATI)GetProc<glVertexStream3dvATI>();
      del(stream, ref coords);
    }

    public static void VertexStream3fATI(uint stream, float x, float y, float z)
    {
      glVertexStream3fATI del = (glVertexStream3fATI)GetProc<glVertexStream3fATI>();
      del(stream, x, y, z);
    }

    public static void VertexStream3fvATI(uint stream, ref float[] coords)
    {
      glVertexStream3fvATI del = (glVertexStream3fvATI)GetProc<glVertexStream3fvATI>();
      del(stream, ref coords);
    }

    public static void VertexStream3iATI(uint stream, int x, int y, int z)
    {
      glVertexStream3iATI del = (glVertexStream3iATI)GetProc<glVertexStream3iATI>();
      del(stream, x, y, z);
    }

    public static void VertexStream3ivATI(uint stream, ref int[] coords)
    {
      glVertexStream3ivATI del = (glVertexStream3ivATI)GetProc<glVertexStream3ivATI>();
      del(stream, ref coords);
    }

    public static void VertexStream3sATI(uint stream, short x, short y, short z)
    {
      glVertexStream3sATI del = (glVertexStream3sATI)GetProc<glVertexStream3sATI>();
      del(stream, x, y, z);
    }

    public static void VertexStream3svATI(uint stream, ref short[] coords)
    {
      glVertexStream3svATI del = (glVertexStream3svATI)GetProc<glVertexStream3svATI>();
      del(stream, ref coords);
    }

    public static void VertexStream4dATI(uint stream, double x, double y, double z, double w)
    {
      glVertexStream4dATI del = (glVertexStream4dATI)GetProc<glVertexStream4dATI>();
      del(stream, x, y, z, w);
    }

    public static void VertexStream4dvATI(uint stream, ref double[] coords)
    {
      glVertexStream4dvATI del = (glVertexStream4dvATI)GetProc<glVertexStream4dvATI>();
      del(stream, ref coords);
    }

    public static void VertexStream4fATI(uint stream, float x, float y, float z, float w)
    {
      glVertexStream4fATI del = (glVertexStream4fATI)GetProc<glVertexStream4fATI>();
      del(stream, x, y, z, w);
    }

    public static void VertexStream4fvATI(uint stream, ref float[] coords)
    {
      glVertexStream4fvATI del = (glVertexStream4fvATI)GetProc<glVertexStream4fvATI>();
      del(stream, ref coords);
    }

    public static void VertexStream4iATI(uint stream, int x, int y, int z, int w)
    {
      glVertexStream4iATI del = (glVertexStream4iATI)GetProc<glVertexStream4iATI>();
      del(stream, x, y, z, w);
    }

    public static void VertexStream4ivATI(uint stream, ref int[] coords)
    {
      glVertexStream4ivATI del = (glVertexStream4ivATI)GetProc<glVertexStream4ivATI>();
      del(stream, ref coords);
    }

    public static void VertexStream4sATI(uint stream, short x, short y, short z, short w)
    {
      glVertexStream4sATI del = (glVertexStream4sATI)GetProc<glVertexStream4sATI>();
      del(stream, x, y, z, w);
    }

    public static void VertexStream4svATI(uint stream, ref short[] coords)
    {
      glVertexStream4svATI del = (glVertexStream4svATI)GetProc<glVertexStream4svATI>();
      del(stream, ref coords);
    }

    public static void VertexWeightfEXT(float weight)
    {
      glVertexWeightfEXT del = (glVertexWeightfEXT)GetProc<glVertexWeightfEXT>();
      del(weight);
    }

    public static void VertexWeightfvEXT(ref float[] weight)
    {
      glVertexWeightfvEXT del = (glVertexWeightfvEXT)GetProc<glVertexWeightfvEXT>();
      del(ref weight);
    }

    public static void VertexWeighthNV(ushort weight)
    {
      glVertexWeighthNV del = (glVertexWeighthNV)GetProc<glVertexWeighthNV>();
      del(weight);
    }

    public static void VertexWeighthvNV(ref ushort[] weight)
    {
      glVertexWeighthvNV del = (glVertexWeighthvNV)GetProc<glVertexWeighthvNV>();
      del(ref weight);
    }

    public static void VertexWeightPointerEXT(int size, uint type, int stride, IntPtr pointer)
    {
      glVertexWeightPointerEXT del = (glVertexWeightPointerEXT)GetProc<glVertexWeightPointerEXT>();
      del(size, type, stride, pointer);
    }

    public static void VideoCaptureStreamParameterdvNV(uint video_capture_slot, uint stream, uint pname, ref double[] parameters)
    {
      glVideoCaptureStreamParameterdvNV del = (glVideoCaptureStreamParameterdvNV)GetProc<glVideoCaptureStreamParameterdvNV>();
      del(video_capture_slot, stream, pname, ref parameters);
    }

    public static void VideoCaptureStreamParameterfvNV(uint video_capture_slot, uint stream, uint pname, ref float[] parameters)
    {
      glVideoCaptureStreamParameterfvNV del = (glVideoCaptureStreamParameterfvNV)GetProc<glVideoCaptureStreamParameterfvNV>();
      del(video_capture_slot, stream, pname, ref parameters);
    }

    public static void VideoCaptureStreamParameterivNV(uint video_capture_slot, uint stream, uint pname, ref int[] parameters)
    {
      glVideoCaptureStreamParameterivNV del = (glVideoCaptureStreamParameterivNV)GetProc<glVideoCaptureStreamParameterivNV>();
      del(video_capture_slot, stream, pname, ref parameters);
    }

    public static void ViewportArrayv(uint first, int count, ref float[] v)
    {
      glViewportArrayv del = (glViewportArrayv)GetProc<glViewportArrayv>();
      del(first, count, ref v);
    }

    public static void ViewportIndexedf(uint index, float x, float y, float w, float h)
    {
      glViewportIndexedf del = (glViewportIndexedf)GetProc<glViewportIndexedf>();
      del(index, x, y, w, h);
    }

    public static void ViewportIndexedfv(uint index, ref float[] v)
    {
      glViewportIndexedfv del = (glViewportIndexedfv)GetProc<glViewportIndexedfv>();
      del(index, ref v);
    }

    public static void WaitSync(GLsync sync, uint flags, ulong timeout)
    {
      glWaitSync del = (glWaitSync)GetProc<glWaitSync>();
      del(sync, flags, timeout);
    }

    public static void WeightbvARB(int size, ref sbyte[] weights)
    {
      glWeightbvARB del = (glWeightbvARB)GetProc<glWeightbvARB>();
      del(size, ref weights);
    }

    public static void WeightdvARB(int size, ref double[] weights)
    {
      glWeightdvARB del = (glWeightdvARB)GetProc<glWeightdvARB>();
      del(size, ref weights);
    }

    public static void WeightfvARB(int size, ref float[] weights)
    {
      glWeightfvARB del = (glWeightfvARB)GetProc<glWeightfvARB>();
      del(size, ref weights);
    }

    public static void WeightivARB(int size, ref int[] weights)
    {
      glWeightivARB del = (glWeightivARB)GetProc<glWeightivARB>();
      del(size, ref weights);
    }

    public static void WeightPathsNV(uint resultPath, int numPaths, ref uint[] paths, ref float[] weights)
    {
      glWeightPathsNV del = (glWeightPathsNV)GetProc<glWeightPathsNV>();
      del(resultPath, numPaths, ref paths, ref weights);
    }

    public static void WeightPointerARB(int size, uint type, int stride, IntPtr pointer)
    {
      glWeightPointerARB del = (glWeightPointerARB)GetProc<glWeightPointerARB>();
      del(size, type, stride, pointer);
    }

    public static void WeightsvARB(int size, ref short[] weights)
    {
      glWeightsvARB del = (glWeightsvARB)GetProc<glWeightsvARB>();
      del(size, ref weights);
    }

    public static void WeightubvARB(int size, ref byte[] weights)
    {
      glWeightubvARB del = (glWeightubvARB)GetProc<glWeightubvARB>();
      del(size, ref weights);
    }

    public static void WeightuivARB(int size, ref uint[] weights)
    {
      glWeightuivARB del = (glWeightuivARB)GetProc<glWeightuivARB>();
      del(size, ref weights);
    }

    public static void WeightusvARB(int size, ref ushort[] weights)
    {
      glWeightusvARB del = (glWeightusvARB)GetProc<glWeightusvARB>();
      del(size, ref weights);
    }

    public static void WindowPos2d(double x, double y)
    {
      glWindowPos2d del = (glWindowPos2d)GetProc<glWindowPos2d>();
      del(x, y);
    }

    public static void WindowPos2dARB(double x, double y)
    {
      glWindowPos2dARB del = (glWindowPos2dARB)GetProc<glWindowPos2dARB>();
      del(x, y);
    }

    public static void WindowPos2dMESA(double x, double y)
    {
      glWindowPos2dMESA del = (glWindowPos2dMESA)GetProc<glWindowPos2dMESA>();
      del(x, y);
    }

    public static void WindowPos2dv(ref double[] v)
    {
      glWindowPos2dv del = (glWindowPos2dv)GetProc<glWindowPos2dv>();
      del(ref v);
    }

    public static void WindowPos2dvARB(ref double[] v)
    {
      glWindowPos2dvARB del = (glWindowPos2dvARB)GetProc<glWindowPos2dvARB>();
      del(ref v);
    }

    public static void WindowPos2dvMESA(ref double[] v)
    {
      glWindowPos2dvMESA del = (glWindowPos2dvMESA)GetProc<glWindowPos2dvMESA>();
      del(ref v);
    }

    public static void WindowPos2f(float x, float y)
    {
      glWindowPos2f del = (glWindowPos2f)GetProc<glWindowPos2f>();
      del(x, y);
    }

    public static void WindowPos2fARB(float x, float y)
    {
      glWindowPos2fARB del = (glWindowPos2fARB)GetProc<glWindowPos2fARB>();
      del(x, y);
    }

    public static void WindowPos2fMESA(float x, float y)
    {
      glWindowPos2fMESA del = (glWindowPos2fMESA)GetProc<glWindowPos2fMESA>();
      del(x, y);
    }

    public static void WindowPos2fv(ref float[] v)
    {
      glWindowPos2fv del = (glWindowPos2fv)GetProc<glWindowPos2fv>();
      del(ref v);
    }

    public static void WindowPos2fvARB(ref float[] v)
    {
      glWindowPos2fvARB del = (glWindowPos2fvARB)GetProc<glWindowPos2fvARB>();
      del(ref v);
    }

    public static void WindowPos2fvMESA(ref float[] v)
    {
      glWindowPos2fvMESA del = (glWindowPos2fvMESA)GetProc<glWindowPos2fvMESA>();
      del(ref v);
    }

    public static void WindowPos2i(int x, int y)
    {
      glWindowPos2i del = (glWindowPos2i)GetProc<glWindowPos2i>();
      del(x, y);
    }

    public static void WindowPos2iARB(int x, int y)
    {
      glWindowPos2iARB del = (glWindowPos2iARB)GetProc<glWindowPos2iARB>();
      del(x, y);
    }

    public static void WindowPos2iMESA(int x, int y)
    {
      glWindowPos2iMESA del = (glWindowPos2iMESA)GetProc<glWindowPos2iMESA>();
      del(x, y);
    }

    public static void WindowPos2iv(ref int[] v)
    {
      glWindowPos2iv del = (glWindowPos2iv)GetProc<glWindowPos2iv>();
      del(ref v);
    }

    public static void WindowPos2ivARB(ref int[] v)
    {
      glWindowPos2ivARB del = (glWindowPos2ivARB)GetProc<glWindowPos2ivARB>();
      del(ref v);
    }

    public static void WindowPos2ivMESA(ref int[] v)
    {
      glWindowPos2ivMESA del = (glWindowPos2ivMESA)GetProc<glWindowPos2ivMESA>();
      del(ref v);
    }

    public static void WindowPos2s(short x, short y)
    {
      glWindowPos2s del = (glWindowPos2s)GetProc<glWindowPos2s>();
      del(x, y);
    }

    public static void WindowPos2sARB(short x, short y)
    {
      glWindowPos2sARB del = (glWindowPos2sARB)GetProc<glWindowPos2sARB>();
      del(x, y);
    }

    public static void WindowPos2sMESA(short x, short y)
    {
      glWindowPos2sMESA del = (glWindowPos2sMESA)GetProc<glWindowPos2sMESA>();
      del(x, y);
    }

    public static void WindowPos2sv(ref short[] v)
    {
      glWindowPos2sv del = (glWindowPos2sv)GetProc<glWindowPos2sv>();
      del(ref v);
    }

    public static void WindowPos2svARB(ref short[] v)
    {
      glWindowPos2svARB del = (glWindowPos2svARB)GetProc<glWindowPos2svARB>();
      del(ref v);
    }

    public static void WindowPos2svMESA(ref short[] v)
    {
      glWindowPos2svMESA del = (glWindowPos2svMESA)GetProc<glWindowPos2svMESA>();
      del(ref v);
    }

    public static void WindowPos3d(double x, double y, double z)
    {
      glWindowPos3d del = (glWindowPos3d)GetProc<glWindowPos3d>();
      del(x, y, z);
    }

    public static void WindowPos3dARB(double x, double y, double z)
    {
      glWindowPos3dARB del = (glWindowPos3dARB)GetProc<glWindowPos3dARB>();
      del(x, y, z);
    }

    public static void WindowPos3dMESA(double x, double y, double z)
    {
      glWindowPos3dMESA del = (glWindowPos3dMESA)GetProc<glWindowPos3dMESA>();
      del(x, y, z);
    }

    public static void WindowPos3dv(ref double[] v)
    {
      glWindowPos3dv del = (glWindowPos3dv)GetProc<glWindowPos3dv>();
      del(ref v);
    }

    public static void WindowPos3dvARB(ref double[] v)
    {
      glWindowPos3dvARB del = (glWindowPos3dvARB)GetProc<glWindowPos3dvARB>();
      del(ref v);
    }

    public static void WindowPos3dvMESA(ref double[] v)
    {
      glWindowPos3dvMESA del = (glWindowPos3dvMESA)GetProc<glWindowPos3dvMESA>();
      del(ref v);
    }

    public static void WindowPos3f(float x, float y, float z)
    {
      glWindowPos3f del = (glWindowPos3f)GetProc<glWindowPos3f>();
      del(x, y, z);
    }

    public static void WindowPos3fARB(float x, float y, float z)
    {
      glWindowPos3fARB del = (glWindowPos3fARB)GetProc<glWindowPos3fARB>();
      del(x, y, z);
    }

    public static void WindowPos3fMESA(float x, float y, float z)
    {
      glWindowPos3fMESA del = (glWindowPos3fMESA)GetProc<glWindowPos3fMESA>();
      del(x, y, z);
    }

    public static void WindowPos3fv(ref float[] v)
    {
      glWindowPos3fv del = (glWindowPos3fv)GetProc<glWindowPos3fv>();
      del(ref v);
    }

    public static void WindowPos3fvARB(ref float[] v)
    {
      glWindowPos3fvARB del = (glWindowPos3fvARB)GetProc<glWindowPos3fvARB>();
      del(ref v);
    }

    public static void WindowPos3fvMESA(ref float[] v)
    {
      glWindowPos3fvMESA del = (glWindowPos3fvMESA)GetProc<glWindowPos3fvMESA>();
      del(ref v);
    }

    public static void WindowPos3i(int x, int y, int z)
    {
      glWindowPos3i del = (glWindowPos3i)GetProc<glWindowPos3i>();
      del(x, y, z);
    }

    public static void WindowPos3iARB(int x, int y, int z)
    {
      glWindowPos3iARB del = (glWindowPos3iARB)GetProc<glWindowPos3iARB>();
      del(x, y, z);
    }

    public static void WindowPos3iMESA(int x, int y, int z)
    {
      glWindowPos3iMESA del = (glWindowPos3iMESA)GetProc<glWindowPos3iMESA>();
      del(x, y, z);
    }

    public static void WindowPos3iv(ref int[] v)
    {
      glWindowPos3iv del = (glWindowPos3iv)GetProc<glWindowPos3iv>();
      del(ref v);
    }

    public static void WindowPos3ivARB(ref int[] v)
    {
      glWindowPos3ivARB del = (glWindowPos3ivARB)GetProc<glWindowPos3ivARB>();
      del(ref v);
    }

    public static void WindowPos3ivMESA(ref int[] v)
    {
      glWindowPos3ivMESA del = (glWindowPos3ivMESA)GetProc<glWindowPos3ivMESA>();
      del(ref v);
    }

    public static void WindowPos3s(short x, short y, short z)
    {
      glWindowPos3s del = (glWindowPos3s)GetProc<glWindowPos3s>();
      del(x, y, z);
    }

    public static void WindowPos3sARB(short x, short y, short z)
    {
      glWindowPos3sARB del = (glWindowPos3sARB)GetProc<glWindowPos3sARB>();
      del(x, y, z);
    }

    public static void WindowPos3sMESA(short x, short y, short z)
    {
      glWindowPos3sMESA del = (glWindowPos3sMESA)GetProc<glWindowPos3sMESA>();
      del(x, y, z);
    }

    public static void WindowPos3sv(ref short[] v)
    {
      glWindowPos3sv del = (glWindowPos3sv)GetProc<glWindowPos3sv>();
      del(ref v);
    }

    public static void WindowPos3svARB(ref short[] v)
    {
      glWindowPos3svARB del = (glWindowPos3svARB)GetProc<glWindowPos3svARB>();
      del(ref v);
    }

    public static void WindowPos3svMESA(ref short[] v)
    {
      glWindowPos3svMESA del = (glWindowPos3svMESA)GetProc<glWindowPos3svMESA>();
      del(ref v);
    }

    public static void WindowPos4dMESA(double x, double y, double z, double w)
    {
      glWindowPos4dMESA del = (glWindowPos4dMESA)GetProc<glWindowPos4dMESA>();
      del(x, y, z, w);
    }

    public static void WindowPos4dvMESA(ref double[] v)
    {
      glWindowPos4dvMESA del = (glWindowPos4dvMESA)GetProc<glWindowPos4dvMESA>();
      del(ref v);
    }

    public static void WindowPos4fMESA(float x, float y, float z, float w)
    {
      glWindowPos4fMESA del = (glWindowPos4fMESA)GetProc<glWindowPos4fMESA>();
      del(x, y, z, w);
    }

    public static void WindowPos4fvMESA(ref float[] v)
    {
      glWindowPos4fvMESA del = (glWindowPos4fvMESA)GetProc<glWindowPos4fvMESA>();
      del(ref v);
    }

    public static void WindowPos4iMESA(int x, int y, int z, int w)
    {
      glWindowPos4iMESA del = (glWindowPos4iMESA)GetProc<glWindowPos4iMESA>();
      del(x, y, z, w);
    }

    public static void WindowPos4ivMESA(ref int[] v)
    {
      glWindowPos4ivMESA del = (glWindowPos4ivMESA)GetProc<glWindowPos4ivMESA>();
      del(ref v);
    }

    public static void WindowPos4sMESA(short x, short y, short z, short w)
    {
      glWindowPos4sMESA del = (glWindowPos4sMESA)GetProc<glWindowPos4sMESA>();
      del(x, y, z, w);
    }

    public static void WindowPos4svMESA(ref short[] v)
    {
      glWindowPos4svMESA del = (glWindowPos4svMESA)GetProc<glWindowPos4svMESA>();
      del(ref v);
    }

    public static void WriteMaskEXT(uint res, uint inp, uint outX, uint outY, uint outZ, uint outW)
    {
      glWriteMaskEXT del = (glWriteMaskEXT)GetProc<glWriteMaskEXT>();
      del(res, inp, outX, outY, outZ, outW);
    }

    public static IntPtr MapBuffer(uint target, uint access)
    {
      glMapBuffer del = (glMapBuffer)GetProc<glMapBuffer>();
      return del(target, access);
    }

    public static IntPtr MapBufferARB(uint target, uint access)
    {
      glMapBufferARB del = (glMapBufferARB)GetProc<glMapBufferARB>();
      return del(target, access);
    }

    public static IntPtr MapBufferRange(uint target, IntPtr offset, IntPtr length, uint access)
    {
      glMapBufferRange del = (glMapBufferRange)GetProc<glMapBufferRange>();
      return del(target, offset, length, access);
    }

    public static IntPtr MapNamedBufferEXT(uint buffer, uint access)
    {
      glMapNamedBufferEXT del = (glMapNamedBufferEXT)GetProc<glMapNamedBufferEXT>();
      return del(buffer, access);
    }

    public static IntPtr MapNamedBufferRangeEXT(uint buffer, IntPtr offset, IntPtr length, uint access)
    {
      glMapNamedBufferRangeEXT del = (glMapNamedBufferRangeEXT)GetProc<glMapNamedBufferRangeEXT>();
      return del(buffer, offset, length, access);
    }

    public static IntPtr MapObjectBufferATI(uint buffer)
    {
      glMapObjectBufferATI del = (glMapObjectBufferATI)GetProc<glMapObjectBufferATI>();
      return del(buffer);
    }

    public static IntPtr MapTexture2DINTEL(uint texture, int level, uint access, ref int[] stride, ref uint[] layout)
    {
      glMapTexture2DINTEL del = (glMapTexture2DINTEL)GetProc<glMapTexture2DINTEL>();
      return del(texture, level, access, ref stride, ref layout);
    }

  }
}
